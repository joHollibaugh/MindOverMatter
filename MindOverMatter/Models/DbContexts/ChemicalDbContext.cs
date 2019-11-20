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
        public DbSet<Prefix> Prefixes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atom>().HasKey(x => x.AtomId);
            modelBuilder.Entity<Atom>().HasData(
                    new Atom { AtomId = 1, Name = "Carbon", BondPotential = 4 },
                    new Atom { AtomId = 2, Name = "Oxygen", BondPotential = 2 },
                    new Atom { AtomId = 3, Name = "Nitrogen", BondPotential = 3 },
                    new Atom { AtomId = 4, Name = "Fluorine", BondPotential = 1 },
                    new Atom { AtomId = 5, Name = "Chlorine", BondPotential = 1 }
                );
            modelBuilder.Entity<Prefix>().HasKey(x => x.PrefixId);
            modelBuilder.Entity<Prefix>().HasData(
                new Prefix() { PrefixId = 1, Name = "Meth", ChainLength = 1, },
                new Prefix() { PrefixId = 2, Name = "Ethane", ChainLength = 2, },
                new Prefix() { PrefixId = 3, Name = "Prop", ChainLength = 3, },
                new Prefix() { PrefixId = 4, Name = "But", ChainLength = 4, },
                new Prefix() { PrefixId = 5, Name = "Pent", ChainLength = 5, },
                new Prefix() { PrefixId = 6, Name = "Hex", ChainLength = 6, },
                new Prefix() { PrefixId = 7, Name = "Hept", ChainLength = 7, },
                new Prefix() { PrefixId = 8, Name = "Oct", ChainLength = 8, },
                new Prefix() { PrefixId = 9, Name = "Non", ChainLength = 9, },
                new Prefix() { PrefixId = 10, Name = "Dec", ChainLength = 10, },
                new Prefix() { PrefixId = 11, Name = "Undec", ChainLength = 11, },
                new Prefix() { PrefixId = 12, Name = "Dodec", ChainLength = 12, },
                new Prefix() { PrefixId = 13, Name = "Tridec", ChainLength = 13, },
                new Prefix() { PrefixId = 14, Name = "Tetradec", ChainLength = 14, },
                new Prefix() { PrefixId = 15, Name = "Pentadec", ChainLength = 15, },
                new Prefix() { PrefixId = 16, Name = "Hexadec", ChainLength = 16, },
                new Prefix() { PrefixId = 17, Name = "Heptadec", ChainLength = 17, },
                new Prefix() { PrefixId = 18, Name = "Octadec", ChainLength = 18, },
                new Prefix() { PrefixId = 19, Name = "Nonadec", ChainLength = 19, },
                new Prefix() { PrefixId = 20, Name = "Icos", ChainLength = 20, }
                );
        }

        public Prefix GetPrefixByLength(int chainLength)
        {
            return (Prefix)Prefixes.Where(x => x.ChainLength == chainLength);
        }

        public Atom GetAtomByName(string name)
        {
            return (Atom)Atoms.Where(x => x.Name == name);
        }
    }
}
