using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DalalStreetAPI.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DS_EventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeString = table.Column<string>(nullable: false),
                    Likelihood = table.Column<double>(nullable: false),
                    EffectOnSelf = table.Column<double>(nullable: false),
                    EffectOnOthers = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DS_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DS_NewCompanyNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DS_NewCompanyNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DS_NewsEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventTypeId = table.Column<int>(nullable: false),
                    OnCompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DS_NewsEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DS_NewsEvent_DS_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "DS_EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DS_NewsEvent_DS_Company_OnCompanyId",
                        column: x => x.OnCompanyId,
                        principalTable: "DS_Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DS_NewsEvent_EventTypeId",
                table: "DS_NewsEvent",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DS_NewsEvent_OnCompanyId",
                table: "DS_NewsEvent",
                column: "OnCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DS_NewCompanyNames");

            migrationBuilder.DropTable(
                name: "DS_NewsEvent");

            migrationBuilder.DropTable(
                name: "DS_EventTypes");
        }
    }
}
