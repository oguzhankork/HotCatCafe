using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotCatCafe.MVC.Migrations
{
    /// <inheritdoc />
    public partial class updateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 29, 2, 54, 35, 397, DateTimeKind.Local).AddTicks(7390), "Yiyecek ve Alt Kategorileri", new Guid("5e301288-6818-4290-8e4f-c2de8c6be172") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 29, 2, 54, 35, 397, DateTimeKind.Local).AddTicks(7541), "Tatlı ve Alt Kategorileri", new Guid("72abfd74-6c0a-473e-af10-c7df8245824e") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 29, 2, 54, 35, 397, DateTimeKind.Local).AddTicks(7583), "İçecek ve Alt Kategorileri", new Guid("8294280d-a90a-47f9-a4be-f70aed24d01f") });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 29, 2, 54, 35, 398, DateTimeKind.Local).AddTicks(1261), new Guid("edeb3f3d-5f7a-4c7e-a064-51402cc90fad") });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 29, 2, 54, 35, 398, DateTimeKind.Local).AddTicks(1398), new Guid("b5b28937-bd3e-4c78-9c35-d247284b431f") });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 29, 2, 54, 35, 398, DateTimeKind.Local).AddTicks(1434), new Guid("c51d55a9-09c2-4c31-b6d9-94ad0a450b95") });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 29, 2, 54, 35, 398, DateTimeKind.Local).AddTicks(1480), new Guid("b61cb838-c0da-4536-bb01-8fb324d424ce") });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 29, 2, 54, 35, 398, DateTimeKind.Local).AddTicks(1516), new Guid("cd14ad92-867e-4961-8122-e8baf3087929") });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 29, 2, 54, 35, 398, DateTimeKind.Local).AddTicks(1546), new Guid("0835fea7-4601-4847-b54b-d363837c8868") });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 29, 2, 54, 35, 398, DateTimeKind.Local).AddTicks(1575), new Guid("cff0f586-7260-4774-87f1-5b0970ec5c16") });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 29, 2, 54, 35, 399, DateTimeKind.Local).AddTicks(1899), new Guid("13223e77-1013-48c9-86aa-bebae1314ef2") });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 29, 2, 54, 35, 399, DateTimeKind.Local).AddTicks(2042), new Guid("16785362-82f1-4eab-9e6f-0b70c46e8651") });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 29, 2, 54, 35, 399, DateTimeKind.Local).AddTicks(2087), new Guid("efea0192-40ba-48a0-ac03-119f1e77cfc4") });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 29, 2, 54, 35, 399, DateTimeKind.Local).AddTicks(2123), new Guid("d5527b39-4f9c-4f3d-98fa-291880b0e2a7") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 19, 16, 7, 14, 699, DateTimeKind.Local).AddTicks(9363), "Yiyecek ve Alt Kategrileri", new Guid("38605ecc-7171-4101-a28c-7598eccb75c1") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 19, 16, 7, 14, 699, DateTimeKind.Local).AddTicks(9482), "Tatlı ve Alt Kategrileri", new Guid("772fe3aa-6019-484b-9b62-ffff4628786a") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 19, 16, 7, 14, 699, DateTimeKind.Local).AddTicks(9514), "İçecek ve Alt Kategrileri", new Guid("8a3ea34d-5861-4397-8d40-ff8dd9f92cea") });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 19, 16, 7, 14, 700, DateTimeKind.Local).AddTicks(977), new Guid("1a71d5c2-05fc-45ba-87c1-ad406afa5294") });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 19, 16, 7, 14, 700, DateTimeKind.Local).AddTicks(1039), new Guid("49303c5b-71e0-4c0f-82de-d549f739fa4a") });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 19, 16, 7, 14, 700, DateTimeKind.Local).AddTicks(1063), new Guid("27a06f57-0ce9-4b40-80d6-7188088422bf") });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 19, 16, 7, 14, 700, DateTimeKind.Local).AddTicks(1088), new Guid("a2192ddd-6057-43f9-a2dd-4cb5ebf4c580") });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 19, 16, 7, 14, 700, DateTimeKind.Local).AddTicks(1114), new Guid("d7573154-7900-4493-93ec-5c727f06972b") });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 19, 16, 7, 14, 700, DateTimeKind.Local).AddTicks(1145), new Guid("070e4306-2bdd-473d-89cf-e264e930a69c") });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 19, 16, 7, 14, 700, DateTimeKind.Local).AddTicks(1166), new Guid("a2965ff1-e2b5-412e-b531-0bd6d41aaec5") });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 19, 16, 7, 14, 700, DateTimeKind.Local).AddTicks(5125), new Guid("07921141-8e46-4d71-9ef5-158f43ef9960") });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 19, 16, 7, 14, 700, DateTimeKind.Local).AddTicks(5169), new Guid("ff5ba700-cc36-4262-8b05-dc39c93c4623") });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 19, 16, 7, 14, 700, DateTimeKind.Local).AddTicks(5191), new Guid("e9f49757-9205-4fc9-aa58-45c1d4242cb3") });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 9, 19, 16, 7, 14, 700, DateTimeKind.Local).AddTicks(5211), new Guid("fb96f9bf-567d-4d85-a7d9-14230508cb3a") });
        }
    }
}
