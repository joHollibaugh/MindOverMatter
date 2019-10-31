using Microsoft.AspNetCore.Mvc;
using MindOverMatter.Models.ChemicalDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindOverMatter.Controllers
{
    public class ChemicalController : Controller
    {
        private readonly ChemicalDbContext _context;

        public ChemicalController(ChemicalDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public string GetMoleculeName(string CH3List)
        {
            
            string Name = "Butane";

            return Name;
        }
    }
}
