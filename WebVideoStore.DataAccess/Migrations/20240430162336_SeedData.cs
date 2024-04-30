using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebVideoStore.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "VideoTapes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceRent = table.Column<double>(type: "float", nullable: false),
                    PriceBuy = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoTapes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "VideoTapes",
                columns: new[] { "Id", "Director", "PriceBuy", "PriceRent", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "James Cameron", 85.0, 6.0, "The Terminator", 1984 },
                    { 2, "The Wachowski Brothers", 74.0, 4.0, "The Matrix", 1999 },
                    { 3, "Francis Ford Coppola", 95.0, 6.0, "The Godfather", 1972 },
                    { 4, "Christopher Nolan", 75.0, 5.0, "The Dark Knight", 2008 },
                    { 5, "Frank Darabont", 80.0, 5.0, "The Shawshank Redemption", 1994 },
                    { 6, "Quentin Tarantino", 70.0, 4.0, "Pulp Fiction", 1994 },
                    { 7, "Jonathan Demme", 70.0, 4.0, "The Silence of the Lambs", 1991 },
                    { 8, "Stanley Kubrick", 70.0, 4.0, "The Shining", 1980 },
                    { 9, "William Friedkin", 70.0, 4.0, "The Exorcist", 1973 },
                    { 10, "M. Night Shyamalan", 70.0, 4.0, "The Sixth Sense", 1999 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoTapes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
