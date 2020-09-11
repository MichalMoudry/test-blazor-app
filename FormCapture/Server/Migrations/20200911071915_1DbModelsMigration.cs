using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormCapture.Server.Migrations
{
    public partial class _1DbModelsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    AppID = table.Column<string>(nullable: true),
                    MetadataID = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CaptureApplications",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true),
                    Locale = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaptureApplications", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CaptureAppWorkflows",
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
                    table.PrimaryKey("PK_CaptureAppWorkflows", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Metadata",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    EntityID = table.Column<string>(nullable: true),
                    DataKey = table.Column<string>(nullable: true),
                    DataValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metadata", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProcessedFiles",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Content = table.Column<byte[]>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    BatchID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessedFiles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Queue",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    AppID = table.Column<string>(nullable: true),
                    BatchID = table.Column<string>(nullable: true),
                    AppWorkflowTaskGroupID = table.Column<string>(nullable: true),
                    AppWorkflowID = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queue", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserApps",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(nullable: true),
                    ApplicationID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserApps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(nullable: true),
                    SettingKey = table.Column<string>(nullable: true),
                    SettingValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowGroups",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    AppWorkflowID = table.Column<string>(nullable: true),
                    WorkflowGroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowGroups", x => x.ID);
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

            migrationBuilder.CreateTable(
                name: "WorkflowTaskGrouping",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    AppWorkflowTaskID = table.Column<string>(nullable: true),
                    AppWorkflowTaskGroupID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowTaskGrouping", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowTasks",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    TaskName = table.Column<string>(nullable: true),
                    TaskContent = table.Column<byte[]>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowTasks", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropTable(
                name: "CaptureApplications");

            migrationBuilder.DropTable(
                name: "CaptureAppWorkflows");

            migrationBuilder.DropTable(
                name: "Metadata");

            migrationBuilder.DropTable(
                name: "ProcessedFiles");

            migrationBuilder.DropTable(
                name: "Queue");

            migrationBuilder.DropTable(
                name: "UserApps");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "WorkflowGroups");

            migrationBuilder.DropTable(
                name: "Workflows");

            migrationBuilder.DropTable(
                name: "WorkflowTaskGrouping");

            migrationBuilder.DropTable(
                name: "WorkflowTasks");
        }
    }
}
