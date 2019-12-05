using Microsoft.AspNetCore.Mvc;
using MindOverMatter.Models.DbContexts;
using MindOverMatter.Models.Matter;
using MindOverMatter.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using MindOverMatter.Models.ViewModels;
using Microsoft.AspNet.Identity;
using MindOverMatter.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public ActionResult getMolecule(string input)
        {
            List<ConvertableMol> Clist = JsonConvert.DeserializeObject<List<ConvertableMol>>(input);
            var map = new Dictionary<string, String[]>();
            List<Node> nodeList = new List<Node>();
            List<Node> convertedList = new List<Node>();
            foreach (ConvertableMol C in Clist)
            {                
                Node n = new Node() { NodeTag = C.ID };
                nodeList.Add(n);
                map.Add(n.NodeTag, C.b);
            }
            foreach (var pair in map)
            {
                List<Node> _neighbors = new List<Node>();
                Node n = nodeList.Find(x => x.NodeTag == pair.Key);
                foreach (string s in pair.Value)
                {
                    _neighbors.Add(nodeList.Find(x => x.NodeTag == s));
                }
                if (_neighbors.Count >= 1);
                n.Neighbors = _neighbors;
                convertedList.Add(n);
            }
            //int length = scanner._longestChain(convertedList);
            if (convertedList.Count <= 3)
            {
                String Name = "";
                switch (convertedList.Count)
                {
                    case 1:
                        Name = "Methane";
                        break;
                    case 2:
                        Name = "Ethane";
                        break;
                    case 3:
                        Name = "Propane";
                        break;
                }
                return PartialView("~/Views/Home/RatingModal.cshtml", new RatingModalModel() { MoleculeName = Name, UserIdEncrypt = User.Identity.GetUserId(), MoleculeJson = input });
            }
            else
            {
                try
                {
                    List<string> _mainChainJson = new List<string>();
                    Molecule mol = scanner.FindLongestChain(convertedList);
                    foreach(Node n in mol.ParentChain.NodeList)
                    {
                        _mainChainJson.Add(n.NodeTag);
                    }
                    string[][] jsonChain = _mainChainJson.Select(x => new string[] { x }).ToArray();

                    return PartialView("~/Views/Home/RatingModal.cshtml", new RatingModalModel() { MoleculeName = mol.getName(_context), UserIdEncrypt = User.Identity.GetUserId(), MoleculeJson = input, MainChainJson = JsonConvert.SerializeObject(jsonChain) });

                }
                catch(Exception ex)
                {
                    return PartialView("~/Views/Home/RatingModal.cshtml", new RatingModalModel() { MoleculeName = "Couldn't find a name!", UserIdEncrypt = User.Identity.GetUserId(), MoleculeJson = input });
                }
            }
        }

        [Authorize]
        public ActionResult RateName(string rating, string moleculeJson, string name)
        {
            bool isValid;
            int score = -1;
            isValid =  int.TryParse(rating,out score);

            if (isValid)
            {
                DbContextOptionsBuilder<ChemicalDbContext> options = new DbContextOptionsBuilder<ChemicalDbContext>();
                using (var chemicalDbContext = new ChemicalDbContext(options.Options))
                {
                    Molecule molecule = new Molecule() { Name = name, MoleculeJson = moleculeJson };
                    chemicalDbContext.Add(molecule);
                    chemicalDbContext.SaveChanges();

                    Rating ratingObj = new Rating() { Score = Convert.ToInt32(rating), UserId = this.User.Identity.GetUserId(), MoleculeId = molecule.MoleculeId };
                    chemicalDbContext.Add(ratingObj);
                    chemicalDbContext.SaveChanges();
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
