using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDyeFor.Migrations
{
    public partial class AddApplicationUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MXRecipe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ShadeDepth = table.Column<double>(nullable: false),
                    FabricWeight = table.Column<double>(nullable: false),
                    DyeColor = table.Column<string>(nullable: true),
                    Fabric = table.Column<int>(nullable: false),
                    Color = table.Column<int>(nullable: false),
                    Salt = table.Column<double>(nullable: false),
                    SodaAsh = table.Column<double>(nullable: false),
                    Water = table.Column<double>(nullable: false),
                    Dye = table.Column<double>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MXRecipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MXRecipe_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MXRecipe_ApplicationUserId",
                table: "MXRecipe",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MXRecipe");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");
        }
    }
}
