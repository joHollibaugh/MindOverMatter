using Microsoft.AspNetCore.Mvc;
using MindOverMatter.Models.DbContexts;
using MindOverMatter.Models.Matter;
using MindOverMatter.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindOverMatter.Controllers
{
    public class ChemicalController : Controller
    {
        readonly ChemicalDbContext _context;
        private MoleculeScanner scanner;
        public ChemicalController(ChemicalDbContext context)
        {
            _context = context;
            //scanner can access DB
            scanner = new MoleculeScanner(context);
        }

        [HttpPost]
        public ActionResult getMolecule(string input)
        {
            return null;   
        }
        public string GetMoleculeName()
        {

            Node c0 = new Node() { NodeTag = "C0" };
            Node c1 = new Node() { NodeTag = "C1" };
            Node c2 = new Node() { NodeTag = "C2" };
            Node c3 = new Node() { NodeTag = "C3" };
            Node c4 = new Node() { NodeTag = "C4" };
            Node c5 = new Node() { NodeTag = "C5" };
            Node c6 = new Node() { NodeTag = "C6" };
            Node c7 = new Node() { NodeTag = "C7" };
            Node c8 = new Node() { NodeTag = "C8" };
            c0.Neighbors = new List<Node>() { c1, c7, c8 };
            c1.Neighbors = new List<Node>() { c0, c2, c4 };
            c2.Neighbors = new List<Node>() { c1, c3, c5 };
            c3.Neighbors = new List<Node>() { c2 };
            c4.Neighbors = new List<Node>() { c1 };
            c5.Neighbors = new List<Node>() { c2, c6 };
            c6.Neighbors = new List<Node>() { c5 };
            c7.Neighbors = new List<Node>() { c0 };
            c8.Neighbors = new List<Node>() { c0 };

            List<Node> fakeNodes = new List<Node>() { c0, c1, c2, c3, c4, c5, c6, c7, c8 };

            Chain parentChain = scanner.FindLongestChain(fakeNodes);
            return "In Progress...";
        }
    }
}
