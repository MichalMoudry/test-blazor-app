using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormCapture.Server.Migrations
{
    public partial class TaskDescriptionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaptureAppWorkflows");

            migrationBuilder.DropTable(
                name: "WorkflowGroups");

            migrationBuilder.DropTable(
                name: "Workflows");

            migrationBuilder.DropTable(
                name: "WorkflowTaskGrouping");

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

            migrationBuilder.DropColumn(
                name: "TaskContent",
                table: "WorkflowTasks");

            migrationBuilder.DropColumn(
                name: "TaskName",
                table: "WorkflowTasks");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "WorkflowTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WorkflowTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WorkflowTasks",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Content",
                table: "WorkflowTasks");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "WorkflowTasks");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "WorkflowTasks");

            migrationBuilder.AddColumn<byte[]>(
                name: "TaskContent",
                table: "WorkflowTasks",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaskName",
                table: "WorkflowTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CaptureAppWorkflows",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Added = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkflowID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaptureAppWorkflows", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowGroups",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Added = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppWorkflowID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkflowGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowGroups", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Workflows",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Added = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflows", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowTaskGrouping",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Added = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppWorkflowTaskGroupID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppWorkflowTaskID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowTaskGrouping", x => x.ID);
                });

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
    }
}
