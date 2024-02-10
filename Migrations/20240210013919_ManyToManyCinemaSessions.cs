using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstAPI.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyCinemaSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CinemaID",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CinemaID",
                table: "Sessions",
                column: "CinemaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Cinemas_CinemaID",
                table: "Sessions",
                column: "CinemaID",
                principalTable: "Cinemas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Cinemas_CinemaID",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_CinemaID",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "CinemaID",
                table: "Sessions");
        }
    }
}
