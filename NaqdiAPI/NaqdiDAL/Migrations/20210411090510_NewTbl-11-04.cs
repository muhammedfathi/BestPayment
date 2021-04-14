using Microsoft.EntityFrameworkCore.Migrations;

namespace NaqdiDAL.Migrations
{
    public partial class NewTbl1104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProvidersDeposit_Banks_BankID",
                table: "ProvidersDeposit");

            migrationBuilder.DropForeignKey(
                name: "FK_ProvidersDeposit_Provider_ProviderID",
                table: "ProvidersDeposit");

            migrationBuilder.DropForeignKey(
                name: "FK_ProvidersDeposit_TUser_UserID",
                table: "ProvidersDeposit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProvidersDeposit",
                table: "ProvidersDeposit");

            migrationBuilder.RenameTable(
                name: "ProvidersDeposit",
                newName: "ProvidersDeposits");

            migrationBuilder.RenameIndex(
                name: "IX_ProvidersDeposit_UserID",
                table: "ProvidersDeposits",
                newName: "IX_ProvidersDeposits_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_ProvidersDeposit_ProviderID",
                table: "ProvidersDeposits",
                newName: "IX_ProvidersDeposits_ProviderID");

            migrationBuilder.RenameIndex(
                name: "IX_ProvidersDeposit_BankID",
                table: "ProvidersDeposits",
                newName: "IX_ProvidersDeposits_BankID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProvidersDeposits",
                table: "ProvidersDeposits",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "ChargeSims",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NetworkID = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Fees = table.Column<int>(type: "int", nullable: false),
                    Commision = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargeSims", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProvidersDeposits_Banks_BankID",
                table: "ProvidersDeposits",
                column: "BankID",
                principalTable: "Banks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProvidersDeposits_Provider_ProviderID",
                table: "ProvidersDeposits",
                column: "ProviderID",
                principalTable: "Provider",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProvidersDeposits_TUser_UserID",
                table: "ProvidersDeposits",
                column: "UserID",
                principalTable: "TUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProvidersDeposits_Banks_BankID",
                table: "ProvidersDeposits");

            migrationBuilder.DropForeignKey(
                name: "FK_ProvidersDeposits_Provider_ProviderID",
                table: "ProvidersDeposits");

            migrationBuilder.DropForeignKey(
                name: "FK_ProvidersDeposits_TUser_UserID",
                table: "ProvidersDeposits");

            migrationBuilder.DropTable(
                name: "ChargeSims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProvidersDeposits",
                table: "ProvidersDeposits");

            migrationBuilder.RenameTable(
                name: "ProvidersDeposits",
                newName: "ProvidersDeposit");

            migrationBuilder.RenameIndex(
                name: "IX_ProvidersDeposits_UserID",
                table: "ProvidersDeposit",
                newName: "IX_ProvidersDeposit_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_ProvidersDeposits_ProviderID",
                table: "ProvidersDeposit",
                newName: "IX_ProvidersDeposit_ProviderID");

            migrationBuilder.RenameIndex(
                name: "IX_ProvidersDeposits_BankID",
                table: "ProvidersDeposit",
                newName: "IX_ProvidersDeposit_BankID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProvidersDeposit",
                table: "ProvidersDeposit",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProvidersDeposit_Banks_BankID",
                table: "ProvidersDeposit",
                column: "BankID",
                principalTable: "Banks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProvidersDeposit_Provider_ProviderID",
                table: "ProvidersDeposit",
                column: "ProviderID",
                principalTable: "Provider",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProvidersDeposit_TUser_UserID",
                table: "ProvidersDeposit",
                column: "UserID",
                principalTable: "TUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
