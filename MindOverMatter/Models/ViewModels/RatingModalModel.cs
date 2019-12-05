using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindOverMatter.Models.ViewModels
{
    public class RatingModalModel
    {
        public string MoleculeName { get; set; }
        public string MoleculeId { get; set; }
        public string UserIdEncrypt { get; set; }
        public string MoleculeJson { get; set; }
        public string MainChainJson { get; set; } = String.Empty;
    }
}
