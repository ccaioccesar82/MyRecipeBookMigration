using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRecipeBook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration0000007 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_User_UserId",
                 table: "Recipes");


            migrationBuilder.DropIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Recipes"
                );

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UsersID",
                table: "Recipes",
                column: "UsersID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_User_UsersID",
                table: "Recipes",
                column: "UsersID",
                principalTable: "User",
                principalColumn: "Id");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
