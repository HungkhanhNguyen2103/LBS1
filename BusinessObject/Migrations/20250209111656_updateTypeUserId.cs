using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class updateTypeUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Account_UserId1",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Account_UserId1",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBook_Account_UserId1",
                table: "UserBook");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTranscation_Account_UserId1",
                table: "UserTranscation");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTranscationBook_Account_UserId1",
                table: "UserTranscationBook");

            migrationBuilder.DropIndex(
                name: "IX_UserTranscationBook_UserId1",
                table: "UserTranscationBook");

            migrationBuilder.DropIndex(
                name: "IX_UserTranscation_UserId1",
                table: "UserTranscation");

            migrationBuilder.DropIndex(
                name: "IX_UserBook_UserId1",
                table: "UserBook");

            migrationBuilder.DropIndex(
                name: "IX_Comment_UserId1",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Book_UserId1",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserTranscationBook");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserTranscation");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserBook");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Book");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserTranscationBook",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserTranscation",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserBook",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Book",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a9c9e70-254e-41ea-a7f0-6e3c3de08c04", "AQAAAAIAAYagAAAAEP8KHk2FcqreH0McypjIruA+htPsKosV/T554g2ulWS2s7AHiw3C3VSCTcvjb0lMFQ==", "d1fcb8fd-5171-4e24-9830-769823a0af90" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff321ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0d569df-21b4-40b6-be39-2dee2b57b61a", "AQAAAAIAAYagAAAAEAfHQcQxvOLgmAS9BVaYT8PWLGzeq51p8aj6LARTi1ASHOk+Yr04ECDK7jmCAYfGFA==", "7136313d-1cc3-4732-937d-534efba986ad" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTranscationBook_UserId",
                table: "UserTranscationBook",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTranscation_UserId",
                table: "UserTranscation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBook_UserId",
                table: "UserBook",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_UserId",
                table: "Book",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Account_UserId",
                table: "Book",
                column: "UserId",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Account_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBook_Account_UserId",
                table: "UserBook",
                column: "UserId",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTranscation_Account_UserId",
                table: "UserTranscation",
                column: "UserId",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTranscationBook_Account_UserId",
                table: "UserTranscationBook",
                column: "UserId",
                principalTable: "Account",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Account_UserId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Account_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBook_Account_UserId",
                table: "UserBook");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTranscation_Account_UserId",
                table: "UserTranscation");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTranscationBook_Account_UserId",
                table: "UserTranscationBook");

            migrationBuilder.DropIndex(
                name: "IX_UserTranscationBook_UserId",
                table: "UserTranscationBook");

            migrationBuilder.DropIndex(
                name: "IX_UserTranscation_UserId",
                table: "UserTranscation");

            migrationBuilder.DropIndex(
                name: "IX_UserBook_UserId",
                table: "UserBook");

            migrationBuilder.DropIndex(
                name: "IX_Comment_UserId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Book_UserId",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserTranscationBook",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserTranscationBook",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserTranscation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserTranscation",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserBook",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserBook",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Book",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c920fb4b-bd51-4091-a626-07da1a5446d5", "AQAAAAIAAYagAAAAECb5CWcjNkAamnwPOoQimbLScXASvfLeJxAlYQ5quDTtw2ca9vVA+SMQfYSH2vYo+w==", "1276ab23-c7be-4eed-b7e3-79cffadccfb5" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff321ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8ee5f9e-a1ac-4f44-a459-aa7c6dec0f9b", "AQAAAAIAAYagAAAAEMNQnoogZjdWCWI7mux8v7Yd47QR+66re/KYO2RMTutygvlGVWVrKSbLwOhiTQKkIg==", "13e08c21-9fc3-46ec-952c-89721af7774e" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTranscationBook_UserId1",
                table: "UserTranscationBook",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserTranscation_UserId1",
                table: "UserTranscation",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserBook_UserId1",
                table: "UserBook",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId1",
                table: "Comment",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Book_UserId1",
                table: "Book",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Account_UserId1",
                table: "Book",
                column: "UserId1",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Account_UserId1",
                table: "Comment",
                column: "UserId1",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBook_Account_UserId1",
                table: "UserBook",
                column: "UserId1",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTranscation_Account_UserId1",
                table: "UserTranscation",
                column: "UserId1",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTranscationBook_Account_UserId1",
                table: "UserTranscationBook",
                column: "UserId1",
                principalTable: "Account",
                principalColumn: "Id");
        }
    }
}
