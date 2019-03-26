﻿// <auto-generated />
using System;
using DalalStreetAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DalalStreetAPI.Migrations
{
    [DbContext(typeof(DS_Context))]
    [Migration("20190326165631_v3")]
    partial class v3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DalalStreetAPI.Models.DS_Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("stockValues");

                    b.Property<int>("totalStocks");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("DS_Company");
                });

            modelBuilder.Entity("DalalStreetAPI.Models.DS_CompanyCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("DS_CompanyCategory");
                });

            modelBuilder.Entity("DalalStreetAPI.Models.DS_EventTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("EffectOnOthers");

                    b.Property<double>("EffectOnSelf");

                    b.Property<double>("Likelihood");

                    b.Property<string>("TypeString")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("DS_EventTypes");
                });

            modelBuilder.Entity("DalalStreetAPI.Models.DS_NewCompanyNames", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("DS_NewCompanyNames");
                });

            modelBuilder.Entity("DalalStreetAPI.Models.DS_NewsEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventTypeId");

                    b.Property<int>("OnCompanyId");

                    b.HasKey("Id");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("OnCompanyId");

                    b.ToTable("DS_NewsEvent");
                });

            modelBuilder.Entity("DalalStreetAPI.Models.DS_Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Balance");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<long>("Score");

                    b.HasKey("Id");

                    b.ToTable("DS_Player");
                });

            modelBuilder.Entity("DalalStreetAPI.Models.DS_PlayerInventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<int>("OwnedStocks");

                    b.Property<int>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PlayerId");

                    b.ToTable("DS_PlayerInventory");
                });

            modelBuilder.Entity("DalalStreetAPI.Models.TransactionLogs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("Transaction");

                    b.HasKey("Id");

                    b.ToTable("TransactionLogs");
                });

            modelBuilder.Entity("DalalStreetAPI.Models.DS_Company", b =>
                {
                    b.HasOne("DalalStreetAPI.Models.DS_CompanyCategory", "DS_CompanyCategory")
                        .WithMany("DS_Companies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DalalStreetAPI.Models.DS_NewsEvent", b =>
                {
                    b.HasOne("DalalStreetAPI.Models.DS_EventTypes", "DS_EventType")
                        .WithMany("DS_Companies")
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DalalStreetAPI.Models.DS_Company", "DS_Company")
                        .WithMany("DS_Companies")
                        .HasForeignKey("OnCompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DalalStreetAPI.Models.DS_PlayerInventory", b =>
                {
                    b.HasOne("DalalStreetAPI.Models.DS_Company", "DS_Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DalalStreetAPI.Models.DS_Player", "DS_Player")
                        .WithMany("DS_PlayerInventory")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}