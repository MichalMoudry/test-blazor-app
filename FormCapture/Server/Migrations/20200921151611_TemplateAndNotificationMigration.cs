using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormCapture.Server.Migrations
{
    public partial class TemplateAndNotificationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7efd6151-02b7-450f-880a-a97291d4036f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "869d53fb-bc6f-447b-80b8-7a13d0a20730");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf86a311-8140-45ee-825a-a633e6f31c41");

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsIdentifying = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Xposition = table.Column<int>(nullable: false),
                    Yposition = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    IsRead = table.Column<bool>(nullable: false),
                    RecipientID = table.Column<string>(nullable: true),
                    NotificationType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    AppID = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    Xdimension = table.Column<int>(nullable: false),
                    Ydimension = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e6905e7-77e8-440e-a246-d8e29547b39e", "e33aa306-ee74-4f6d-8d96-915d55588133", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f833ce42-f475-4ba7-9fed-48b13cf70cfd", "362fdbeb-c0fb-493d-94e3-81a5c130d5ea", "Workflow admin", "WORKFLOW ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ceb41c49-5bbb-41e5-9436-ea1df60bedc3", "7b239026-ecb3-4b24-a40f-3d28b2118a7f", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e6905e7-77e8-440e-a246-d8e29547b39e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ceb41c49-5bbb-41e5-9436-ea1df60bedc3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f833ce42-f475-4ba7-9fed-48b13cf70cfd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7efd6151-02b7-450f-880a-a97291d4036f", "a241d0b5-feaa-4214-ba58-f90f0eb71c83", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "869d53fb-bc6f-447b-80b8-7a13d0a20730", "8832b4b3-84b2-4bd9-9126-d24614562a9c", "Workflow admin", "WORKFLOW ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cf86a311-8140-45ee-825a-a633e6f31c41", "a32975dd-6dfe-4247-8fef-e3b6bbb38813", "User", "USER" });
        }
    }
}
