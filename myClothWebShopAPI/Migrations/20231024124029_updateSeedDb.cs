using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myClothWebShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateSeedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "614e1c7e-d742-4ce8-95d4-7e4dbe49c5f4", "AQAAAAIAAYagAAAAEExt9ECwR5AxemZFznTRHgcMxqVUs5rfKGBl7DZ+JchKxEOMU/Y+Vg6fZ9Ic+r9l6A==", "4c3c2b48-8bfc-4587-a06d-a7efc0db9bcc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f33e39c9-1bae-4e73-9bf1-56270238a95d", "AQAAAAIAAYagAAAAEOA4bL0oueTc/l5BUsl5JefMDd5QQMs1IHb7DjUFM5K8rAGG7pTDUJU+fRXKId19Og==", "00da1dc0-2d95-4fea-be1f-a6d9e657d0c1" });
        }
    }
}
