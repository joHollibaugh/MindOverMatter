﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MindOverMatter.Models.DbContexts;

namespace MindOverMatter.Migrations
{
    [DbContext(typeof(ChemicalDbContext))]
    partial class ChemicalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MindOverMatter.Models.Matter.Atom", b =>
                {
                    b.Property<int>("AtomId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BondPotential");

                    b.Property<string>("Name");

                    b.HasKey("AtomId");

                    b.ToTable("Atoms");
                });

            modelBuilder.Entity("MindOverMatter.Models.Matter.Molecule", b =>
                {
                    b.Property<int>("MoleculeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MoleculeJson");

                    b.Property<string>("Name");

                    b.HasKey("MoleculeId");

                    b.ToTable("Molecules");
                });

            modelBuilder.Entity("MindOverMatter.Models.Matter.Prefix", b =>
                {
                    b.Property<int>("PrefixId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChainLength");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("PrefixId");

                    b.ToTable("Prefixes");

                    b.HasData(
                        new { PrefixId = 1, ChainLength = 1, Name = "Meth" },
                        new { PrefixId = 2, ChainLength = 2, Name = "Ethane" },
                        new { PrefixId = 3, ChainLength = 3, Name = "Prop" },
                        new { PrefixId = 4, ChainLength = 4, Name = "But" },
                        new { PrefixId = 5, ChainLength = 5, Name = "Pent" },
                        new { PrefixId = 6, ChainLength = 6, Name = "Hex" },
                        new { PrefixId = 7, ChainLength = 7, Name = "Hept" },
                        new { PrefixId = 8, ChainLength = 8, Name = "Oct" },
                        new { PrefixId = 9, ChainLength = 9, Name = "Non" },
                        new { PrefixId = 10, ChainLength = 10, Name = "Dec" },
                        new { PrefixId = 11, ChainLength = 11, Name = "Undec" },
                        new { PrefixId = 12, ChainLength = 12, Name = "Dodec" },
                        new { PrefixId = 13, ChainLength = 13, Name = "Tridec" },
                        new { PrefixId = 14, ChainLength = 14, Name = "Tetradec" },
                        new { PrefixId = 15, ChainLength = 15, Name = "Pentadec" },
                        new { PrefixId = 16, ChainLength = 16, Name = "Hexadec" },
                        new { PrefixId = 17, ChainLength = 17, Name = "Heptadec" },
                        new { PrefixId = 18, ChainLength = 18, Name = "Octadec" },
                        new { PrefixId = 19, ChainLength = 19, Name = "Nonadec" },
                        new { PrefixId = 20, ChainLength = 20, Name = "Icos" }
                    );
                });

            modelBuilder.Entity("MindOverMatter.Models.User.Rating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MoleculeId");

                    b.Property<int>("Score");

                    b.Property<string>("UserId");

                    b.HasKey("RatingId");

                    b.ToTable("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
