using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addNewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasicKnowledge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicKnowledge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conspectus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conspectus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conspectus_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Conspectus_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportType = table.Column<int>(type: "int", nullable: false),
                    UserReportStatus = table.Column<int>(type: "int", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserReport_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea37ae12-a687-475a-a2a9-b7625055a44c", "AQAAAAIAAYagAAAAEKWjMgsu0mLm1lKl/B/wMXfZFxqaUuLiAjhCPbkB6kOBxMHuBriBfhIfAN1Hh70JaA==", "abc414fb-a2f1-490c-96b1-8c26e5aac08c" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee9dab03-46d9-424f-bba9-2be0647c5e53", "AQAAAAIAAYagAAAAEE0P97pVMHcJUFV8dQXyhuFienb91eMbO6ZGKnicgpkqsADjw1FkjoRO06IKp5qzyQ==", "ac1bace7-2f24-45e5-a9d4-ea646c319598" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e711fbc-f121-4e70-bcd4-7c52171e742c", "AQAAAAIAAYagAAAAEOfs7zqtLPaDbheJtlzvFBKNpDyo3kBoervaPwj9M1CBgeiNSOTr7sXYQSJUq1vm+g==", "3ffcf468-511b-4266-9c7f-0a733413b747" });

            migrationBuilder.CreateIndex(
                name: "IX_Conspectus_BookId",
                table: "Conspectus",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Conspectus_UserId",
                table: "Conspectus",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReport_UserId",
                table: "UserReport",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasicKnowledge");

            migrationBuilder.DropTable(
                name: "Conspectus");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "UserReport");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35da64fa-08db-4597-a861-ab8c53f3ec7f", "AQAAAAIAAYagAAAAED7qQSZzG3sK5DYJTg3mDgFKxcC2KeTTdJxfTBOTtyBi0ybkSnpwbKlRJWsVRv1QbQ==", "e6725c6f-ef2d-43d7-85d8-16e48fa2f5dc" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ece98ff0-323a-4952-af4c-f18f0181e2ad", "AQAAAAIAAYagAAAAEOxnpwKvA2ittJVpW8x3U1rr21z5OAnbFvZ37grYzkm2ROoDLacdVWvWU9GSr08F1A==", "7b097e5c-dd75-45ef-97a5-4a506c1298f8" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03b1c572-7d0f-4698-a2fc-4012c072b70f", "AQAAAAIAAYagAAAAEHv6vBlPN4WtxjxYFN859Qe/9zejO++9TG7Uo5RfZ7Jzkm9ptKsJHc/Kn/lGVclp3w==", "8e49bb85-f3c7-46b0-8ae7-766cdd5a9929" });
        }
    }
}
