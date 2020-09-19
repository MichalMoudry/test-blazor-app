using Microsoft.EntityFrameworkCore.Migrations;

namespace FormCapture.Server.Migrations
{
    public partial class WorkflowIDMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69d93057-25bd-46d0-8ccf-93eb5869e24e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "819be047-5640-4f5a-b34d-2de279b0ff2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cd777ff-0c8f-4e72-9505-3b2ed5367f76");

            migrationBuilder.AddColumn<string>(
                name: "WorkflowID",
                table: "TaskGroupings",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "WorkflowID",
                table: "TaskGroupings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "819be047-5640-4f5a-b34d-2de279b0ff2b", "8a7ff5d9-c0c9-4427-a3f3-c3b6d0ebd4bc", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "69d93057-25bd-46d0-8ccf-93eb5869e24e", "261bd49c-7a22-4e3b-8fb9-881c29ed5669", "Workflow admin", "WORKFLOW ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9cd777ff-0c8f-4e72-9505-3b2ed5367f76", "32e31626-f587-4bc8-bef6-4607439e2182", "User", "USER" });
        }
    }
}
