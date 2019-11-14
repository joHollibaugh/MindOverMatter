using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MindOverMatter.Models.Matter
{
    public class Node
    {
        public Node()
        {
            Neighbors = new List<Node>();
            Branches = new List<Chain>();
            Bonds = 0;
            nodeChains = new List<NodeChain>();
        }

        public Node(int id)
        {
            Neighbors = new List<Node>();
            Branches = new List<Chain>();
            NodeId = id;
            Bonds = 0;
            nodeChains = new List<NodeChain>();
        }

        public Node(int id, List<Node> neighbors)
        {
            Branches = new List<Chain>();
            NodeId = id;
            Neighbors = neighbors;
            Bonds = neighbors.Count;
            nodeChains = new List<NodeChain>();
        }

        [Required]
        [Key]
        public int NodeId { get; set; }
        public string NodeTag { get; set; }
        //Properties
        public Atom Atom { get; set; }
        //The number of bonds extending from this node
        public int Bonds { get; set; }

        //Node "Types" are based off of the number of branches
        //Divergent >= 3
        public bool Divergent { get; set; }
        //Outer = 1
        public bool Outer { get; set; }
        //Linear = 2
        public bool Linear { get; set; }

        //Unmapped(not in the database) Properties
        [NotMapped]
        public bool Checked { get; set; }
        [NotMapped]
        public List<Node> Neighbors { get; set; }
        [NotMapped]
        public List<Chain> Branches { get; set; }



        //Used by Entity Framework
        public List<NodeChain> nodeChains { get; set; }
        public List<NodeNeighbor> nodeNeighbors { get; set; }


        //Methods
        public void AddBranch(Chain newBranch)
        {
            Branches.Add(newBranch);
            nodeChains.Add(new NodeChain { NodeId = NodeId, ChainId = newBranch.ChainId });
        }

        public void AddNeighbor(Node newNeighbor)
        {
            Neighbors.Add(newNeighbor);
            Bonds = Neighbors.Count();
        }

        public bool IsDivergent()
        {
            if (Bonds > 2)
            {
                Divergent = true;
            }
            else if (Bonds <= 2)
            {
                Divergent = false;
                if (Bonds == 1)
                {
                    Outer = true;
                    Linear = false;
                }
                if (Bonds == 2)
                {
                    Outer = false;
                    Linear = true;
                }
            }
            return Divergent;
        }

        public bool IsLastArrival()
        {
            //Nodes are considered "Checked" by different criteria depending on how many branches they have
            //Bonds is the total bonds and Branches is the chains that have been attached
            switch (Bonds)
            {
                case 1:
                    Checked = true;
                    break;
                case 2:
                    if (Branches.Count == 1 || Branches.Count == 2)
                    {
                        Checked = true;
                    }
                    break;
                case 3:
                case 4:
                    if (Branches.Count + 2 >= Bonds)
                    {
                        Checked = true;
                    }
                    break;
            }
            return Checked;
        }

        public bool IsCheckedByParent()
        {
            switch (Bonds)
            {
                case 1:
                    Checked = true;
                    break;
                case 2:
                    if (Branches.Count == 2)
                    {
                        Checked = true;
                    }
                    break;
                case 3:
                case 4:
                    if (Branches.Count + 2 >= Bonds)
                    {
                        Checked = true;
                    }
                    break;
            }
            return Checked;
        }

        public bool HasNeighbor(Node n)
        {
            bool hasNeighbor = false;
            foreach (Node neighbor in Neighbors)
            {
                if (n.NodeTag == neighbor.NodeTag)
                {
                    hasNeighbor = true;
                }
            }
            return hasNeighbor;
        }

        public void SetBonds()
        {
            Bonds = Neighbors.Count;
        }
    }
}
