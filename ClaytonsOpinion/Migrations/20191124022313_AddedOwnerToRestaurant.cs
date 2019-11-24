using Microsoft.EntityFrameworkCore.Migrations;

namespace ClaytonsOpinion.Migrations
{
    public partial class AddedOwnerToRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RestaurantOwnerId",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_RestaurantOwnerId",
                table: "Restaurants",
                column: "RestaurantOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_AspNetUsers_RestaurantOwnerId",
                table: "Restaurants",
                column: "RestaurantOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_AspNetUsers_RestaurantOwnerId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_RestaurantOwnerId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "RestaurantOwnerId",
                table: "Restaurants");
        }
    }
}
