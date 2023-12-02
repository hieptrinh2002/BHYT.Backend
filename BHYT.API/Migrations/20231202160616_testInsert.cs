using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHYT.API.Migrations
{
    /// <inheritdoc />
    public partial class testInsert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "STATUS",
                columns: new[] { "ID", "GUID", "NAME" },
                values: new object[] { 0, new Guid("bb2c9a22-d548-4420-8fe9-2fe222fc4885"), true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "STATUS",
                keyColumn: "ID",
                keyValue: 0);
        }
    }
}
