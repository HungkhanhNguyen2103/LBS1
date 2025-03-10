using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addTableUserReportComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserReportComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserReportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReportComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserReportComments_UserReport_UserReportId",
                        column: x => x.UserReportId,
                        principalTable: "UserReport",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "745c4bfe-321c-490d-b6c3-b66ea44607e9", "AQAAAAIAAYagAAAAEE66c89vpelVvVrddfevuN3+HFwROba0PNMv5nHR3grqVwYCc/ZiuRxO3wYVMngVQQ==", "902d6522-747b-4459-af04-7cc37b3658e6" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "174b1c4d-3c0d-469b-b0ab-6220d9bb561d", "AQAAAAIAAYagAAAAENdcWfsphAdwsCHCiwtw6Uj0eOaQLozzdkZu+WaACQ1QseC3xujhnpSk9QYh1aPIrw==", "abd9923a-1569-44e5-bb6f-42ea8e370933" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f47d184-b03a-4ac7-8b45-6c8d86452e84", "AQAAAAIAAYagAAAAEDVzOQEo5tRa7snja7qhnW3ClCcFwTKLrFzDJTjP8B/i/aDjefd8dP34zRMrq6tS7g==", "e97c8e2b-541d-4917-8623-adf0fddbcf05" });

            migrationBuilder.CreateIndex(
                name: "IX_UserReportComments_UserReportId",
                table: "UserReportComments",
                column: "UserReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserReportComments");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d233e03c-3a0b-44eb-bb52-54c69836bcc9", "AQAAAAIAAYagAAAAEJ0gPlbjhVhnzkorO09XR+crrY7fktGafSOR9oXCOyUM/rlCoPFnTa9JGgEiqZ43PA==", "021d5351-f869-437b-80d9-a0225968b451" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14fa5dbc-8c0b-41c5-93b6-4e301fc8d745", "AQAAAAIAAYagAAAAEAwvYDEdoIw+aiFEP5lnuHu/cfRiwI4DJTIpYWFaQjgnQBTQr4umoI2HKBrEeyo2zA==", "83eb89bc-34bb-4567-96f8-a1e3f33e7bd9" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb576bd3-6d50-497d-bfe3-ec979a15f7e7", "AQAAAAIAAYagAAAAEAPJhyvldMyHu+7g8uTXomIv5BlgZFgF4fGr29LtkEY6f0VvLFB+JlnQSieZ8V7njg==", "73522e64-e5ba-4216-abfb-db9fda729179" });
        }
    }
}
