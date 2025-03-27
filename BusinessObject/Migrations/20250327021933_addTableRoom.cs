using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addTableRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AuthorUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChapterBookId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Account_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Room_Account_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b856f06d-3116-4f7a-89e6-10c1c6661493", "AQAAAAIAAYagAAAAENK2cgu5JHDOVLgeSrwU5JgclzdJL5ujndL0lelREE0/kWxtwSW7bVIZzy38p6u1Bg==", "b41bbbfd-0ffa-4340-a113-68e22df073cc" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f87db91-6714-4c34-9ae8-1e1f5653e105", "AQAAAAIAAYagAAAAEAKkATielwmdfSdLDXpSpGqaZTCMsaRITZ8oFyhl3AeOZd7McOo7BFUZvUUt6EGicQ==", "13e31634-dcef-4f41-abdf-3d5f1ba2a673" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd9658b2-4ae1-49fb-9c0e-857d49a3e9e1", "AQAAAAIAAYagAAAAENV0JuE1gLRMqr0CupALxt/ASfc9yvh+JSg001ZbRTyEdLcV5nYoFyIYEmD5p/mLIg==", "8163e9db-6775-4af5-9ce2-e712d77c14a5" });

            migrationBuilder.CreateIndex(
                name: "IX_Room_AuthorId",
                table: "Room",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_ManagerId",
                table: "Room",
                column: "ManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69983061-69b7-4465-9b3e-360bec32faf8", "AQAAAAIAAYagAAAAEHLJL5k3OMNYkEwUpccm2HoklSieYXyFjyr95dVBRBWh0Tzd9mlwISKHGRCADDl39g==", "2104d509-e51a-49cc-a132-793fd5cda2aa" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0bfce671-f789-4b1d-967b-829b589b9db5", "AQAAAAIAAYagAAAAENvOpT3I8eRVc6KTBomCjALNdqRcHBzDhNwOmV10xo1CVfwZ0j7EuLqQbR61OV/MgQ==", "e78589ff-cf47-403a-b3b6-187a0ed976e4" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14e6b51e-42d5-49cf-a74d-741226b0621f", "AQAAAAIAAYagAAAAEGLlRHuObR2+56Qap0nnPKzLw09D2ALxyND+U2ZGzu3gEhMvecC1QHZOctUNhSS9mA==", "33514a27-6819-44b5-9701-be7023291fe1" });
        }
    }
}
