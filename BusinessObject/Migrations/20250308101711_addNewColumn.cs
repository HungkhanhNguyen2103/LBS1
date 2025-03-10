using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addNewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b98020aa-d12e-413a-9bbc-d63fb320eee8", "AQAAAAIAAYagAAAAEI8BMZHw4sgRNArauD6A3+rc9lKQG2+D5rQ1HkCsuPOUQ0pn6VVSooEUhv0oZcn86A==", "a6e146f1-3c39-45df-9b57-ff576fcfe04f" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "418b9be0-3b86-4cc8-9b38-e12daede6095", "AQAAAAIAAYagAAAAECkDKxMEjbyO5qEDhwSxehzws2q/p3kI9dNAXdyw5UkFvU3AH5d/FHQJ3M1sFUjDHA==", "5cb1758a-dd51-4e9b-bd9a-3084055c36dd" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3802a33b-1354-401a-8c17-9129566ec51e", "AQAAAAIAAYagAAAAEEG7AVlp9r0ii0PuFREoEd7+w8PmD1B6qvTPGHT7i4EVk2gN/VW2PNo/b+DhvhkX+Q==", "1fb1771d-45d3-4b91-90a8-35cac14eee8c" });
        }
    }
}
