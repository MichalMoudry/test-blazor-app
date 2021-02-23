using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormCapture.Server.Migrations
{
    public partial class TaskParameterMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "WorkflowTaskParameters",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParameterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParemeterValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Added = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowTaskParameters", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dee74948-a790-4efe-9f67-900a368af4a3", "ebd57bec-6dc7-451e-a88f-836015e9e286", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3ac7a716-ef60-4400-95d5-4f022e2d53fd", "76314490-e5fe-4ed2-b89f-51633eb72aa5", "Workflow admin", "WORKFLOW ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "60c12a3f-d7bc-4fcd-a1a6-2cb4409fdf72", "5b3db097-5c5a-444f-8ff2-2b8ce7eb6456", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkflowTaskParameters");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ac7a716-ef60-4400-95d5-4f022e2d53fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60c12a3f-d7bc-4fcd-a1a6-2cb4409fdf72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dee74948-a790-4efe-9f67-900a368af4a3");

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
    }
}
