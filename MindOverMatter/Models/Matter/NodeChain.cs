using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindOverMatter.Models.Matter
{
    //Due to the version of EF we are using this was the only method of creating a linking table to normalize the db
    public class NodeChain
    {
        public int ChainId { get; set; }
        public string NodeId { get; set; }
    }
}
