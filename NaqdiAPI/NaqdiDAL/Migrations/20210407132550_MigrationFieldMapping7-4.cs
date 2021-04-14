using Microsoft.EntityFrameworkCore.Migrations;

namespace NaqdiDAL.Migrations
{
    public partial class MigrationFieldMapping74 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Service_Providers",
                columns: table => new
                {
                    Serv_ProvID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceVerb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CasesCpsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_Providers", x => x.Serv_ProvID);
                    table.ForeignKey(
                        name: "FK_Service_Providers_CasesCPS_CasesCpsID",
                        column: x => x.CasesCpsID,
                        principalTable: "CasesCPS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fields_Mappings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AndroidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRequest = table.Column<bool>(type: "bit", nullable: false),
                    ProviderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service_ProviderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields_Mappings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fields_Mappings_Service_Providers_Service_ProviderID",
                        column: x => x.Service_ProviderID,
                        principalTable: "Service_Providers",
                        principalColumn: "Serv_ProvID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fields_Mappings_Service_ProviderID",
                table: "Fields_Mappings",
                column: "Service_ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Providers_CasesCpsID",
                table: "Service_Providers",
                column: "CasesCpsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fields_Mappings");

            migrationBuilder.DropTable(
                name: "Service_Providers");
        }
    }
}
