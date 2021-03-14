using Microsoft.EntityFrameworkCore.Migrations;

namespace Recycling.Data.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RecycleOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_RecycleOrders_UserId",
                table: "RecycleOrders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecycleOrders_AspNetUsers_UserId",
                table: "RecycleOrders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecycleOrders_AspNetUsers_UserId",
                table: "RecycleOrders");

            migrationBuilder.DropIndex(
                name: "IX_RecycleOrders_UserId",
                table: "RecycleOrders");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RecycleOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
