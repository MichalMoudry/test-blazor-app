using Microsoft.EntityFrameworkCore.Migrations;

namespace FormCapture.Server.Migrations
{
    public partial class AppWorkflowsNameMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "WorkflowName",
                table: "AppWorkflows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ebc42164-f91b-4783-a0bb-2bec40508007", "50108c8c-78b1-4b42-9a4c-5aae7d659de0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "605b31bd-e16b-4af4-b646-c39f1cc0526f", "0b3f8067-62c5-4e5e-bc3f-5a8c4a158ff6", "Workflow admin", "WORKFLOW ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2047d2a4-6596-4eaf-83e5-a97887851d57", "48c793b4-ca43-490c-b1c1-259482b3fcf0", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2047d2a4-6596-4eaf-83e5-a97887851d57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "605b31bd-e16b-4af4-b646-c39f1cc0526f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebc42164-f91b-4783-a0bb-2bec40508007");

            migrationBuilder.DropColumn(
                name: "WorkflowName",
                table: "AppWorkflows");

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
    }
}
