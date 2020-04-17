using Microsoft.EntityFrameworkCore.Migrations;

namespace Physis.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "Tree",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tree_VendorId",
                table: "Tree",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tree_Vendor_VendorId",
                table: "Tree",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "VendorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tree_Vendor_VendorId",
                table: "Tree");

            migrationBuilder.DropIndex(
                name: "IX_Tree_VendorId",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Tree");
        }
    }
}
