using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DalalStreetAPI.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DS_Player",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Score = table.Column<long>(nullable: false),
                    Balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DS_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Transaction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DS_PlayerInventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnedStocks = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DS_PlayerInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DS_PlayerInventory_DS_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "DS_Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DS_PlayerInventory_DS_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "DS_Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DS_PlayerInventory_CompanyId",
                table: "DS_PlayerInventory",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DS_PlayerInventory_PlayerId",
                table: "DS_PlayerInventory",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DS_PlayerInventory");

            migrationBuilder.DropTable(
                name: "TransactionLogs");

            migrationBuilder.DropTable(
                name: "DS_Player");
        }
    }
}
