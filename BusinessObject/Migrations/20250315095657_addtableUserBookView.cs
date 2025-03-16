using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addtableUserBookView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
