﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dbcontext;

#nullable disable

namespace dbcontext.Migrations
{
    [DbContext(typeof(OurContext))]
    [Migration("20230323125556_AddedSkill")]
    partial class AddedSkill
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("dbcontext.Classes.Medewerker", b =>
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

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<int?>("MedewerkerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

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

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Uitstroomrichting")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MedewerkerId");

                    b.HasIndex("TalentManagerId");

                    b.ToTable("Medewerker");
                });

            modelBuilder.Entity("dbcontext.Classes.Opdrachtgever", b =>
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

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.ToTable("Opdrachtgever");
                });

            modelBuilder.Entity("dbcontext.Classes.Plaatsing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MedewerkerId")
                        .HasColumnType("int");

                    b.Property<int>("SollicitatieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Started")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("MedewerkerId");

                    b.HasIndex("SollicitatieId");

                    b.ToTable("Plaatsing");
                });

            modelBuilder.Entity("dbcontext.Classes.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MedewerkerId")
                        .HasColumnType("int");

                    b.Property<int?>("SkillId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.HasIndex("MedewerkerId");

                    b.HasIndex("SkillId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("dbcontext.Classes.Sollicitatie", b =>
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
                        .HasColumnType("longtext");

                    b.Property<int>("VacatureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedewerkerId");

                    b.HasIndex("VacatureId");

                    b.ToTable("Sollicitatie");
                });

            modelBuilder.Entity("dbcontext.Classes.TalentManager", b =>
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

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.ToTable("TalentManager");
                });

            modelBuilder.Entity("dbcontext.Classes.Vacature", b =>
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
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("OpdrachtgeverId");

                    b.ToTable("Vacature");
                });

            modelBuilder.Entity("dbcontext.Classes.Medewerker", b =>
                {
                    b.HasOne("dbcontext.Classes.Medewerker", null)
                        .WithMany("Medewerkers")
                        .HasForeignKey("MedewerkerId");

                    b.HasOne("dbcontext.Classes.TalentManager", "TalentManager")
                        .WithMany("Medewerkers")
                        .HasForeignKey("TalentManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TalentManager");
                });

            modelBuilder.Entity("dbcontext.Classes.Plaatsing", b =>
                {
                    b.HasOne("dbcontext.Classes.Medewerker", "Medewerker")
                        .WithMany()
                        .HasForeignKey("MedewerkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dbcontext.Classes.Sollicitatie", "Sollicitatie")
                        .WithMany()
                        .HasForeignKey("SollicitatieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medewerker");

                    b.Navigation("Sollicitatie");
                });

            modelBuilder.Entity("dbcontext.Classes.Skill", b =>
                {
                    b.HasOne("dbcontext.Classes.Medewerker", "Medewerker")
                        .WithMany("Skill")
                        .HasForeignKey("MedewerkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dbcontext.Classes.Skill", null)
                        .WithMany("Skills")
                        .HasForeignKey("SkillId");

                    b.Navigation("Medewerker");
                });

            modelBuilder.Entity("dbcontext.Classes.Sollicitatie", b =>
                {
                    b.HasOne("dbcontext.Classes.Medewerker", "Medewerker")
                        .WithMany()
                        .HasForeignKey("MedewerkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dbcontext.Classes.Vacature", "Vacature")
                        .WithMany()
                        .HasForeignKey("VacatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medewerker");

                    b.Navigation("Vacature");
                });

            modelBuilder.Entity("dbcontext.Classes.Vacature", b =>
                {
                    b.HasOne("dbcontext.Classes.Opdrachtgever", "Opdrachtgever")
                        .WithMany()
                        .HasForeignKey("OpdrachtgeverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Opdrachtgever");
                });

            modelBuilder.Entity("dbcontext.Classes.Medewerker", b =>
                {
                    b.Navigation("Medewerkers");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("dbcontext.Classes.Skill", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("dbcontext.Classes.TalentManager", b =>
                {
                    b.Navigation("Medewerkers");
                });
#pragma warning restore 612, 618
        }
    }
}
