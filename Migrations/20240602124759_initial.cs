using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PostgreHotel.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gosti",
                columns: table => new
                {
                    gostid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ime = table.Column<string>(type: "text", nullable: false),
                    prezime = table.Column<string>(type: "text", nullable: false),
                    adresa = table.Column<string>(type: "text", nullable: false),
                    telefon = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gosti", x => x.gostid);
                });

            migrationBuilder.CreateTable(
                name: "hotel",
                columns: table => new
                {
                    hotelid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    imehotela = table.Column<string>(type: "text", nullable: false),
                    adresa = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotel", x => x.hotelid);
                });

            migrationBuilder.CreateTable(
                name: "rezervacije",
                columns: table => new
                {
                    rezervacijaid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gostid = table.Column<int>(type: "integer", nullable: false),
                    sobaid = table.Column<int>(type: "integer", nullable: false),
                    datumdolaska = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    datumodlaska = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rezervacije", x => x.rezervacijaid);
                });

            migrationBuilder.CreateTable(
                name: "sobe",
                columns: table => new
                {
                    sobaid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipsobe = table.Column<string>(type: "text", nullable: false),
                    brojkreveta = table.Column<int>(type: "integer", nullable: false),
                    cijena = table.Column<int>(type: "integer", nullable: false),
                    hotelid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sobe", x => x.sobaid);
                });

            migrationBuilder.CreateTable(
                name: "usluga",
                columns: table => new
                {
                    uslugaid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    naziv = table.Column<string>(type: "text", nullable: false),
                    cijena = table.Column<int>(type: "integer", nullable: false),
                    hotelid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usluga", x => x.uslugaid);
                });

            migrationBuilder.CreateTable(
                name: "zaposlenici",
                columns: table => new
                {
                    zaposlenikid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ime = table.Column<string>(type: "text", nullable: false),
                    prezime = table.Column<string>(type: "text", nullable: false),
                    poziija = table.Column<string>(type: "text", nullable: false),
                    placa = table.Column<int>(type: "integer", nullable: false),
                    hotelid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zaposlenici", x => x.zaposlenikid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gosti");

            migrationBuilder.DropTable(
                name: "hotel");

            migrationBuilder.DropTable(
                name: "rezervacije");

            migrationBuilder.DropTable(
                name: "sobe");

            migrationBuilder.DropTable(
                name: "usluga");

            migrationBuilder.DropTable(
                name: "zaposlenici");
        }
    }
}
