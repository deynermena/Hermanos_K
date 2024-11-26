using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HermanosK.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneNumberToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PhoneNumber" },
                values: new object[] { new DateTime(2024, 11, 25, 22, 42, 29, 971, DateTimeKind.Local).AddTicks(2373), "$2a$11$kPEGUg.NGMpqJyc3XTmW/OCZ0aNfuI5VWeVP5VFO8YONeQqAw5eCG", "123456789" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "PhoneNumber" },
                values: new object[] { new DateTime(2024, 11, 25, 22, 42, 29, 971, DateTimeKind.Local).AddTicks(2474), "$2a$11$kPEGUg.NGMpqJyc3XTmW/OCZ0aNfuI5VWeVP5VFO8YONeQqAw5eCG", "123456789" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "PhoneNumber" },
                values: new object[] { new DateTime(2024, 11, 25, 22, 42, 29, 971, DateTimeKind.Local).AddTicks(2480), "$2a$11$kPEGUg.NGMpqJyc3XTmW/OCZ0aNfuI5VWeVP5VFO8YONeQqAw5eCG", "123456789" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 11, 25, 5, 20, 39, 370, DateTimeKind.Local).AddTicks(6410), "$2a$11$Gwh4zJjMZNBo46avO/gSVegStWe2DNrU3U8GYhw15yn2NvsdW/5Gu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 11, 25, 5, 20, 39, 370, DateTimeKind.Local).AddTicks(6445), "$2a$11$Gwh4zJjMZNBo46avO/gSVegStWe2DNrU3U8GYhw15yn2NvsdW/5Gu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 11, 25, 5, 20, 39, 370, DateTimeKind.Local).AddTicks(6449), "$2a$11$Gwh4zJjMZNBo46avO/gSVegStWe2DNrU3U8GYhw15yn2NvsdW/5Gu" });
        }
    }
}
