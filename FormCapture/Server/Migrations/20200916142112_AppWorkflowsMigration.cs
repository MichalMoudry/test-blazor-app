using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormCapture.Server.Migrations
{
    public partial class AppWorkflowsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "287dce48-ac0a-4df8-ab23-178c5f2360e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e34f3da-d077-4023-8126-3440431ec8e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ecfc24e-39f1-4dad-b075-0d4044d37ad5");

            migrationBuilder.CreateTable(
                name: "AppWorkflows",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    AppID = table.Column<string>(nullable: true),
                    WorkflowID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppWorkflows", x => x.ID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppWorkflows");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "287dce48-ac0a-4df8-ab23-178c5f2360e8", "cf0a8f00-58cf-4507-bb07-f8844b735310", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e34f3da-d077-4023-8126-3440431ec8e8", "9a6d931e-d5d3-4f64-a10d-f8a13342401c", "Workflow admin", "WORKFLOW ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ecfc24e-39f1-4dad-b075-0d4044d37ad5", "be8be711-4780-423b-8036-f397a215f657", "User", "USER" });
        }
    }
}
