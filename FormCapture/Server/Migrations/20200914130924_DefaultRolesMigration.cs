using Microsoft.EntityFrameworkCore.Migrations;

namespace FormCapture.Server.Migrations
{
    public partial class DefaultRolesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca33bf04-e2be-4109-84e7-3b80a7a3b4f6", "decb94b1-ee95-4bc0-8152-b5a809b67204", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "46e796d4-b577-4e4f-a242-ab2810c48e27", "6e8a9a55-a968-4a5c-bc85-f40e51545a99", "Workflow admin", "WORKFLOW ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e0358fb-5eae-4919-ba85-fd6716c9efb0", "801f808d-cce7-40cf-9081-5c614a8ca221", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46e796d4-b577-4e4f-a242-ab2810c48e27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e0358fb-5eae-4919-ba85-fd6716c9efb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca33bf04-e2be-4109-84e7-3b80a7a3b4f6");
        }
    }
}
