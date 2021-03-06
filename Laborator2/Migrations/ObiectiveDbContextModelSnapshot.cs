﻿// <auto-generated />
using System;
using Laborator2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Laborator2.Migrations
{
    [DbContext(typeof(ObiectiveDbContext))]
    partial class ObiectiveDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab3.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Laborator2.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Important");

                    b.Property<int>("ObiectivId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("ObiectivId");

                    b.ToTable("Comments");
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
                        .HasForeignKey("ObiectivId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
