using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esty_Context.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_AspNetUsers_CustomerId1",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_CustomerId1",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "orders");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_orders_CustomerId",
                table: "orders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_AspNetUsers_CustomerId",
                table: "orders",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_AspNetUsers_CustomerId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_CustomerId",
                table: "orders");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId1",
                table: "orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_CustomerId1",
                table: "orders",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_AspNetUsers_CustomerId1",
                table: "orders",
                column: "CustomerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
