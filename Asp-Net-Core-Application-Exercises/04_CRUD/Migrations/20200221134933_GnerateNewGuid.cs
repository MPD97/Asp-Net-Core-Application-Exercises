using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _04_CRUD.Migrations
{
    public partial class GnerateNewGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("6c408478-b40f-4b53-9491-b01cf8ec0213"));

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Cost", "Name", "ShopId" },
                values: new object[] { new Guid("6eb3315e-18e3-4c2f-ad94-82a8d5ae32c4"), 2.32m, "Milk 500ml", 1 });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 2, 21, 14, 49, 32, 823, DateTimeKind.Local).AddTicks(5708));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("6eb3315e-18e3-4c2f-ad94-82a8d5ae32c4"));

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Cost", "Name", "ShopId" },
                values: new object[] { new Guid("6c408478-b40f-4b53-9491-b01cf8ec0213"), 2.32m, "Milk 500ml", 1 });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 2, 21, 14, 21, 32, 878, DateTimeKind.Local).AddTicks(7536));
        }
    }
}
