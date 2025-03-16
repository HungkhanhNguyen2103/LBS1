using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class changedatatype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "UserReport",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "UserReport",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "UserReport",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4a7a4ae-d503-41b4-b4ef-e8cfc82cdd89", "AQAAAAIAAYagAAAAEBboMOprAwsRETWGGmBSnNFoMscvIzArS/TUcvsq4wcDPjBlH9ACPirdItL9o+mp+A==", "1b8bf4de-e662-4c3d-9b92-d70041089e99" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed5da83c-ec2f-470c-aed3-43056abb753f", "AQAAAAIAAYagAAAAEJI91zp/m5TvLzdaAiaCILYqTpUTR60T2ZAtxX7IiSQeBWArD7K7t29iPo6NFj2rJg==", "f97ce592-8e3a-430a-99dc-fc8584d4d41a" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69d19b16-44da-4988-8a36-20e1a613b7d4", "AQAAAAIAAYagAAAAEEEJUUdJE34qUruQs3HqlrOidKFiRlpHxKSEjF46ZC61TyAiw1LvyGB9HjnY+TKuXg==", "16ecbdd9-0696-43b2-80b2-9d94fd1f12f4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "UserReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "UserReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "UserReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
