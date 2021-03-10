using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormCapture.Server.Migrations
{
    public partial class RemoveTaskParameterMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkflowTaskParameters");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6af0db32-a52f-41b5-9c33-3baa7e694bf4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93270bf8-ccde-424e-985a-6ea1f649ac60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1748457-c2ec-4d9f-b694-ea4df968ef9c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9caceb62-daa6-4b05-b86f-fea8d75b5fed", "6b1d5f51-06b6-4a35-890a-9c676f4ab9b2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "35d506e5-eac8-43f2-b9c9-1579a2c0eed4", "caac2965-3d9a-4517-8891-b306bb06155c", "Workflow admin", "WORKFLOW ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62424096-b925-4052-9a28-4c8d9ccbf7c5", "39eb3f90-7ecc-499e-9c05-648038e809a6", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35d506e5-eac8-43f2-b9c9-1579a2c0eed4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62424096-b925-4052-9a28-4c8d9ccbf7c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9caceb62-daa6-4b05-b86f-fea8d75b5fed");

            migrationBuilder.CreateTable(
                name: "WorkflowTaskParameters",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Added = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParameterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParemeterValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowTaskParameters", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93270bf8-ccde-424e-985a-6ea1f649ac60", "d1147979-0b73-4fce-a283-15534e7af9f3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b1748457-c2ec-4d9f-b694-ea4df968ef9c", "793196b7-eac8-49f6-9cfb-021268fa4f30", "Workflow admin", "WORKFLOW ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6af0db32-a52f-41b5-9c33-3baa7e694bf4", "d48cb3ea-0f63-4889-9e03-7edaef8144ff", "User", "USER" });
        }
    }
}
