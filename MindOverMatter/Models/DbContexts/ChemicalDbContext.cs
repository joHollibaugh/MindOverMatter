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

        public DbSet<Atom> Atoms { get; set; }
        public DbSet<Molecule> Molecules { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atom>().HasKey(x => x.AtomId);
            modelBuilder.Entity<Atom>().HasData(
                    new Atom { AtomId=1, Name="Carbon", BondPotential=4},
                    new Atom { AtomId=2, Name="Oxygen", BondPotential=2},
                    new Atom { AtomId=3, Name="Nitrogen", BondPotential=3}
                );
        }

        public Atom GetAtomByName(string name)
        {
            return (Atom)Atoms.Where(x => x.Name == name);
        }
    }
}
