using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsilMedia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VideoPhotoPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Films",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoPath",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "FilmMakers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "VideoPath",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "FilmMakers");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Actors");
        }
    }
}
