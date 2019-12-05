using Microsoft.EntityFrameworkCore;
using MindOverMatter.Models.Identity;
using MindOverMatter.Models.Matter;
using MindOverMatter.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindOverMatter.Models.ViewModels
{
    public class AdminViewModel
    {
        public List<Rating> Ratings { get; set; }
        public Dictionary<int, Molecule> Molecules { get; set; }
    }
}
