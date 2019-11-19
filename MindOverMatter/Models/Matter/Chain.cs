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


        public void AddNode(Node newNode)
        {
            NodeList.Add(newNode);
        }

        public void AddChain(Chain segment)
        {
            for(int i = segment.NodeList.Count - 1; i >= 0; i--)
            {
                NodeList.Add(segment.NodeList[i]);
            }
        }

        public Node FindNextNode()
        {
            Node nextNode = new Node();
            foreach (Node n in CurrentNode.Neighbors)
            {
                n.Scan();
                if (!n.Divergent && n.Next)
                {
                    nextNode = n;
                }
                else if(n.Divergent && n.Next)
                {
                    nextNode = n;
                }
                n.Scans++;
            }
            return nextNode;
        }

        public Node FindBranchLink()
        {
            Node nextNode = new Node();
            foreach (Node n in CurrentNode.Neighbors)
            {
                if (n.Divergent && !n.Checked)
                {
                    nextNode = n;
                }
            }
            return nextNode;
        }
    }
}

