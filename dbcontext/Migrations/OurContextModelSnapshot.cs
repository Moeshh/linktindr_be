﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dbcontext;

#nullable disable

namespace dbcontext.Migrations
{
    [DbContext(typeof(OurContext))]
    partial class OurContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("dbcontext.Medewerker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("Datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("VARCHAR(6)");

                    b.Property<string>("ProfileText")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Radius")
                        .HasMaxLength(3)
                        .HasColumnType("INT(3)");

                    b.Property<int>("TalentManagerId")
                        .HasColumnType("int");

                    b.Property<int>("Telephone")
                        .HasMaxLength(10)
                        .HasColumnType("INT(10)");

                    b.Property<string>("Uitstroomrichting")
                        .IsRequired()
                        .HasColumnType("ENUM('DevOps', 'Informatie Analist', 'C# Programmeur', 'Java Programmeur')");

                    b.HasKey("Id");

                    b.HasIndex("TalentManagerId");

                    b.ToTable("medewerker");
                });

            modelBuilder.Entity("dbcontext.Opdrachtgever", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<int>("Telephone")
                        .HasMaxLength(10)
                        .HasColumnType("INT(10)");

                    b.HasKey("Id");

                    b.ToTable("opdrachtgever");
                });

            modelBuilder.Entity("dbcontext.Plaatsing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("SollicitatieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SollicitatieId");

                    b.ToTable("plaatsing");
                });

            modelBuilder.Entity("dbcontext.Sollicitatie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MedewerkerId")
                        .HasColumnType("int");

                    b.Property<bool>("Medewerker_akkoord")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<bool>("Opdrachtgever_akkoord")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("ENUM('Match', 'Sollicitatie', 'Bedenktijd', 'Accept', 'Decline')")
                        .HasDefaultValue("Match");

                    b.Property<int>("VacatureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedewerkerId");

                    b.HasIndex("VacatureId");

                    b.ToTable("sollicitatie");
                });

            modelBuilder.Entity("dbcontext.TalentManager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<int>("Telephone")
                        .HasMaxLength(10)
                        .HasColumnType("INT(10)");

                    b.HasKey("Id");

                    b.ToTable("talentmanager");
                });

            modelBuilder.Entity("dbcontext.Vacatures", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Enddate")
                        .HasColumnType("Datetime(6)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<int>("OpdrachtgeverId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Startdate")
                        .HasColumnType("Datetime(6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Uitstroomrichting")
                        .IsRequired()
                        .HasColumnType("ENUM('DevOps', 'Informatie Analist', 'C# Programmeur', 'Java Programmeur')");

                    b.HasKey("Id");

                    b.HasIndex("OpdrachtgeverId");

                    b.ToTable("vacatures");
                });

            modelBuilder.Entity("dbcontext.Medewerker", b =>
                {
                    b.HasOne("dbcontext.TalentManager", "TalentManager")
                        .WithMany("Medewerkers")
                        .HasForeignKey("TalentManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TalentManager");
                });

            modelBuilder.Entity("dbcontext.Plaatsing", b =>
                {
                    b.HasOne("dbcontext.Sollicitatie", "Sollicitatie")
                        .WithMany()
                        .HasForeignKey("SollicitatieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sollicitatie");
                });

            modelBuilder.Entity("dbcontext.Sollicitatie", b =>
                {
                    b.HasOne("dbcontext.Medewerker", "Medewerker")
                        .WithMany()
                        .HasForeignKey("MedewerkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dbcontext.Vacatures", "Vacature")
                        .WithMany()
                        .HasForeignKey("VacatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medewerker");

                    b.Navigation("Vacature");
                });

            modelBuilder.Entity("dbcontext.Vacatures", b =>
                {
                    b.HasOne("dbcontext.Opdrachtgever", "Opdrachtgever")
                        .WithMany("Vacatures")
                        .HasForeignKey("OpdrachtgeverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Opdrachtgever");
                });

            modelBuilder.Entity("dbcontext.Opdrachtgever", b =>
                {
                    b.Navigation("Vacatures");
                });

            modelBuilder.Entity("dbcontext.TalentManager", b =>
                {
                    b.Navigation("Medewerkers");
                });
#pragma warning restore 612, 618
        }
    }
}
