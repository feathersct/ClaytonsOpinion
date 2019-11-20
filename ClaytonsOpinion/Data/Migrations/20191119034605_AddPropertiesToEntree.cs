using Microsoft.EntityFrameworkCore.Migrations;

namespace ClaytonsOpinion.Data.Migrations
{
    public partial class AddPropertiesToEntree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Restaurants",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Bookmarks",
                table: "Entrees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dislikes",
                table: "Entrees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Entrees",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bookmarks",
                table: "Entrees");

            migrationBuilder.DropColumn(
                name: "Dislikes",
                table: "Entrees");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Entrees");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Restaurants",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
