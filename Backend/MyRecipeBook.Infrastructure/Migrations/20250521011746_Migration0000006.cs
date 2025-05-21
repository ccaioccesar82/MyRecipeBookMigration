using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRecipeBook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration0000006 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_User_UsersID",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "CookingTimes");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_UsersID",
                table: "Recipes");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Recipes",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_User_UserId",
                table: "Recipes",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_User_UserId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Recipes");

            migrationBuilder.CreateTable(
                name: "CookingTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RecipeID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CookingTimes_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RecipeID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Difficulties = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Difficulties_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UsersID",
                table: "Recipes",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_CookingTimes_RecipeID",
                table: "CookingTimes",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Difficulties_RecipeID",
                table: "Difficulties",
                column: "RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_User_UsersID",
                table: "Recipes",
                column: "UsersID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
