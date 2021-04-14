using Microsoft.EntityFrameworkCore.Migrations;

namespace NaqdiDAL.Migrations
{
    public partial class dataseedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excute_TUser_user_id",
                table: "Excute");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "ID", "name" },
                values: new object[,]
                {
                    { 1, "مالك" },
                    { 2, "وكيل" },
                    { 3, "مركز" },
                    { 4, "موظف" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Excute_FinalUser",
                table: "Excute",
                column: "FinalUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Excute_TUser_FinalUser",
                table: "Excute",
                column: "FinalUser",
                principalTable: "TUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Excute_TUser_user_id",
                table: "Excute",
                column: "user_id",
                principalTable: "TUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excute_TUser_FinalUser",
                table: "Excute");

            migrationBuilder.DropForeignKey(
                name: "FK_Excute_TUser_user_id",
                table: "Excute");

            migrationBuilder.DropIndex(
                name: "IX_Excute_FinalUser",
                table: "Excute");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.AddForeignKey(
                name: "FK_Excute_TUser_user_id",
                table: "Excute",
                column: "user_id",
                principalTable: "TUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
