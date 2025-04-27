using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class changeRoleAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "627ec4a3-646f-455f-b65f-2903cf78220f", "7d5002bd-f22f-4c7c-bce1-3d22eed213ff" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "627ec4a3-646f-455f-b65f-2903f87c19b6", "7d5002bd-f22f-4c7c-bce1-3d22eed213ff" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2b5c7dc-c36b-4c72-93c3-910587348ead", "AQAAAAIAAYagAAAAEGOcYalqMJniLYhwl+SZGvg3fAOAKEeONeF8EXvNggnWgoi4JnmetMpc3/ykOCeLVw==", "e182f3b6-7104-4dbb-823a-37112d840953" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c02c821-98b5-4683-8162-5b04ad1462ed", "AQAAAAIAAYagAAAAEPcx+utU2CKUA2247Oozv+b4q8zW0HDvDnhbODufuBWopZC7wCG6iH5bn4ZIUd9Vvg==", "62ef1d90-087b-402e-86a3-7578ec23db69" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79f8ed9a-f60f-4651-aa8c-283da75eeb65", "AQAAAAIAAYagAAAAEPz3oyadI17mNG6onRw/fQHTmVY0GNovsUd15lwy1cl6oOgPCaSwGrqI/jniRzv5kw==", "33b51b5a-920b-434b-94f6-9c4b69937791" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17ca6353-860c-46f0-9e33-a3eb404ebc48", "AQAAAAIAAYagAAAAEGmHTz3YyxuKtKv7zmOyUyFeZ69GaXZgtj/dRerUUSmiD2b1w8xZMHSKDklbscczQw==", "45685d18-7e11-4078-a553-d3587c0836d8" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a44a59e-5ddc-4b22-b92f-4aead5000c9e", "AQAAAAIAAYagAAAAEEHAG9x+Zm+Q/fqjOjriItIebDfprD6LnVYSIHZ1zeZFjvnZFkE1fQBg5WoA4nPudw==", "8c788afa-197d-421e-a13c-ab15a5f5b4d2" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb2c5425-2c34-4b97-a60a-1cc1021086f5", "AQAAAAIAAYagAAAAEBYD7iSMwQt/AKLhPiHUAZ7hRX+RgsPyykq3XkhUwUAbwf2PoPfCau81eVYKEcIT5g==", "551d20a4-dea5-4381-b984-cb49096e5b9d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "627ec4a3-646f-455f-b65f-2903cf78220f", "7d5002bd-f22f-4c7c-bce1-3d22eed213ff" },
                    { "627ec4a3-646f-455f-b65f-2903f87c19b6", "7d5002bd-f22f-4c7c-bce1-3d22eed213ff" }
                });
        }
    }
}
