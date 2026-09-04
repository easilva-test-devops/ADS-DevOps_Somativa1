using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteArtesanato.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaCarrinhos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CarrinhoId",
                table: "Produtos",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carrinhos",
                columns: table => new
                {
                    CarrinhoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCarrinho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinhos", x => x.CarrinhoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CarrinhoId",
                table: "Produtos",
                column: "CarrinhoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Carrinhos_CarrinhoId",
                table: "Produtos",
                column: "CarrinhoId",
                principalTable: "Carrinhos",
                principalColumn: "CarrinhoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Carrinhos_CarrinhoId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Carrinhos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CarrinhoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CarrinhoId",
                table: "Produtos");
        }
    }
}
