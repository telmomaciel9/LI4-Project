using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeirasNovas.Migrations
{
    /// <inheritdoc />
    public partial class picr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriaPic",
                table: "Feiras");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoriaPic",
                table: "Feiras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
