﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzariaback.Migrations
{
    /// <inheritdoc />
    public partial class ProdutoFracionado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tipos_Produtos_ProdutoId",
                table: "Tipos");

            migrationBuilder.DropIndex(
                name: "IX_Tipos_ProdutoId",
                table: "Tipos");

            migrationBuilder.AddColumn<bool>(
                name: "Fracionado",
                table: "Produtos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fracionado",
                table: "Produtos");

            migrationBuilder.CreateIndex(
                name: "IX_Tipos_ProdutoId",
                table: "Tipos",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tipos_Produtos_ProdutoId",
                table: "Tipos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
