using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class updatetablecommentuserReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "UserReportComments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "UserReportComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserReportComments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c01438e7-75dd-457c-8a60-56a3aeef023b", "AQAAAAIAAYagAAAAEE9phkDYkifuW+PItDLRZKEIWk2+dv1ldhVo83wkxRL0gpd5R5l2v2gsL7l781eNdQ==", "ac11b248-c6f6-4784-ad87-23ed25c72493" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe4b8cd3-b865-41cd-a836-0eac8c84c247", "AQAAAAIAAYagAAAAEMs2Z0U8Ylz7EbMu//uk/4itUTlM8HCJ+SBUCVD5hwrQCh8b9G749kvty5rhKZS2bw==", "e96bdffb-1c41-4c27-b38b-33750de9c80f" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "200bfad3-fb87-40fd-9248-3e5518d2d45f", "AQAAAAIAAYagAAAAEJ2rRoLA78b0DF53j+ChC1qrK+5ZKjUcxBdlcff2HaYD7b92pW4cRMuow7nThy5dsQ==", "795befd2-93a2-4acb-8efd-59c74a94561f" });

            migrationBuilder.CreateIndex(
                name: "IX_UserReportComments_UserId",
                table: "UserReportComments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReportComments_Account_UserId",
                table: "UserReportComments",
                column: "UserId",
                principalTable: "Account",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReportComments_Account_UserId",
                table: "UserReportComments");

            migrationBuilder.DropIndex(
                name: "IX_UserReportComments_UserId",
                table: "UserReportComments");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "UserReportComments");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "UserReportComments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserReportComments");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b212caa3-2033-45f3-a887-161ac6fc22e4", "AQAAAAIAAYagAAAAEK6me3V/xm1sBwEd7rLuWBW3uvvD2qlJYb3WXFEaRRgLum7/WfARU8y4W8stgtQ2xQ==", "38a0026d-a4bc-42cd-a0c0-4aff09e7c32a" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e992b5a5-d335-49c7-93c0-b1fc17c67b15", "AQAAAAIAAYagAAAAEIr2wiX2VLJvbvZp0z/V3PcDOZ1SlI0fHbofTsUCXAZ0idRcuQl0PB6UAHABV+0MpA==", "c5a03f20-a0fc-4a73-8f37-09810124e14f" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71c74a49-19c1-4a04-8d52-89b4b6decab0", "AQAAAAIAAYagAAAAEOwzuYBpzrZ+WXDhykXMQMcaIXMn1yA/t9fNNgBHH/j2rPZJ95xqsGZ12+Mra2sZGA==", "3297f302-8dfa-4dd7-8789-413fd12ffaa3" });
        }
    }
}
