using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AG.Yonetim.MVC.Migrations
{
    public partial class updateBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_UserId",
                table: "Bills",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_AspNetUsers_UserId",
                table: "Bills",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_AspNetUsers_UserId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_UserId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "AspNetUsers");
        }
    }
}
