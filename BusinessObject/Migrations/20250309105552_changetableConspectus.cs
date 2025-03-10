using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class changetableConspectus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conspectus_Book_BookId",
                table: "Conspectus");

            migrationBuilder.DropIndex(
                name: "IX_Conspectus_BookId",
                table: "Conspectus");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Conspectus");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a763aaa-7fd2-4fa0-8ccb-f54eacd92b67", "AQAAAAIAAYagAAAAENF2s1LL18SNLv+cYLYP9PWfbYnSA4yc0Mpeg9v7H7qqGC59cS7zzwdwfQXausWjuw==", "2c6ee9aa-2543-4683-99b7-f138ef9cbe9d" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90074dfd-d20c-43ee-aafb-c1406947772c", "AQAAAAIAAYagAAAAEP8nlwpr6+bBVx8BqsfzGGIlGoO7TIkwwRoczVujwy3KDxWLzCHjsDtYCpopnx8e4A==", "d5c444c1-4e6e-4694-8409-c638f65bee67" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9eb122e3-b2ba-436f-9b82-b3edb64abc05", "AQAAAAIAAYagAAAAELbJ2KHkq17DdaZXnmDc9lBKtNs7hevVYRrg7DOyg3i2dM1AxLPqxc/xzLFxtbs8zw==", "4dfab49e-1019-4eac-b8e8-bf5d8754982d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Conspectus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a1f457d-ce22-4d85-81f7-669101693ee5", "AQAAAAIAAYagAAAAEJ/e0zcjzB1x6UrBDS8Ch836Q1jsNy9DWpf02kU2bDh+RbhcoWli6Bf+4iwMichBaw==", "c7850e93-6511-44b9-af32-9b65fda75e37" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85f163d5-e35a-485b-8420-e6c0b83de078", "AQAAAAIAAYagAAAAEEnqpPVIXr46XG3uTh3rPSO9Ys5zyTOn4ODqXEK0uyszub6ILJ4tU2J7BZfLNDV2VA==", "3a0d71c6-1f2d-4814-bbf0-8416081d1165" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b07dcdb-8e78-4af4-9c52-00514974aa81", "AQAAAAIAAYagAAAAEPHEO8YC7AdCrozUps9QoGc8t8It3bMhgsuIa26L66KxTW7J2RO0sbNvtQFO1nqvLw==", "a2e0fc9f-8073-4918-9e44-896ad98b31e1" });

            migrationBuilder.CreateIndex(
                name: "IX_Conspectus_BookId",
                table: "Conspectus",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conspectus_Book_BookId",
                table: "Conspectus",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
