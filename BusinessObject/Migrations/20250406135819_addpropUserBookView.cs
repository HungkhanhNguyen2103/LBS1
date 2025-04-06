using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addpropUserBookView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "UserBookView",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookTypeStatus",
                table: "UserBookView",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "UserBookView",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "577debc7-1f51-484e-93a0-a4d1e0d755e4", "AQAAAAIAAYagAAAAEMNG78AI0MQ2OQDvPqaZ5ngrlQqVeGLVsoqhxDPirPJqYfN1y88lF0FmjgWlCHHvfA==", "73bde1a6-1edb-46e1-a234-b1944001304e" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2bda635a-eaf4-4585-976a-45907a7caf20", "AQAAAAIAAYagAAAAEPqjcEYKqGdbyP/Fqcg6MKJX7Z6D44frdt1sMhHibmZ+fZj08KfihsSUB/CHgyBeKw==", "0d3ee7b4-575f-45d6-8866-79e934eccba8" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf64ab82-3247-4cb0-953b-c16d9ec13ead", "AQAAAAIAAYagAAAAEKd/I1ar7UJfP7Vb64J99gx7n2DrNNpeMdYFHRxIvIdvOyX/+Rqn/P8cPZ5SEpweeg==", "73fcf1fe-91c5-4e14-b25d-56726b672e61" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookId",
                table: "UserBookView");

            migrationBuilder.DropColumn(
                name: "BookTypeStatus",
                table: "UserBookView");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserBookView");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9810ead-2881-4ab2-b6aa-7d4e4b39279b", "AQAAAAIAAYagAAAAEBzkl3yxInVYutyZle7pxJAnt6BTjxjUmLZDc43XK5AEAz+Ys+hpX3n7Mc9lwogq0g==", "a84dadab-9f38-486f-966c-7e0f48f12695" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fab1a5d-e858-4e7c-a7cc-91fa9525c6f1", "AQAAAAIAAYagAAAAEMNIY4NEZum0Hv7QRdtMMP0wOmapYXyqKaqVv/88NY9h0+6voQ4vC34Ah80J2QKE4g==", "b9778793-fa99-406b-b9b5-b5a947f51a21" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75af1219-3c16-4806-9171-eafc188a5a58", "AQAAAAIAAYagAAAAEPTIhzZ5DbnumDDwMBL37Z/mXHeYxTKvthE/KXAxoGT0GmAFbTDv6rJXBKwLcl6zaQ==", "64ac4684-1e6e-457a-9e2b-9ef10db7dfa3" });
        }
    }
}
