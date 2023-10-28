using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myClothWebShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateBase64ImageInShopItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f33e39c9-1bae-4e73-9bf1-56270238a95d", "AQAAAAIAAYagAAAAEOA4bL0oueTc/l5BUsl5JefMDd5QQMs1IHb7DjUFM5K8rAGG7pTDUJU+fRXKId19Og==", "00da1dc0-2d95-4fea-be1f-a6d9e657d0c1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8542f91-cf48-459a-b53f-7e0c495ef050", "AQAAAAIAAYagAAAAEAB1CTgvZcbf5MsPhQEXL3ac82chbGtk/8qLve+DW7557q4H7JyKx/ka8dBMbr/4kg==", "30efa9d0-25c0-4dcd-828c-7302629449a9" });
        }
    }
}
