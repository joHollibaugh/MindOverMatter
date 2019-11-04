using Microsoft.EntityFrameworkCore;
using MindOverMatter.Models.Matter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindOverMatter.Models.DbContexts
{
    public class ChemicalDbContext : DbContext
    {
        public ChemicalDbContext(DbContextOptions<ChemicalDbContext> options) : base(options)
        {
        }

        public DbSet<Node> Nodes { get; set; }
        public DbSet<Atom> Atoms { get; set; }
        public DbSet<Chain> Chain { get; set; }
        public DbSet<Molecule> Molecules { get; set; }
        public DbSet<NodeNeighbor> NodeNeighbors { get; set; }
        public DbSet<NodeChain> NodeChains { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NodeNeighbor>().HasKey(nn => new { nn.NodeId, nn.NeighborNodeId });
            modelBuilder.Entity<NodeChain>().HasKey(nc => new { nc.ChainId, nc.NodeId });
            modelBuilder.Entity<Atom>().HasKey(x => x.AtomId);
            modelBuilder.Entity<Node>().Ignore("Neighbors");
            modelBuilder.Entity<Node>().Ignore("Scans");
            modelBuilder.Entity<Chain>().Ignore("CurrentNode");
            modelBuilder.Entity<Molecule>().Ignore("Nodes");
            modelBuilder.Entity<Atom>().HasData(
                new Atom { AtomId=1, Name="Carbon", BondPotential=4}
                );
        }

        public Atom GetAtomByName(string name)
        {
            return (Atom)Atoms.Where(x => x.Name == name);
        }
        public Node GetNodeById(string id)
        {
            return (Node)Nodes.Where(x => x.NodeId == id);
        }
        public List<string> GetNeighborIdsForNodeId(string id)
        {
            return NodeNeighbors.Where(n => n.NodeId == id).Select(n => n.NeighborNodeId).ToList();
        }
        public int GetNewChainId()
        {
            return Chain.Select(c => c.ChainId).First() + 1;
        }
    }
}
