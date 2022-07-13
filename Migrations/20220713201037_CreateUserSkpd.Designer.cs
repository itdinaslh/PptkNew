﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PptkNew.Data;

#nullable disable

namespace PptkNew.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220713201037_CreateUserSkpd")]
    partial class CreateUserSkpd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PptkNew.Entities.JenisPengadaan", b =>
                {
                    b.Property<int>("JenisPengadaanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("JenisPengadaanId"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("NamaJenis")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("JenisPengadaanId");

                    b.ToTable("JenisPengadaan");
                });

            modelBuilder.Entity("PptkNew.Entities.Kegiatan", b =>
                {
                    b.Property<int>("KegiatanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("KegiatanId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("KodeKegiatan")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("NamaKegiatan")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("KegiatanId");

                    b.HasIndex("KodeKegiatan")
                        .IsUnique();

                    b.ToTable("Kegiatan");
                });

            modelBuilder.Entity("PptkNew.Entities.Prog", b =>
                {
                    b.Property<int>("ProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProgramId"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("KodeProgram")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("NamaProgram")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ProgramId");

                    b.HasIndex("KodeProgram")
                        .IsUnique();

                    b.ToTable("Program");
                });

            modelBuilder.Entity("PptkNew.Entities.Rekening", b =>
                {
                    b.Property<int>("RekeningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RekeningId"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("KodeRekening")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("NamaRekening")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("RekeningId");

                    b.HasIndex("KodeRekening")
                        .IsUnique();

                    b.ToTable("Rekening");
                });

            modelBuilder.Entity("PptkNew.Entities.Skpd", b =>
                {
                    b.Property<int>("SkpdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SkpdId"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("NamaPimpinan")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<string>("SkpdCode")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("SkpdName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("SkpdId");

                    b.HasIndex("SkpdCode")
                        .IsUnique();

                    b.ToTable("Skpd");
                });

            modelBuilder.Entity("PptkNew.Entities.SubKegiatan", b =>
                {
                    b.Property<int>("SubKegiatanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubKegiatanId"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("KegiatanId")
                        .HasColumnType("integer");

                    b.Property<string>("KodeSubKegiatan")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("NamaSubKegiatan")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("SubKegiatanId");

                    b.HasIndex("KegiatanId");

                    b.HasIndex("KodeSubKegiatan")
                        .IsUnique();

                    b.ToTable("SubKegiatan");
                });

            modelBuilder.Entity("PptkNew.Entities.UserSkpd", b =>
                {
                    b.Property<Guid>("UserSkpdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("SkpdId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("UserSkpdId");

                    b.HasIndex("SkpdId");

                    b.ToTable("UserSkpd");
                });

            modelBuilder.Entity("PptkNew.Entities.SubKegiatan", b =>
                {
                    b.HasOne("PptkNew.Entities.Kegiatan", "Kegiatan")
                        .WithMany("SubKegiatans")
                        .HasForeignKey("KegiatanId");

                    b.Navigation("Kegiatan");
                });

            modelBuilder.Entity("PptkNew.Entities.UserSkpd", b =>
                {
                    b.HasOne("PptkNew.Entities.Skpd", "Skpd")
                        .WithMany("UserSkpds")
                        .HasForeignKey("SkpdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skpd");
                });

            modelBuilder.Entity("PptkNew.Entities.Kegiatan", b =>
                {
                    b.Navigation("SubKegiatans");
                });

            modelBuilder.Entity("PptkNew.Entities.Skpd", b =>
                {
                    b.Navigation("UserSkpds");
                });
#pragma warning restore 612, 618
        }
    }
}
