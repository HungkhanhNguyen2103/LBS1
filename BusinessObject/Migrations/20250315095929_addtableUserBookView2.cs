using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addtableUserBookView2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserBookView",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChapterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBookView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBookView_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd37b157-8428-4c6c-9a4e-c6e8b397480b", "AQAAAAIAAYagAAAAEJAdKpGLLbKr4t6ecboARo2PckPucNfr/PgfY2+Bv89Z+HGa66MmWCtjBNqCoRO8Fg==", "620ddaa8-288c-405f-b1ed-e14534173ce4" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adfd4836-fd12-42eb-a0d4-e927a8873610", "AQAAAAIAAYagAAAAEKH7AUUFZ570rVRG7vgEKULkKnSDrFl2nASFfzOdsndRtVMoNXeFa2qJDsDFcHwwCA==", "2686bf8c-08f2-4a75-85a1-e2d6f01d2dfc" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfa1e3a0-1bf4-49ee-b01a-f9b52945c830", "AQAAAAIAAYagAAAAEK/jIYhBzexAlU/puLoEL6TemdVjHz/UEo2K5MW0iIOHQi/XIEyTrU5WmtXr+snivg==", "ee65d211-0b49-417c-8753-a798e18b53a9" });

            migrationBuilder.CreateIndex(
                name: "IX_UserBookView_UserId",
                table: "UserBookView",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBookView");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "736c6cf4-3c85-4ecd-9eb4-7088c4e1b384", "AQAAAAIAAYagAAAAEFVF2kJnhSE7bpgFxRS9TpY9qk9KB0q+KO4EO8VmnwbM35ye+fljmIcX6qoLT0Q6zw==", "8cbadce0-9bdc-4567-88f1-1fb4e0b515f1" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b080c2b-64c4-4205-a53d-dbd6fe5150f0", "AQAAAAIAAYagAAAAEHwzUIw6gwwlJNTcZYG4+NNG+cVtJ1j2xYN4vsUb4QcfVAtOagdKm6k8RyRhBq0hDQ==", "f83864d2-3a01-49a2-871d-33c54fa26ec1" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f497cd54-b6e7-4b85-a685-03f8fe7d69ba", "AQAAAAIAAYagAAAAEL/TcZVvDiwd+e1imuEd0fP+BwQc9DN2LrjZZ6Ll29/tn7/ZwVXs2twljYkO8oqADA==", "f77f186f-a536-4f30-801e-60d3e27fdc9b" });
        }
    }
}
