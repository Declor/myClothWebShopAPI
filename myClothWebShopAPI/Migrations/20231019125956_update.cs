using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myClothWebShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8542f91-cf48-459a-b53f-7e0c495ef050", "AQAAAAIAAYagAAAAEAB1CTgvZcbf5MsPhQEXL3ac82chbGtk/8qLve+DW7557q4H7JyKx/ka8dBMbr/4kg==", "30efa9d0-25c0-4dcd-828c-7302629449a9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e627884-a7ad-4749-8dfb-f6d97a97a7c1", "AQAAAAIAAYagAAAAEEZUZqJH6vtNES3Eg+C2N+Alxn8X93VbUCsgyyrJ5thMdVeOeG5pteg3jXvyJZb6ew==", "f02468d9-797c-4650-8a1f-7713842474cb" });
        }
    }
}
