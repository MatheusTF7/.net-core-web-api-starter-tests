using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWebVale.Migrations
{
    public partial class conta_em_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "User",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_User_AccountId",
                table: "User",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Account_AccountId",
                table: "User",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Account_AccountId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AccountId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "User");
        }
    }
}
