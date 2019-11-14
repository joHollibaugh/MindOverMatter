using MindOverMatter.Models.DbContexts;
using MindOverMatter.Models.Matter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
                n.SetBonds();
                n.IsDivergent();
                if (n.Outer == true)
                {
                    outerNodes.Add(n);
                    n.Checked = true;
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

        public int _longestChain(List<Node> nodes)
        {
            int length = 0;
            Node root = GetStartingNodes(nodes).FirstOrDefault();
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                length++;
                var parentChain = new List<Node>();
                var qSize = q.Count;
                var prevNode = new Node();
                for (int i = 0; i < qSize; i++)
                {
                    var currentNode = q.Dequeue();
                    if (currentNode.Neighbors != null)
                    {
                        foreach (var child in currentNode.Neighbors)
                        {
                            q.Enqueue(child);
                        }
                    }
                }
            }
            return length;
        }

        public Chain FindLongestChain(List<Node> nodesIn)
        {
            Chain parentChain = new Chain();
            List<Chain> unsortedChains = GetStartingChains(GetStartingNodes(nodesIn));
            List<Chain> parentChainSegments = new List<Chain>();
            List<Chain> sideChains = new List<Chain>();
            int sideChainsFound = 0;

            
            while (ParentChainsUnfound(parentChainSegments))
            {
                for (int i = 0; i < unsortedChains.Count; i++)
                {

                    if (IsUnclassified(unsortedChains[i]))
                    {
                        Chain c = unsortedChains[i];
                        Node cn = c.CurrentNode = c.FindNextNode();

                        if (cn.NodeTag != null)
                        {
                            cn.AddBranch(c);
                            c.AddNode(cn);
                            if (!cn.nodeChains.Contains(new NodeChain { NodeId = cn.NodeId, ChainId = c.ChainId }))
                            {
                                _context.NodeChains.Add(cn.nodeChains.Last());
                            }
                        }
                        else
                        {
                            c.Side = true;
                            sideChainsFound++;
                        }
                    }
                    if (!SideChainsToFind(sideChainsFound, unsortedChains.Count))
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
            bool finished = false;
            while (finished == false)
            {
                //Line
                if (parentChainSegments[0].CurrentNode != parentChainSegments[1].CurrentNode)
                {
                    Node SegmentOneNextNode = parentChainSegments[0].FindNextNode();
                    if (parentChainSegments[1].CurrentNode != SegmentOneNextNode)
                    {
                        if (SegmentOneNextNode.HasNeighbor(parentChainSegments[1].CurrentNode))
                        {
                            finished = true;
                        }
                        parentChainSegments[0].AddNode(SegmentOneNextNode);
                        SegmentOneNextNode.AddBranch(parentChainSegments[0]);
                        parentChainSegments[0].CurrentNode = SegmentOneNextNode;
                    }
                    else if (parentChainSegments[1].CurrentNode == SegmentOneNextNode)
                    {
                        finished = true;
                    }
                }
            }
            parentChainSegments[0].AddChain(parentChainSegments[1]);
            return parentChainSegments[0];
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
            if (found + 2 == chainCount)
            {
                return false;
            }
            return true;
        }
    }
}


