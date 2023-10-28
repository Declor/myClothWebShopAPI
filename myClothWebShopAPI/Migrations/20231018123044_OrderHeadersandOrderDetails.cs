using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myClothWebShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class OrderHeadersandOrderDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderHeaderd",
                table: "OrderHeaders",
                newName: "OrderHeaderId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dac233fe-fa5e-4d55-9e48-fe1f8bbe22ad", "AQAAAAIAAYagAAAAEEM/u2JzN+dl3c9fnPfXY99WlL1AeCBhUrensjgBw6h69AB2Wk9nDYA6Cq/KZ7qaew==", "e358c527-2ea5-4269-af07-9c6e91dc515e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderHeaderId",
                table: "OrderHeaders",
                newName: "OrderHeaderd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00151b1e-2636-47d3-9f7d-20df9820f3c4", "AQAAAAIAAYagAAAAEEE/3J4LZ2fj5952bhdseGbetBs905txqJdmD4wJDkJYlv2NviM1JFiveU2yDd34+w==", "9e15917f-09fa-4b31-b8e6-8ee5d5169d87" });
        }
    }
}
