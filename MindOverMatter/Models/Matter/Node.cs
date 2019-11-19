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
        }

        public Node(int id)
        {
            Neighbors = new List<Node>();
            Branches = new List<Chain>();
            Bonds = 0;
        }

        public Node(int id, List<Node> neighbors)
        {
            Branches = new List<Chain>();
            Neighbors = neighbors;
            Bonds = neighbors.Count;
        }

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
        public bool Next { get; set; }
        [NotMapped]
        public List<Node> Neighbors { get; set; }
        [NotMapped]
        public List<Chain> Branches { get; set; }
        [NotMapped]
        public int Scans { get; set; }
        [NotMapped]
        public int Position { get; set; }


        //Methods
        public void AddBranch(Chain branch)
        {
            Chain nonReferenceBranch = new Chain();
            foreach (Node n in branch.NodeList)
            {
                nonReferenceBranch.NodeList.Add(n);
            }
            Branches.Add(nonReferenceBranch);
        }

        public void AddNeighbor(Node newNeighbor)
        {
            Neighbors.Add(newNeighbor);
            Bonds = Neighbors.Count();
        }

        public void SetType()
        {
            if (Bonds > 2)
            {
                Divergent = true;
            }
            else if (Bonds == 1)
            {
                Outer = true;
            }
            else if (Bonds == 2)
            {
                Linear = true;
            }
        }

        public bool Scan()
        {
            switch (Bonds)
            {
                case 1:
                    Next = false;
                    break;
                case 2:
                    if (Scans == 0)
                    {
                        Next = true;
                    }
                    else
                        Next = false;
                    break;
                case 3:
                case 4:
                    if (Scans + 2 == Bonds)
                    {
                        Next = true;
                    }
                    else
                        Next = false;
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

        public override string ToString()
        {
            return NodeTag;
        }
    }

}
