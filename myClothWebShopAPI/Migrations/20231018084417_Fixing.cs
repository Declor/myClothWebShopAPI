using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myClothWebShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class Fixing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6e12ea8-a3f9-41ae-8361-f463511e3c82", "AQAAAAIAAYagAAAAEHJd4BGwpqAxKvCL9RHvfBRkxWAyOCgmMyB94jXbk6RgCG+TTjOJbaglRazsg3lCpA==", "339e562f-2111-4e43-99c3-784cb14b64ce" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c57cf4f-64e7-424a-b47d-ec9f05cecfdb", "AQAAAAIAAYagAAAAEBnME946y52sKObLCc4RjlRIe+7+PjaPxuStr3At26ZZGrZR8vjNltsWrHIxrvFQpg==", "56bd0cb9-2ed7-4bd2-96ed-dc5a499e0ed1" });
        }
    }
}
