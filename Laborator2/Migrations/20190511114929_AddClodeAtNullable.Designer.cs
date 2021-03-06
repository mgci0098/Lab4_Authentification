﻿// <auto-generated />
using System;
using Laborator2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Laborator2.Migrations
{
    [DbContext(typeof(ObiectiveDbContext))]
    [Migration("20190511114929_AddClodeAtNullable")]
    partial class AddClodeAtNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Laborator2.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Important");

                    b.Property<int?>("ObiectivId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("ObiectivId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Laborator2.Models.Obiectiv", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Added");

                    b.Property<DateTime>("Deadline");

                    b.Property<string>("Description");

                    b.Property<int>("Importanta");

                    b.Property<int>("Starea");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("closedAt");

                    b.HasKey("Id");

                    b.ToTable("Obiective");
                });

            modelBuilder.Entity("Laborator2.Models.Comment", b =>
                {
                    b.HasOne("Laborator2.Models.Obiectiv")
                        .WithMany("Comments")
                        .HasForeignKey("ObiectivId");
                });
#pragma warning restore 612, 618
        }
    }
}
