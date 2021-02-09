using Microsoft.EntityFrameworkCore.Migrations;

namespace FormCapture.Server.Migrations
{
    public partial class TemplateNameMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "AppWorkflowID",
                table: "Queue");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Fields");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Templates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TemplateID",
                table: "Fields",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "508ee666-8db6-4497-b4f8-392c7e28c697", "7716943c-3a72-4923-86d9-14b9ef50a697", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e4710103-9f64-4519-aef3-74c6dd798241", "ef3069a7-a345-415d-9bd4-6fbca37bd2d9", "Workflow admin", "WORKFLOW ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99d6bb28-e067-4dd4-9436-098c79dd8fdf", "d4685a84-cb5b-4176-adf7-3a4694fb2d7b", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "508ee666-8db6-4497-b4f8-392c7e28c697");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99d6bb28-e067-4dd4-9436-098c79dd8fdf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4710103-9f64-4519-aef3-74c6dd798241");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "TemplateID",
                table: "Fields");

            migrationBuilder.AddColumn<string>(
                name: "AppWorkflowID",
                table: "Queue",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Fields",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
