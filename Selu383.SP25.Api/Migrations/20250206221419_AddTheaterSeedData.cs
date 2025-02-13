using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Selu383.SP25.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTheaterSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Theaters",
                columns: new[] { "Id", "Address", "Name", "SeatCount" },
                values: new object[,]
                {
                    { 1, "1200 W University Ave, Hammond, LA 70401", "AMC Hammond Square 8", 1200 },
                    { 2, "1950 Gause Blvd W, Slidell, LA 70460", "Grand Cinema Slidell", 800 },
                    { 3, "201 N US Highway 190, Covington, LA 70433", "Movie Tavern Covington", 950 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Theaters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Theaters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Theaters",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
