using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _04_CRUD.Migrations
{
    public partial class SeedData01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopId", "Created", "Name" },
                values: new object[] { 1, new DateTime(2020, 2, 21, 14, 21, 32, 878, DateTimeKind.Local).AddTicks(7536), "Super Grocery" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Cost", "Name", "ShopId" },
                values: new object[] { new Guid("6c408478-b40f-4b53-9491-b01cf8ec0213"), 2.32m, "Milk 500ml", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("6c408478-b40f-4b53-9491-b01cf8ec0213"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: 1);
        }
    }
}
