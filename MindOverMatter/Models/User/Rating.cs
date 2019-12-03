using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MindOverMatter.Models.User
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        public string UserId { get; set; }
        public int MoleculeId { get; set; }
        public int Score { get; set; }
    }
}
