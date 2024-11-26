using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HermanosK.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name" },
                values: new object[,]
                {
                    { 1, "Cliente" },
                    { 2, "Administrador" },
                    { 3, "Empleado" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "FirstName", "IsActive", "LastName", "PasswordHash", "RoleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 25, 5, 20, 39, 370, DateTimeKind.Local).AddTicks(6410), "cliente@hermanosk.com", "Usuario", true, "Cliente", "$2a$11$Gwh4zJjMZNBo46avO/gSVegStWe2DNrU3U8GYhw15yn2NvsdW/5Gu", 1 },
                    { 2, new DateTime(2024, 11, 25, 5, 20, 39, 370, DateTimeKind.Local).AddTicks(6445), "admin@hermanosk.com", "Usuario", true, "Administrador", "$2a$11$Gwh4zJjMZNBo46avO/gSVegStWe2DNrU3U8GYhw15yn2NvsdW/5Gu", 2 },
                    { 3, new DateTime(2024, 11, 25, 5, 20, 39, 370, DateTimeKind.Local).AddTicks(6449), "empleado@hermanosk.com", "Usuario", true, "Empleado", "$2a$11$Gwh4zJjMZNBo46avO/gSVegStWe2DNrU3U8GYhw15yn2NvsdW/5Gu", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
