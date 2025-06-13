using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDo.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "todo");

            migrationBuilder.EnsureSchema(
                name: "idenaatity");

            migrationBuilder.CreateTable(
                name: "TodoCategories",
                schema: "todo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "idenaatity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                schema: "todo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsDone = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todos_TodoCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "todo",
                        principalTable: "TodoCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "todo",
                table: "TodoCategories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("65104e88-8f0f-4e85-ad90-786104ad2b22"), new DateTime(2025, 6, 13, 12, 12, 53, 338, DateTimeKind.Utc).AddTicks(3431), "House", new DateTime(2025, 6, 13, 12, 12, 53, 338, DateTimeKind.Utc).AddTicks(3432), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("a1916263-7022-4f8f-afaf-385074521efe"), new DateTime(2025, 6, 13, 12, 12, 53, 338, DateTimeKind.Utc).AddTicks(3056), "Work", new DateTime(2025, 6, 13, 12, 12, 53, 338, DateTimeKind.Utc).AddTicks(3202), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c811b26d-b48d-4eaa-8ef4-7693bea5cd7f"), new DateTime(2025, 6, 13, 12, 12, 53, 338, DateTimeKind.Utc).AddTicks(3435), "Others", new DateTime(2025, 6, 13, 12, 12, 53, 338, DateTimeKind.Utc).AddTicks(3436), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("f98648b6-8d2c-499a-bc70-372ef54a9887"), new DateTime(2025, 6, 13, 12, 12, 53, 338, DateTimeKind.Utc).AddTicks(3434), "Pets", new DateTime(2025, 6, 13, 12, 12, 53, 338, DateTimeKind.Utc).AddTicks(3434), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_CategoryId",
                schema: "todo",
                table: "Todos",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_Title",
                schema: "todo",
                table: "Todos",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                schema: "idenaatity",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos",
                schema: "todo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "idenaatity");

            migrationBuilder.DropTable(
                name: "TodoCategories",
                schema: "todo");
        }
    }
}
