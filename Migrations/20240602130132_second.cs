using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PostgreHotel.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
    name: "rezervacije",
    columns: table => new
    {
        rezervacijaid = table.Column<int>(type: "integer", nullable: false)
            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
        gostid = table.Column<int>(type: "integer", nullable: false),
        sobaid = table.Column<int>(type: "integer", nullable: false),
        datumdolaska = table.Column<DateTime>(type: "timestamp with time zone", nullable: true), // Updated to allow nullable
        datumodlaska = table.Column<DateTime>(type: "timestamp with time zone", nullable: true) // Updated to allow nullable
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_rezervacije", x => x.rezervacijaid);
        table.ForeignKey(
            name: "FK_rezervacije_gosti_gostid",
            column: x => x.gostid,
            principalTable: "gosti",
            principalColumn: "gostid",
            onDelete: ReferentialAction.Cascade);
        table.ForeignKey(
            name: "FK_rezervacije_sobe_sobaid",
            column: x => x.sobaid,
            principalTable: "sobe",
            principalColumn: "sobaid",
            onDelete: ReferentialAction.Cascade);
    });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rezervacije");
        }
    }
}
