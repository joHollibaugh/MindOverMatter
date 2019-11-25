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
            return PartialView("~/Views/Home/RatingModal.cshtml", new RatingModalModel() { MoleculeId = "10", MoleculeName="Ethane", UserIdEncrypt=User.Identity.GetUserId() }); 
        }
    }
}
