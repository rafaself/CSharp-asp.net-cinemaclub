using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstAPI.Migrations
{
    /// <inheritdoc />
    public partial class OneToManySessionMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieID",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MovieID",
                table: "Sessions",
                column: "MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Movies_MovieID",
                table: "Sessions",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Movies_MovieID",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_MovieID",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "Sessions");
        }
    }
}
