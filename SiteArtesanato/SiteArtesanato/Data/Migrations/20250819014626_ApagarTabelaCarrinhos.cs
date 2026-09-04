using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteArtesanato.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApagarTabelaCarrinhos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 2. Remova a chave estrangeira da tabela que a referencia
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Carrinhos_CarrinhoId",
                table: "Produtos");
            migrationBuilder.DropTable(
                name: "Carrinhos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrinhos",
                columns: table => new
                {
                    CarrinhoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCarrinho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinhos", x => x.CarrinhoId);
                });
        }
    }
}
