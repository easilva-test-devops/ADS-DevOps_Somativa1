using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteArtesanato.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaItensCarrinho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItensCarrinho",
                columns: table => new
                {
                    ItemCarrinhoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrinhoId = table.Column<long>(type: "bigint", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensCarrinho", x => x.ItemCarrinhoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensCarrinho");
        }
    }
}
