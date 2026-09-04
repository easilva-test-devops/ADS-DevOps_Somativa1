using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteArtesanato.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteradaTabelaCarrinho_mudadoCampoProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Carrinhos_CarrinhoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CarrinhoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CarrinhoId",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Carrinhos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Carrinhos");

            migrationBuilder.AddColumn<long>(
                name: "CarrinhoId",
                table: "Produtos",
                type: "bigint",
                nullable: true);

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
    }
}
