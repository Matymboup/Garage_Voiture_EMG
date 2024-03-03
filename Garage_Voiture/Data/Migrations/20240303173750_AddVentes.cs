using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_Voiture.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddVentes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Voiture",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Voiture");
        }
    }
}
