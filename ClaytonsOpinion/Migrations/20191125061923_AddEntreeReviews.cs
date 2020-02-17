using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClaytonsOpinion.Migrations
{
    public partial class AddEntreeReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntreeReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReviewedEntreeId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    ReviewDateTime = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntreeReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntreeReviews_Entrees_ReviewedEntreeId",
                        column: x => x.ReviewedEntreeId,
                        principalTable: "Entrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntreeReviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntreeReviews_ReviewedEntreeId",
                table: "EntreeReviews",
                column: "ReviewedEntreeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntreeReviews_UserId",
                table: "EntreeReviews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntreeReviews");
        }
    }
}
