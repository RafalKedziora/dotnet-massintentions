using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddCategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MassDate",
                table: "Intentions",
                type: "datetime2(0)",
                precision: 0,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Intentions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Intentions_CategoryId",
                table: "Intentions",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Intentions_Categories_CategoryId",
                table: "Intentions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intentions_Categories_CategoryId",
                table: "Intentions");

            migrationBuilder.DropIndex(
                name: "IX_Intentions_CategoryId",
                table: "Intentions");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Intentions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MassDate",
                table: "Intentions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldPrecision: 0);
        }
    }
}
