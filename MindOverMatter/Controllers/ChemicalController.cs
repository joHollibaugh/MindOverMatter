using Microsoft.AspNetCore.Mvc;
using MindOverMatter.Models.DbContexts;
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
    }
}
