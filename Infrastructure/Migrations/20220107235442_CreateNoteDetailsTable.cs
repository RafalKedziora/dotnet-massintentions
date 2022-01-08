using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class CreateNoteDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IntentionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false),
                    IntentionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntentionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntentionDetails_Intentions_IntentionId",
                        column: x => x.IntentionId,
                        principalTable: "Intentions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IntentionDetails_IntentionId",
                table: "IntentionDetails",
                column: "IntentionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntentionDetails");
        }
    }
}
