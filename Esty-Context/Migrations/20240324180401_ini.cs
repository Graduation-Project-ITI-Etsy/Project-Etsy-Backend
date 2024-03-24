using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esty_Context.Migrations
{
    /// <inheritdoc />
    public partial class ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentID",
                table: "payment",
                newName: "PaymentId");

            migrationBuilder.AddColumn<string>(
                name: "CategoryImage",
                table: "categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BaseCategoryImage",
                table: "baseCategories",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryImage",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "BaseCategoryImage",
                table: "baseCategories");

            migrationBuilder.RenameColumn(
                name: "PaymentId",
                table: "payment",
                newName: "PaymentID");
        }
    }
}
