using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MindOverMatter.Models.Matter
{
    public class Atom
    {
        public Atom()
        {

        }
        [Key]
        public int AtomId { get; set; }
        public int BondPotential { get; set; }
        public string Name { get; set; }
    }
}
