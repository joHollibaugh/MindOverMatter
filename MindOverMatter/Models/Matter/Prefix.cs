using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MindOverMatter.Models.Matter
{
    public class Prefix
    {
        public Prefix()
        {

        }
        [Key]
        public int PrefixId { get; set; }
        public String Name { get; set; }
        public int ChainLength { get; set; }
    }
}
