using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MindOverMatter.Models.Matter
{
    public class Chain
    {
        public Chain()
        {
            NodeList = new List<Node>();
        }
        public Chain(Node n)
        {
            CurrentNode = n;
            NodeList = new List<Node>();
        }
        public Chain(Node n, int id)
        {
            ChainId = id;
            CurrentNode = n;
            NodeList = new List<Node>();
        }

        public int ChainId { get; set; }
        public List<Node> NodeList { get; set; }
        public Boolean Parent { get; set; }
        public Boolean Side { get; set; }
        public Node CurrentNode { get; set; }

        //Used by Entity Framework
        public NodeChain NodeChain { get; set; }

        public void AddNode(Node newNode)
        {
            NodeList.Add(newNode);
        }

        public void AddChain(Chain segment)
        {
            foreach(Node n in segment.NodeList)
            {
                NodeList.Add(n);
            }
        }

        public Node FindNextNode()
        {
            //Make sure all of the branches on divergent nodes have been exhausted prior to finding the next node
            Node nextNode = new Node();
            foreach (Node n in CurrentNode.Neighbors)
            {
                //If this neighbor hasn't been checked and we have established a linear path (not divergent)
                //This must be the next node
                if (!n.IsDivergent() && !n.Checked)
                {
                    nextNode = n;
                }
                else if(n.IsDivergent())
                {
                    nextNode = n;
                }
            }
            return nextNode;
        }

    }
}

