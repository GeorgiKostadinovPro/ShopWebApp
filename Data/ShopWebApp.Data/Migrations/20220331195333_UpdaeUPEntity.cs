using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopWebApp.Data.Migrations
{
    public partial class UpdaeUPEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UsersProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UsersProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UsersProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UsersProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "UsersProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersProducts_IsDeleted",
                table: "UsersProducts",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersProducts_IsDeleted",
                table: "UsersProducts");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UsersProducts");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UsersProducts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsersProducts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UsersProducts");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "UsersProducts");
        }
    }
}
