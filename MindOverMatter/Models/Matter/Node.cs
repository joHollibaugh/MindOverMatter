using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MindOverMatter.Models.Matter
{
    public class Node
    {
        public Node()
        {

        }

        [Required]
        [Key]
        public string NodeId { get; set; }
        public Atom Atom { get; set; }
        public int Scans { get; set; }
        public Boolean Divergent { get; set; }
        public List<Node> Neighbors { get; set; }

    }
}
