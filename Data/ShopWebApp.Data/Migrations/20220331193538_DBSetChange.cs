using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopWebApp.Data.Migrations
{
    public partial class DBSetChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProduct_AspNetUsers_UserId",
                table: "UserProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProduct_Products_ProductId",
                table: "UserProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProduct",
                table: "UserProduct");

            migrationBuilder.RenameTable(
                name: "UserProduct",
                newName: "UsersProducts");

            migrationBuilder.RenameIndex(
                name: "IX_UserProduct_ProductId",
                table: "UsersProducts",
                newName: "IX_UsersProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersProducts",
                table: "UsersProducts",
                columns: new[] { "UserId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProducts_AspNetUsers_UserId",
                table: "UsersProducts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProducts_Products_ProductId",
                table: "UsersProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersProducts_AspNetUsers_UserId",
                table: "UsersProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProducts_Products_ProductId",
                table: "UsersProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersProducts",
                table: "UsersProducts");

            migrationBuilder.RenameTable(
                name: "UsersProducts",
                newName: "UserProduct");

            migrationBuilder.RenameIndex(
                name: "IX_UsersProducts_ProductId",
                table: "UserProduct",
                newName: "IX_UserProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProduct",
                table: "UserProduct",
                columns: new[] { "UserId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserProduct_AspNetUsers_UserId",
                table: "UserProduct",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProduct_Products_ProductId",
                table: "UserProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
