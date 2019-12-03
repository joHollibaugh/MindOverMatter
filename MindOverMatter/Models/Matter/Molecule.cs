using MindOverMatter.Models.DbContexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MindOverMatter.Models.Matter
{
    public class Molecule
    {
        public Molecule()
        {
        }
        //public Molecule(int Id, string name, List<Chain> chains)
        //{
        //    MoleculeId = Id;
        //    Name = name;
        //}

        [Required]
        [Key]
        public int MoleculeId { get; set; }
        public string Name { get; set; }

        public string MoleculeJson { get; set; }
        [NotMapped]
        public List<Chain> SideChains { get; set; }
        [NotMapped]
        public Chain ParentChain { get; set; }
        [NotMapped]
        private ChemicalDbContext context;

        public string getName(ChemicalDbContext _context)
        {
            Dictionary<int, string> map = new Dictionary<int, string>();
            int counter = 0;
            foreach (Node n in this.ParentChain.NodeList)
            {
                if (n.Divergent)
                {
                    map.Add(n.Position, _context.GetPrefixByLength(n.Branches[0].NodeList.Count()).Name);
                }
            }
            var identicalPairs = map.ToLookup(x => x.Value, x => x.Key).Where(x => x.Count() > 1);
            foreach (var item in identicalPairs)
            {
                var keys = item.Aggregate("", (s, v) => s + ", " + v);
                this.Name += keys + "-Di" + item.Key + "yl";
                this.Name.Substring(1);
            }
            foreach(var item in identicalPairs)
            {
                map.Remove(item.ElementAt(0));
                map.Remove(item.ElementAt(1));

            }
            foreach (var item in map)
            {
                Name += item.Key + "-" + item.Value + "yl";
            }


            this.Name += _context.GetPrefixByLength(this.ParentChain.NodeList.Count).Name + "ane";
           
            return this.Name;
        }
    }

}
