﻿// <auto-generated />
using System;
using Centre_de_formation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Centre_de_formation.Migrations
{
    [DbContext(typeof(CentreFormationContext))]
    [Migration("20240429225425_update3")]
    partial class update3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Centre_de_formation.Models.Cours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomCours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cours");
                });

            modelBuilder.Entity("Centre_de_formation.Models.Formateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salaire")
                        .HasColumnType("float");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Formateurs");
                });

            modelBuilder.Entity("Centre_de_formation.Models.Formation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CoursId")
                        .HasColumnType("int");

                    b.Property<string>("NomFormation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrixFormation")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CoursId");

                    b.ToTable("Formations");
                });

            modelBuilder.Entity("Centre_de_formation.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("EtatPayment")
                        .HasColumnType("bit");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("Centre_de_formation.Models.Salle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Depatement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumSalle")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Salles");
                });

            modelBuilder.Entity("Centre_de_formation.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FormateurId")
                        .HasColumnType("int");

                    b.Property<int?>("FormationId")
                        .HasColumnType("int");

                    b.Property<int?>("SalleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateDebut")
                        .HasColumnType("datetime2");

                    b.Property<int>("duree")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormateurId");

                    b.HasIndex("FormationId");

                    b.HasIndex("SalleId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("ParticipantSession", b =>
                {
                    b.Property<int>("ParticipantsId")
                        .HasColumnType("int");

                    b.Property<int>("SessionsId")
                        .HasColumnType("int");

                    b.HasKey("ParticipantsId", "SessionsId");

                    b.HasIndex("SessionsId");

                    b.ToTable("ParticipantSession");
                });

            modelBuilder.Entity("Centre_de_formation.Models.Formation", b =>
                {
                    b.HasOne("Centre_de_formation.Models.Cours", "Cours")
                        .WithMany("Formations")
                        .HasForeignKey("CoursId");

                    b.Navigation("Cours");
                });

            modelBuilder.Entity("Centre_de_formation.Models.Session", b =>
                {
                    b.HasOne("Centre_de_formation.Models.Formateur", "Formateur")
                        .WithMany("Sessions")
                        .HasForeignKey("FormateurId");

                    b.HasOne("Centre_de_formation.Models.Formation", "Formation")
                        .WithMany("Sessions")
                        .HasForeignKey("FormationId");

                    b.HasOne("Centre_de_formation.Models.Salle", "Salle")
                        .WithMany("Sessions")
                        .HasForeignKey("SalleId");

                    b.Navigation("Formateur");

                    b.Navigation("Formation");

                    b.Navigation("Salle");
                });

            modelBuilder.Entity("ParticipantSession", b =>
                {
                    b.HasOne("Centre_de_formation.Models.Participant", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Centre_de_formation.Models.Session", null)
                        .WithMany()
                        .HasForeignKey("SessionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Centre_de_formation.Models.Cours", b =>
                {
                    b.Navigation("Formations");
                });

            modelBuilder.Entity("Centre_de_formation.Models.Formateur", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("Centre_de_formation.Models.Formation", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("Centre_de_formation.Models.Salle", b =>
                {
                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
