using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pinball.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedGameColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Game1",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Game2",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Game3",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Game4",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Game5",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GameEliminatedIn",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Game1",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Game2",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Game3",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Game4",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Game5",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GameEliminatedIn",
                table: "Players");
        }
    }
}
