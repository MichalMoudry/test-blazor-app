using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormCapture.Server.Migrations
{
    public partial class FieldValueMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0715c76a-8d0f-4073-b591-b4d7a45a1daa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c71748c-8d9a-4938-9a59-164f7468012d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9e4759a-1481-4dfa-85c1-5f081fce1c0d");

            migrationBuilder.AlterColumn<string>(
                name: "AppWorkflowTaskGroupID",
                table: "Queue",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FieldValues",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FieldID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Added = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldValues", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0dedd2ad-b8d1-45ee-852d-793dc9c40f54", "c72335e8-f02a-4f78-9a42-32fc966ad4c3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e596e738-7c4d-46cc-9311-c4665ec5ae3e", "accdb1d3-0dd2-4bd3-95be-29aa73519d8f", "Workflow admin", "WORKFLOW ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51d5167c-52ce-4011-9f88-531a7f1bcbce", "e481501c-cce5-41da-acd5-45ff091ff0fe", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldValues");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dedd2ad-b8d1-45ee-852d-793dc9c40f54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51d5167c-52ce-4011-9f88-531a7f1bcbce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e596e738-7c4d-46cc-9311-c4665ec5ae3e");

            migrationBuilder.AlterColumn<string>(
                name: "AppWorkflowTaskGroupID",
                table: "Queue",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c71748c-8d9a-4938-9a59-164f7468012d", "cb02ee15-d45a-4e58-bb20-c53cd5024517", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9e4759a-1481-4dfa-85c1-5f081fce1c0d", "d6070ad7-f6ff-4abd-8a64-b8354826754d", "Workflow admin", "WORKFLOW ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0715c76a-8d0f-4073-b591-b4d7a45a1daa", "b0ab7a2b-f500-42c5-9eed-87f56ae5cffd", "User", "USER" });
        }
    }
}
