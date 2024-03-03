using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_Voiture.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRepair : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Modeles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Marques",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reparations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CoutReparation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VoitureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reparations_Voiture_VoitureId",
                        column: x => x.VoitureId,
                        principalTable: "Voiture",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reparations_VoitureId",
                table: "Reparations",
                column: "VoitureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reparations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Modeles");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Marques");

            migrationBuilder.RenameColumn(
                name: "Disponible",
                table: "Voiture",
                newName: "Disponibile");
        }
    }
}
