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

        DbSet<Node> Node { get; set; }

        DbSet<Atom> Atoms { get; set; }

        DbSet<Chain> Chain { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atom>().HasKey(x => x.AtomId);
            modelBuilder.Entity<Atom>().HasData(
                new Atom { AtomId=1, Name="Carbon", BondPotential=4}
                );
        }
    }
}
