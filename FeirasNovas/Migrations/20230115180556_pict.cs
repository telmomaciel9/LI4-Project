using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeirasNovas.Migrations
{
    /// <inheritdoc />
    public partial class pict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Feiras_FeirasidFeira",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FeirasidFeira",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "VenderUsername",
                table: "Feiras");

            migrationBuilder.DropColumn(
                name: "FeirasidFeira",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "Product");

            migrationBuilder.AddColumn<string>(
                name: "CategoriaPic",
                table: "Feiras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "idProduto");

            migrationBuilder.CreateTable(
                name: "Feira_Product",
                columns: table => new
                {
                    idProduto = table.Column<int>(type: "int", nullable: false),
                    idFeira = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feira_Product", x => new { x.idFeira, x.idProduto });
                    table.ForeignKey(
                        name: "FK_Feira_Product_Feiras_idFeira",
                        column: x => x.idFeira,
                        principalTable: "Feiras",
                        principalColumn: "idFeira",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feira_Product_Product_idProduto",
                        column: x => x.idProduto,
                        principalTable: "Product",
                        principalColumn: "idProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendedorL",
                columns: table => new
                {
                    VendedorIdL = table.Column<int>(type: "int", nullable: false),
                    VendedorNameL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendedorL", x => x.VendedorIdL);
                    table.ForeignKey(
                        name: "FK_VendedorL_Feiras_VendedorIdL",
                        column: x => x.VendedorIdL,
                        principalTable: "Feiras",
                        principalColumn: "idFeira",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feira_Product_idProduto",
                table: "Feira_Product",
                column: "idProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feira_Product");

            migrationBuilder.DropTable(
                name: "VendedorL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoriaPic",
                table: "Feiras");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Produto");

            migrationBuilder.AddColumn<string>(
                name: "VenderUsername",
                table: "Feiras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FeirasidFeira",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "idProduto");

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    idVenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Fatura = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.idVenda);
                    table.ForeignKey(
                        name: "FK_Venda_Produto_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Produto",
                        principalColumn: "idProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FeirasidFeira",
                table: "AspNetUsers",
                column: "FeirasidFeira");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ProductId",
                table: "Venda",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Feiras_FeirasidFeira",
                table: "AspNetUsers",
                column: "FeirasidFeira",
                principalTable: "Feiras",
                principalColumn: "idFeira",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
