using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addTableCommentUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChapterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentUsers_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29d2ddda-7a5e-42e1-8927-efc52bc38396", "AQAAAAIAAYagAAAAEOeMYgTzyAtNwJeF0j1L9l/CnYgVYsbPRKCNc5NK2DAEWo0qQpQCwt0EU0uRMhqZwQ==", "58d1b12f-4d79-4aa6-8b36-059c6cd091b2" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8aa0fa00-cff3-4f8e-98d2-e70fb565a8dd", "AQAAAAIAAYagAAAAENWlrs8qjrwO0W0j3npUPpY3vG4pDso2EjL2uw28hBXrAf2waAw6j1WkPb/KuJI1kw==", "7ca0ef99-0a91-4dc2-a4d7-fdc4646898ab" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da004515-5211-4fef-ada1-15d5f60b1524", "AQAAAAIAAYagAAAAEPNPNeVBghve9yS9YvKoiZE+OG8ZjEZUd7j6MzsqtN0WaTpWfROmn9NPRqU8DFnYPg==", "971fcec7-5369-4a22-a652-036c598bc143" });

            migrationBuilder.CreateIndex(
                name: "IX_CommentUsers_AccountId",
                table: "CommentUsers",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentUsers");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25262bfd-2474-49b4-a88d-07fed36745dc", "AQAAAAIAAYagAAAAEMYud5P3Uj5LxdtPmfnne2cqgdM+wszDEqd6EzzVn/Cph5uSmjUfoUmPkTLNDKzO7Q==", "a30d2346-7e41-4b84-8bb5-117a68c384b9" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21b5157f-46f7-4526-8125-b96b2985a16d", "AQAAAAIAAYagAAAAEKdU1G+hr/K0LrpOj9qSLPLJ1ORtgHSEgL8OnrtDZuDcUDbFBXE+OY5obj4Y8V+apg==", "6746e978-febb-4518-836b-420b53120c7a" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa5258c0-a174-438c-961a-6e21939aa4d0", "AQAAAAIAAYagAAAAEPg/t4UCM98MCJvEH37/8XHKct7AfIEuhAgp4zFB9tdaYvUEUzlksST4ruOvzwbTRA==", "7d57e3c2-4e6d-4a92-983b-fa88891bec47" });
        }
    }
}
