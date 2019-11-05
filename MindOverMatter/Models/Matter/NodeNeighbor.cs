using MindOverMatter.Models.DbContexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MindOverMatter.Models.Matter
{
    //Due to the version of EF we are using this was the only method of creating a linking table to normalize the db
    public class NodeNeighbor
    {
        public int NodeId { get; set; }
        public int NeighborId { get; set; }

    }
}
