using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebVideoStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddVideoTapeCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

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
                    PriceBuy = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoTapes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoTapes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Action" },
                    { 2, 2, "Comedy" },
                    { 3, 3, "Drama" },
                    { 4, 4, "Horror" },
                    { 5, 5, "Sci-Fi" }
                });

            migrationBuilder.InsertData(
                table: "VideoTapes",
                columns: new[] { "Id", "CategoryId", "Director", "ImageUrl", "PriceBuy", "PriceRent", "Title", "Year" },
                values: new object[,]
                {
                    { 1, 5, "James Cameron", "", 85.0, 6.0, "The Terminator", 1984 },
                    { 2, 5, "The Wachowski Brothers", "", 74.0, 4.0, "The Matrix", 1999 },
                    { 3, 1, "Francis Ford Coppola", "", 95.0, 6.0, "The Godfather", 1972 },
                    { 4, 4, "Christopher Nolan", "", 75.0, 5.0, "The Dark Knight", 2008 },
                    { 5, 2, "Frank Darabont", "", 80.0, 5.0, "The Shawshank Redemption", 1994 },
                    { 6, 3, "Quentin Tarantino", "", 70.0, 4.0, "Pulp Fiction", 1994 },
                    { 7, 3, "Jonathan Demme", "", 70.0, 4.0, "The Silence of the Lambs", 1991 },
                    { 8, 4, "Stanley Kubrick", "", 70.0, 4.0, "The Shining", 1980 },
                    { 9, 4, "William Friedkin", "", 70.0, 4.0, "The Exorcist", 1973 },
                    { 10, 4, "M. Night Shyamalan", "", 70.0, 4.0, "The Sixth Sense", 1999 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoTapes_CategoryId",
                table: "VideoTapes",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoTapes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
