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
                n.SetType();
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
                unsortedChains.Add(new Chain(startingNodes[i], i));
                unsortedChains[i].AddNode(startingNodes[i]);
            }
            return unsortedChains;
        }

        public Chain numberParentSegment(Chain parentChain)
        {
            List<Node> endNodes = GetStartingNodes(parentChain.NodeList);                
            Queue<Node> q = new Queue<Node>();                                           
            Queue<Node> _q = new Queue<Node>();                                          
            int count = 0;                                                               
            int _count = 0;
            Node previousNode = new Node();
            q.Enqueue(endNodes[0]);
            _q.Enqueue(endNodes[1]);
            while(q.Count > 0)                                                           
            {                                                                            
                count++;                                                                 
                var currentNode = q.Dequeue();
                if (count == 1)
                {
                    previousNode = currentNode;

                }
                if (currentNode.Neighbors.Count >= 3 || endNodes.IndexOf(currentNode) != -1 && count > 1)                                    
                {                                                                        
                    q.Clear();                                                           
                }
                else
                {
                    q.Enqueue(currentNode.Neighbors.Find(_n => _n != previousNode && _n != currentNode));
                }
                if (count > 1)
                {
                    previousNode = currentNode;
                }

            }
            while (_q.Count > 0)                                                         
            {                                                                            
                _count++;                                                                
                var currentNode = _q.Dequeue();
                if (_count == 1)
                {
                    previousNode = currentNode;

                }
                if (currentNode.Neighbors.Count >= 3 || endNodes.IndexOf(currentNode) != -1 && _count > 1 )                                    
                {                                                                        
                    _q.Clear();                                                          
                }
                else
                {
                    _q.Enqueue(currentNode.Neighbors.Find(_n => _n != previousNode && _n != currentNode));                    
                }
                if (_count > 1)
                {
                    previousNode = currentNode;
                }
            }


            if (count > _count)
            {
                parentChain.NodeList.Reverse();
            }
            foreach (var n in parentChain.NodeList)
            {
                n.Position = parentChain.NodeList.FindIndex(a => a == n) + 1;
            }

            return parentChain;                                                          
        }                                                                                

        //Sending back the parent chain object
        //Every node that has a branch is identified by looping through and checking Branches.count
        //Every branch that is listed will be a side chain from the parent chain
        public Molecule FindLongestChain(List<Node> nodesIn)
        {
            Chain parentChain = new Chain();
            List<Chain> unsortedChains = GetStartingChains(GetStartingNodes(nodesIn));
            List<Chain> parentSegment = new List<Chain>();
            List<Chain> sideChains = new List<Chain>();
            int sideChainsFound = 0;

            
            while (ParentChainsUnfound(parentSegment))
            {
                for (int i = 0; i < unsortedChains.Count; i++)
                {
                    if (IsUnclassified(unsortedChains[i]))
                    {
                        Chain c = unsortedChains[i];
                        Node previousNode = c.CurrentNode;
                        Node cn = c.CurrentNode = c.FindNextNode();
                        if (cn.NodeTag != null)
                        {
                            if (cn.Next)
                            {
                                c.AddNode(cn);
                            }
                        }
                        else
                        {
                            c.CurrentNode = previousNode;
                            cn = c.FindBranchLink();
                            c.Side = true;
                            cn.AddBranch(c);
                            sideChainsFound++;
                        }
                        previousNode.Checked = true;
                    }
                    if (!SideChainsToFind(sideChainsFound, unsortedChains.Count))
                    {
                        foreach (Chain c in unsortedChains)
                        {
                            if (c.Parent == false && c.Side == false)
                            {
                                c.Parent = true;
                                parentSegment.Add(c);
                            }
                        }
                    }
                }
            }
            bool finished = false;
            while (finished == false)
            {
                if (parentSegment[0].CurrentNode != parentSegment[1].CurrentNode)
                {
                    Node nextNode = parentSegment[0].FindNextNode();
                    if (parentSegment[1].CurrentNode != nextNode)
                    {
                        if (nextNode.HasNeighbor(parentSegment[1].CurrentNode))
                        {
                            finished = true;
                        }
                        parentSegment[0].AddNode(nextNode);
                        parentSegment[0].CurrentNode = nextNode;
                    }
                    else if (parentSegment[1].CurrentNode == nextNode)
                    {
                        finished = true;
                    }
                }
            }
            parentSegment[0].AddChain(parentSegment[1]);
            numberParentSegment(parentSegment[0]);
            Molecule mol = new Molecule();


            mol.ParentChain = parentSegment[0];
            mol.SideChains = new List<Chain>();
            foreach (Chain c in unsortedChains)
            {
                if (c.Side)
                {
                    mol.SideChains.Add(c);
                }
            }

            return mol;
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