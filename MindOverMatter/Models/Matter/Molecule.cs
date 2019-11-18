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
        public Molecule(int Id, string name, List<Chain> chains, List<Node> nodes)
        {
            MoleculeId = Id;
            Name = name;
            Nodes = nodes;
        }
        public Molecule(List<Node> nodes)
        {
            Nodes = nodes;
        }

        [Required]
        [Key]
        public int MoleculeId { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public List<Node> Nodes { get; set; }

    }



}
