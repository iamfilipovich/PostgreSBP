﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PostgreHotel.Data;

#nullable disable

namespace PostgreHotel.Migrations
{
    [DbContext(typeof(PostgreHotelContext))]
    [Migration("20240602130132_second")]
    partial class second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PostgreHotel.Data.gosti", b =>
                {
                    b.Property<int>("gostid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("gostid"));

                    b.Property<string>("adresa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("telefon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("gostid");

                    b.ToTable("gosti");
                });

            modelBuilder.Entity("PostgreHotel.Data.hotel", b =>
                {
                    b.Property<int>("hotelid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("hotelid"));

                    b.Property<string>("adresa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("imehotela")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("hotelid");

                    b.ToTable("hotel");
                });

            modelBuilder.Entity("PostgreHotel.Data.rezervacije", b =>
                {
                    b.Property<int>("rezervacijaid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("rezervacijaid"));

                    b.Property<DateTime>("datumdolaska")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("datumodlaska")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("gostid")
                        .HasColumnType("integer");

                    b.Property<int>("sobaid")
                        .HasColumnType("integer");

                    b.HasKey("rezervacijaid");

                    b.ToTable("rezervacije");
                });

            modelBuilder.Entity("PostgreHotel.Data.sobe", b =>
                {
                    b.Property<int>("sobaid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("sobaid"));

                    b.Property<int>("brojkreveta")
                        .HasColumnType("integer");

                    b.Property<int>("cijena")
                        .HasColumnType("integer");

                    b.Property<int>("hotelid")
                        .HasColumnType("integer");

                    b.Property<string>("tipsobe")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("sobaid");

                    b.ToTable("sobe");
                });

            modelBuilder.Entity("PostgreHotel.Data.usluga", b =>
                {
                    b.Property<int>("uslugaid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("uslugaid"));

                    b.Property<int>("cijena")
                        .HasColumnType("integer");

                    b.Property<int>("hotelid")
                        .HasColumnType("integer");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("uslugaid");

                    b.ToTable("usluga");
                });

            modelBuilder.Entity("PostgreHotel.Data.zaposlenici", b =>
                {
                    b.Property<int>("zaposlenikid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("zaposlenikid"));

                    b.Property<int>("hotelid")
                        .HasColumnType("integer");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("placa")
                        .HasColumnType("integer");

                    b.Property<string>("poziija")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("zaposlenikid");

                    b.ToTable("zaposlenici");
                });
#pragma warning restore 612, 618
        }
    }
}
