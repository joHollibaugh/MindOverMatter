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
                n.IsDivergent();
                n.SetBonds();
                if (n.Neighbors.Count == 1)
                {
                    outerNodes.Add(n);
                    n.Outer = true;
                }
            }
            return outerNodes;
        }
        public List<Chain> GetStartingChains(List<Node> startingNodes)
        {
            List<Chain> unsortedChains = new List<Chain>();
            for (int i = 0; i < startingNodes.Count; i++)
            {
                unsortedChains.Add(new Chain(startingNodes[i]));
                _context.Chain.Add(unsortedChains[i]);
                unsortedChains[i].AddNode(startingNodes[i]);
                _context.SaveChanges();

            }
            return unsortedChains;
        }


        //If it doesn't work right away I'll fix it
        //I spent 12 hours working towards this and I assume the responsibility off hammering all of my code out
        public Chain FindLongestChain(List<Node> nodesIn)
        {
            Chain parentChain = new Chain();
            List<Chain> unsortedChains = GetStartingChains(GetStartingNodes(nodesIn));
            List<Chain> parentChainSegments = new List<Chain>();
            List<Chain> sideChains = new List<Chain>();
            int sideChainsFound = 0;

            while (ParentChainsUnfound(parentChainSegments) && SideChainsToFind(sideChainsFound, unsortedChains.Count))
            {
                //Loop through all unsorted chains and ignore classified chains
                for (int i = 0; i < unsortedChains.Count; i++)
                {
                    //Classification is parent or side chain, included as boolean values of the class
                    if (IsUnclassified(unsortedChains[i]) && sideChainsFound != unsortedChains.Count - 2)
                    {
                        Chain c = unsortedChains[i];
                        //Finding the next node in line for the chain
                        Node cn = c.CurrentNode = c.FindNextNode();

                        if (cn.Divergent)
                        {
                            bool cnChecked = cn.IsLastArrival();
                            //Checked = true --> Largest Branch converging at this node identified
                            //Checked = false --> Side Chain identified
                            if (!cnChecked)
                            {
                                c.Side = true;
                                cn.AddBranch(c);
                                if (!cn.nodeChains.Contains(new NodeChain { NodeId = cn.NodeId, ChainId = c.ChainId }))
                                {
                                    _context.NodeChains.Add(cn.nodeChains.Last());
                                }
                            }
                            else if (cnChecked)
                            {
                                //This chain is the largest to arrive at the divergent node, it continues to grow
                                cn.AddBranch(c);
                                c.AddNode(cn);
                                if (!cn.nodeChains.Contains(new NodeChain { NodeId = cn.NodeId, ChainId = c.ChainId }))
                                {
                                    _context.NodeChains.Add(cn.nodeChains.Last());
                                }
                                //Now it gets skipped and is effectively dead to the scanner
                                sideChainsFound++;
                            }
                            //Every node will get linked to all chains that are connected to it
                        }
                        else if (cn.Linear)
                        {
                            c.AddNode(cn);
                            cn.AddBranch(c);
                            if (cn.nodeChains.Contains(new NodeChain { NodeId = cn.NodeId, ChainId = c.ChainId }) == false)
                            {
                                _context.NodeChains.Add(cn.nodeChains.Last());
                            }
                        }
                        else if (cn.Outer)
                        {
                            //something went wrong
                        }
                    }
                    else if (!SideChainsToFind(sideChainsFound, unsortedChains.Count))
                    {
                        foreach (Chain c in unsortedChains)
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
            parentChainSegments[0].AddChain(parentChainSegments[1]);
            parentChain = parentChainSegments[0];
            return parentChain;
        }


        public bool ParentChainsUnfound(List<Chain> parentSegments)
        {
            if (parentSegments.Count == 2)
            {
                return false;
            }
            return true;
        }

        public bool IsUnclassified(Chain c)
        {
            if (c.Parent == false && c.Side == false)
            {
                return true;
            }
            return false;
        }

        public bool SideChainsToFind(int found, int chainCount)
        {
            if(found + 2 == chainCount)
            {
                return false;
            }
            return true;
        }
    }
}


