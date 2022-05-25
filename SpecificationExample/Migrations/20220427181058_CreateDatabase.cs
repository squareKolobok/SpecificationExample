using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpecificationExample.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AuthorId",
                table: "Tasks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks",
                column: "StatusId");

            migrationBuilder.InsertData("Statuses", new string[] { "Id", "Name" },  new object[] { 1, "Инициировано" });
            migrationBuilder.InsertData("Statuses", new string[] { "Id", "Name" },  new object[] { 2, "В работе" });
            migrationBuilder.InsertData("Statuses", new string[] { "Id", "Name" },  new object[] { 3, "Выполнено" });
            migrationBuilder.InsertData("Statuses", new string[] { "Id", "Name" },  new object[] { 4, "Отменено" });

            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 1, "Super admin", DateTime.Now.AddDays(-40), DateTime.Now.AddDays(-5) });
            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 2, "Reserve super admin", DateTime.Now.AddDays(-40), DateTime.Now.AddDays(-10) });
            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 3, "admin 1", DateTime.Now.AddDays(-40), DateTime.Now.AddDays(-30) });
            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 4, "admin 2", DateTime.Now.AddDays(-40), DateTime.Now.AddDays(-30) });
            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 5, "admin 3", DateTime.Now.AddDays(-40), DateTime.Now.AddDays(-30) });
            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 6, "admin 4", DateTime.Now.AddDays(-40), DateTime.Now.AddDays(-30) });
            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 7, "admin 5", DateTime.Now.AddDays(-40), DateTime.Now.AddDays(-30) });
            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 8, "admin 6", DateTime.Now.AddDays(-40), DateTime.Now.AddDays(-30) });
            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 9, "admin 7", DateTime.Now.AddDays(-40), DateTime.Now.AddDays(-30) });
            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 10, "admin 8", DateTime.Now.AddDays(-40), DateTime.Now.AddDays(-30) });
            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 11, "Simple admin 1", DateTime.Now, DateTime.Now });
            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 13, "Simple admin 2", DateTime.Now, DateTime.Now });
            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 14, "Simple admin 3", DateTime.Now, DateTime.Now });
            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 15, "Simple admin 4", DateTime.Now, DateTime.Now });
            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 16, "Simple admin 5", DateTime.Now, DateTime.Now });
            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 17, "Simple admin 6", DateTime.Now, DateTime.Now });
            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 18, "Simple admin 7", DateTime.Now, DateTime.Now });
            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 12, "Simple admin 8", DateTime.Now, DateTime.Now });
            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 19, "Simple admin 9", DateTime.Now, DateTime.Now });
            migrationBuilder.InsertData("Users", new string[] { "Id", "Name", "DateCreate", "DateUpdate" },  new object[] { 20, "Admin Vasya", DateTime.Now, DateTime.Now });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
