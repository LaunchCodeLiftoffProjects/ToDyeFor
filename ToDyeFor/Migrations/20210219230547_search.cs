using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDyeFor.Migrations
{
    public partial class search : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MXRecipe_AspNetUsers_ApplicationUserId",
                table: "MXRecipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MXRecipe",
                table: "MXRecipe");

            migrationBuilder.RenameTable(
                name: "MXRecipe",
                newName: "recipes");

            migrationBuilder.RenameIndex(
                name: "IX_MXRecipe_ApplicationUserId",
                table: "recipes",
                newName: "IX_recipes_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_recipes",
                table: "recipes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_recipes_AspNetUsers_ApplicationUserId",
                table: "recipes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recipes_AspNetUsers_ApplicationUserId",
                table: "recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_recipes",
                table: "recipes");

            migrationBuilder.RenameTable(
                name: "recipes",
                newName: "MXRecipe");

            migrationBuilder.RenameIndex(
                name: "IX_recipes_ApplicationUserId",
                table: "MXRecipe",
                newName: "IX_MXRecipe_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MXRecipe",
                table: "MXRecipe",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MXRecipe_AspNetUsers_ApplicationUserId",
                table: "MXRecipe",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
