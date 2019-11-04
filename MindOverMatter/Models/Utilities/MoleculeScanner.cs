using MindOverMatter.Models.DbContexts;
using MindOverMatter.Models.Matter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindOverMatter.Models.Utilities
{
    public class MoleculeScanner
    {
        public Molecule M { get; set; }
        private readonly ChemicalDbContext _context;
        public MoleculeScanner(ChemicalDbContext context)
        {
            _context = context;
        }

        public List<Node> GetStartingNodes(List<Node> allNodes)
        {
            List<Node> outerNodes = new List<Node>();
            foreach (Node n in allNodes)
            {
                if (n.Neighbors.Count == 1)
                {
                    outerNodes.Add(n);
                    n.Outer = true;
                }
            }
            return outerNodes;
        }

        //If it doesn't work right away I'll fix it
        //I spent 12 hours working towards this and I assume the responsibility off hammering all of my code out
        public Chain FindLongestChain(List<Node> outerNodes)
        {
            //The goal
            Chain parentChain = new Chain();
            //Start a chain with each outer node.
            List<Chain> outerChains = new List<Chain>();
            for(int i = 0; i < outerNodes.Count; i++) { outerChains.Add(new Chain(outerNodes[i], _context.GetNewChainId())); }
            int sideChainsFound = 0;

            //We will sort them into here
            List<Chain> parentChainSegments = new List<Chain>();

            while (parentChainSegments.Count != 2)
            {
                for (int i = 0; i <= outerChains.Count; i++)
                {
                    if (outerChains[i].Parent == false && outerChains[i].Side == false && sideChainsFound != outerChains.Count - 2)
                    {
                        Chain c = outerChains[i];
                        c.CurrentNode = c.FindNextNode();
                        Node cn = c.CurrentNode;

                        cn.BranchCount = cn.Neighbors.Count;

                        //IsDivergent will set the type(Divergent,Linear,Outer) to true
                        if (cn.IsDivergent())
                        {
                            //Checked = true --> All other branches have made it to the node
                            if (cn.IsChecked())
                            {
                                //This chain is the largest to arrive at the divergent node, it continues to grow
                                c.AddNode(cn);
                                cn.AddBranch(c);
                                _context.NodeChains.Add(cn.nodeChains.Last());
                            }
                            else if (!cn.IsChecked())
                            {
                                cn.AddBranch(c);
                                _context.NodeChains.Add(cn.nodeChains.Last());
                                //Now it gets skipped and is effectively dead to the scanner
                                c.Side = true;
                                sideChainsFound++;
                            }
                            //Every node will get linked to all chains that are connected to it
                        }
                        else if (cn.Linear)
                        {
                            c.AddNode(cn);
                            cn.AddBranch(c);
                            _context.NodeChains.Add(cn.nodeChains.Last());
                        }
                        else if (cn.Outer)
                        {
                            //something went wrong
                        }
                    }
                    else if (sideChainsFound == outerChains.Count - 2)
                    {
                        foreach (Chain c in outerChains)
                        {
                            if (c.Parent == false && c.Side == false)
                            {
                                c.Parent = true;
                                parentChainSegments.Add(c);
                            }
                        }
                    }
                }
            }
            bool finished = false;
            while (finished == false)
            {
                //If each segment is not on the same node upon arrival
                if (parentChainSegments[0].CurrentNode != parentChainSegments[1].CurrentNode)
                {
                    //All branches have been eliminated and the remaining nodes between each parent segment are linear
                    //Find the next node on one half
                    Node SegmentOneNextNode = parentChainSegments[0].FindNextNode();
                    if (parentChainSegments[1].CurrentNode != SegmentOneNextNode)
                    {
                        //If the next node is a neighbor of the second chain we have scanned then we can combine and return them
                        if (SegmentOneNextNode.HasNeighbor(parentChainSegments[1].CurrentNode))
                        {
                            finished = true;
                        }
                        parentChainSegments[0].AddNode(SegmentOneNextNode);
                        SegmentOneNextNode.AddBranch(parentChainSegments[0]);
                        parentChainSegments[0].CurrentNode = SegmentOneNextNode;
                    }
                    //If the next node lands in segment 2 we can combine them and return
                    else if(parentChainSegments[1].CurrentNode == SegmentOneNextNode)
                    {
                        finished = true;
                    }
                }

                if(finished == true)
                {
                    parentChain = parentChainSegments[1];
                    foreach(Node n in parentChainSegments[0].NodeList)
                    {
                        parentChain.NodeList.Add(n);
                    }
                }
            }
            return parentChain;
        }
    }
}
