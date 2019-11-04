﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MindOverMatter.Models.DbContexts;

namespace MindOverMatter.Migrations
{
    [DbContext(typeof(ChemicalDbContext))]
    [Migration("20191102012504_FixNodeId")]
    partial class FixNodeId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
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

                    b.HasData(
                        new { AtomId = 1, BondPotential = 4, Name = "Carbon" }
                    );
                });

            modelBuilder.Entity("MindOverMatter.Models.Matter.Chain", b =>
                {
                    b.Property<int>("ChainId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MoleculeId");

                    b.Property<bool>("Parent");

                    b.HasKey("ChainId");

                    b.HasIndex("MoleculeId");

                    b.ToTable("Chain");
                });

            modelBuilder.Entity("MindOverMatter.Models.Matter.Molecule", b =>
                {
                    b.Property<int>("MoleculeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("MoleculeId");

                    b.ToTable("Molecules");
                });

            modelBuilder.Entity("MindOverMatter.Models.Matter.Node", b =>
                {
                    b.Property<string>("NodeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AtomId");

                    b.Property<int?>("ChainId");

                    b.Property<bool>("Divergent");

                    b.Property<int?>("MoleculeId");

                    b.Property<string>("NodeId1");

                    b.Property<int>("Scans");

                    b.HasKey("NodeId");

                    b.HasIndex("AtomId");

                    b.HasIndex("ChainId");

                    b.HasIndex("MoleculeId");

                    b.HasIndex("NodeId1");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("MindOverMatter.Models.Matter.Chain", b =>
                {
                    b.HasOne("MindOverMatter.Models.Matter.Molecule")
                        .WithMany("Chains")
                        .HasForeignKey("MoleculeId");
                });

            modelBuilder.Entity("MindOverMatter.Models.Matter.Node", b =>
                {
                    b.HasOne("MindOverMatter.Models.Matter.Atom", "Atom")
                        .WithMany()
                        .HasForeignKey("AtomId");

                    b.HasOne("MindOverMatter.Models.Matter.Chain")
                        .WithMany("ChainNodes")
                        .HasForeignKey("ChainId");

                    b.HasOne("MindOverMatter.Models.Matter.Molecule")
                        .WithMany("Nodes")
                        .HasForeignKey("MoleculeId");

                    b.HasOne("MindOverMatter.Models.Matter.Node")
                        .WithMany("Neighbors")
                        .HasForeignKey("NodeId1");
                });
#pragma warning restore 612, 618
        }
    }
}
