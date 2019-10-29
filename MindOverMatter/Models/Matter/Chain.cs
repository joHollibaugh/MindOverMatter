using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindOverMatter.Models.Matter
{
    public class Chain
    {
        public Chain()
        {

        }
        public int ChainId { get; set; }
        public List<Node> ChainNodes { get; set; }
        public Boolean Parent { get; set; }
    }
}
