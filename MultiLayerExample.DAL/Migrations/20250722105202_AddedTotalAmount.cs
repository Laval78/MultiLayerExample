using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiLayerExample.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedTotalAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Test",
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "TotalAmount",
                value: 2350m);

            migrationBuilder.UpdateData(
                schema: "Test",
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                column: "TotalAmount",
                value: 2350m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Test",
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "TotalAmount",
                value: 0m);

            migrationBuilder.UpdateData(
                schema: "Test",
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                column: "TotalAmount",
                value: 0m);
        }
    }
}
