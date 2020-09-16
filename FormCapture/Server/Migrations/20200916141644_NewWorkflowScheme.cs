using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormCapture.Server.Migrations
{
    public partial class NewWorkflowScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0201d451-b504-4ac1-a2e0-9979bf8387f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "954c33d8-a328-42bf-9884-8c0605b6aaf0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf8e15e1-2943-414d-a019-ce8daae57c6b");

            migrationBuilder.CreateTable(
                name: "TaskGroupings",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    TaskID = table.Column<string>(nullable: true),
                    TaskGroupName = table.Column<string>(nullable: true),
                    ExecutionOrderNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskGroupings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Workflows",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflows", x => x.ID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskGroupings");

            migrationBuilder.DropTable(
                name: "Workflows");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0201d451-b504-4ac1-a2e0-9979bf8387f7", "fadbd83f-e10e-4d9a-9930-75f8b123afa1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf8e15e1-2943-414d-a019-ce8daae57c6b", "c502c267-f0df-4577-8c24-0daa9104de6a", "Workflow admin", "WORKFLOW ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "954c33d8-a328-42bf-9884-8c0605b6aaf0", "904df24a-5968-462f-928f-e7be46203956", "User", "USER" });
        }
    }
}
