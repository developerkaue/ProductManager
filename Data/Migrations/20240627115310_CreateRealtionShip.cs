using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagementSystem1.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateRealtionShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Fornecedores_FornecedorId",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Fornecedores_FornecedorId",
                table: "Products",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Fornecedores_FornecedorId",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Fornecedores_FornecedorId",
                table: "Products",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
