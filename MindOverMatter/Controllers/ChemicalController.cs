using Microsoft.AspNetCore.Mvc;
using MindOverMatter.Models.DbContexts;
using MindOverMatter.Models.Matter;
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

        public int FindChainLength(List<Node> nodes)
        {
            
            Node c0 = new Node() { NodeId = "C0" };
            Node c1 = new Node() { NodeId = "C2" };
            Node c2 = new Node() { NodeId = "C3" };
            Node c3 = new Node() { NodeId = "C4" };
            c0.Neighbors = new List<Node>() { c1, c2 };
            c1.Neighbors = new List<Node>() { c0 };
            c2.Neighbors = new List<Node>() { c0, c3 };
            c3.Neighbors = new List<Node>() { c2 };

            List<Node> fakeNodes = new List<Node>() {c0, c1, c2, c3 };
        }

    }
}
