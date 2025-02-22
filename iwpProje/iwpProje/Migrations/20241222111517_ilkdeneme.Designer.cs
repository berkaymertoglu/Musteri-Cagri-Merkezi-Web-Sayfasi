﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using iwpProje.Data;

#nullable disable

namespace iwpProje.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241222111517_ilkdeneme")]
    partial class ilkdeneme
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("iwpProje.Data.oturumacmiskullanici", b =>
                {
                    b.Property<int>("oturumid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("oturumid"));

                    b.Property<DateTime>("oturumbaslangiczamani")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("personelid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("oturumid");

                    b.ToTable("oturumacmiskullanicilar");
                });

            modelBuilder.Entity("iwpProje.Models.cagrikayitlari1hafta", b =>
                {
                    b.Property<TimeSpan>("baslamasaati")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("bitissaati")
                        .HasColumnType("interval");

                    b.Property<int>("cagriid")
                        .HasColumnType("integer");

                    b.Property<string>("durum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("gorusmetarihi")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("konu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("musteriadi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable((string)null);

                    b.ToView("CagriListesi1Hafta", (string)null);
                });

            modelBuilder.Entity("iwpProje.Models.itirazkayitlari", b =>
                {
                    b.Property<int>("itirazid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("itirazid"));

                    b.Property<string>("asistanid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("asistaninaciklamasi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("durumid")
                        .HasColumnType("integer");

                    b.Property<string>("ilgilitakimlideri")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("itirazakonuay")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("takimliderinincevabi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("tarih")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("itirazid");

                    b.ToTable("itirazkayitlari");
                });

            modelBuilder.Entity("iwpProje.Models.login", b =>
                {
                    b.Property<string>("eposta")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("personeladi")
                        .HasColumnType("text");

                    b.Property<string>("personelid")
                        .HasColumnType("text");

                    b.Property<string>("personelsoyadi")
                        .HasColumnType("text");

                    b.Property<string>("sifre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("sistemkullanicilari");
                });

            modelBuilder.Entity("iwpProje.Models.mustericagrikayitlari", b =>
                {
                    b.Property<int>("cagriid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("cagriid"));

                    b.Property<string>("asistansicil")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("baslamasaati")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("bitissaati")
                        .HasColumnType("interval");

                    b.Property<int>("cagrisuresi")
                        .HasColumnType("integer");

                    b.Property<int>("gorusmedurumid")
                        .HasColumnType("integer");

                    b.Property<int>("gorusmekonusuid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("gorusmetarihi")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("musteriadi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("musteriid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ogunkucagrisayisi")
                        .HasColumnType("integer");

                    b.Property<double>("urettigiprim")
                        .HasColumnType("double precision");

                    b.HasKey("cagriid");

                    b.ToTable("mustericagrikayitlari");
                });

            modelBuilder.Entity("iwpProje.Models.musteriler", b =>
                {
                    b.Property<string>("musteriid")
                        .HasColumnType("text");

                    b.Property<string>("musteriadi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("musteriadres")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("musteriemail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("musteritel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("musteriid");

                    b.ToTable("musteriler");
                });
#pragma warning restore 612, 618
        }
    }
}
