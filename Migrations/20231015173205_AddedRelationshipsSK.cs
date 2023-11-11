using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationshipsSK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_ShoppingCarts_ShopingCartId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ShopingCartId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ShopingCartId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "ShoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_MovieId",
                table: "ShoppingCarts",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Movies_MovieId",
                table: "ShoppingCarts",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Movies_MovieId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_MovieId",
                table: "ShoppingCarts");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "ShoppingCarts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ShopingCartId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ShopingCartId",
                table: "Movies",
                column: "ShopingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_ShoppingCarts_ShopingCartId",
                table: "Movies",
                column: "ShopingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");
        }
    }
}
