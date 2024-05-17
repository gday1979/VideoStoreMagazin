using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebVideoStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addCompanyFilmMaker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 6, "Los Angeles", "20 Century Pictures", "001245858963", "90210", "California", "Park Avenue" },
                    { 7, "Los Angeles", "Warner Bros", "001359326589", "90210", "California", "Warner Blvd" },
                    { 3, "Universal City", "Universal Pictures", "001895689958", "91608", "California", "Universal City Plaza" },
                    { 4, "Los Angeles", "Paramount Pictures", "001359326589", "90038", "California", "Melrose Ave" },
                    { 5, "Los Angeles", "New Line Cinema", "0012582589659", "90038", "California", "New Line Cinema" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
