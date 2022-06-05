using Microsoft.EntityFrameworkCore.Migrations;

namespace chatApplication.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IdentityUser_UserName",
                table: "IdentityUser");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUser_UserName",
                table: "IdentityUser",
                column: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IdentityUser_UserName",
                table: "IdentityUser");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUser_UserName",
                table: "IdentityUser",
                column: "UserName")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName")
                .Annotation("SqlServer:Clustered", false);
        }
    }
}
