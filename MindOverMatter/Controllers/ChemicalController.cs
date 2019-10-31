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
            Node c1 = new Node() { NodeId = "C1" };
            Node c2 = new Node() { NodeId = "C2" };
            Node c3 = new Node() { NodeId = "C3" };
            Node c4 = new Node() { NodeId = "C4" };
            Node c5 = new Node() { NodeId = "C5" };
            Node c6 = new Node() { NodeId = "C6" };
            Node c7 = new Node() { NodeId = "C7" };
            Node c8 = new Node() { NodeId = "C8" };
            Node c9 = new Node() { NodeId = "C9" };
            Node c10 = new Node() { NodeId = "C10" };
            Node c11 = new Node() { NodeId = "C11" };
            Node c12 = new Node() { NodeId = "C12" };
            Node c13 = new Node() { NodeId = "C13" };
            Node c14 = new Node() { NodeId = "C14" };
            Node c15 = new Node() { NodeId = "C15" };
            Node c16 = new Node() { NodeId = "C16" };
            Node c17 = new Node() { NodeId = "C17" };
            Node c18 = new Node() { NodeId = "C18" };
            Node c19 = new Node() { NodeId = "C19" };
            Node c20 = new Node() { NodeId = "C20" };



            c0.Neighbors = new List<Node>() { c1 };
            c1.Neighbors = new List<Node>() { c0,c2 };
            c2.Neighbors = new List<Node>() { c1};
            c3.Neighbors = new List<Node>() { c1, c4 };
            c4.Neighbors = new List<Node>() { c3, c5,c6 };
            c5.Neighbors = new List<Node>() { c4 };
            c6.Neighbors = new List<Node>() { c4 };
            c7.Neighbors = new List<Node>() { c8 };
            c8.Neighbors = new List<Node>() { c7,c9};
            c9.Neighbors = new List<Node>() { c8 };
            c10.Neighbors = new List<Node>() { c8, c11, c12 };
            c11.Neighbors = new List<Node>() { c3,c10,c15,c18 };
            c12.Neighbors = new List<Node>() { c13,c14,c10 };
            c13.Neighbors = new List<Node>() { c12 };
            c14.Neighbors = new List<Node>() { c12 };
            c15.Neighbors = new List<Node>() {c11,c17, c16 };
            c16.Neighbors = new List<Node>() {c15 };
            c17.Neighbors = new List<Node>() { c15 };
            c18.Neighbors = new List<Node>() { c19,c20,c11 };
            c19.Neighbors = new List<Node>() { c18 };
            c20.Neighbors = new List<Node>() { c18 };



            List<Node> fakeNodes = new List<Node>() {c0, c1, c2, c3 };
            return 69;
        }

    }
}
