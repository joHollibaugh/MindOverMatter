using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            Chains = chains;
            Nodes = nodes;
        }
        public Molecule(List<Node> nodes)
        {
            Nodes = nodes;
        }

        [Required]
        [Key]
        public int MoleculeId { get; set; }
        public List<Chain> Chains { get; set; }
        public string Name { get; set; }
        public List<Node> Nodes { get; set; }

        public void SetDivergentNodes()
        {
            for(int i = 0; i < Nodes.Count; i++)
            {
                if(Nodes[i].Neighbors.Count > 2)
                {
                    Nodes[i].Divergent = true;
                }
            }
        }
    }



}
