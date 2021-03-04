using Microsoft.EntityFrameworkCore.Migrations;

namespace FormCapture.Server.Migrations
{
    public partial class ProcessedFileTemplateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d3c5e3a-4dcc-419c-9297-98bfd5d2ae45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94af712e-b096-40a8-a4d1-44c937683990");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc640e30-4cdb-437f-b70a-bec2e1d43f19");

            migrationBuilder.AddColumn<string>(
                name: "TemplateID",
                table: "ProcessedFiles",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "TemplateID",
                table: "ProcessedFiles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "94af712e-b096-40a8-a4d1-44c937683990", "168b7619-6747-4268-aae7-6b1263252854", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cc640e30-4cdb-437f-b70a-bec2e1d43f19", "d6d38edd-ce3c-408e-82f1-42a546240066", "Workflow admin", "WORKFLOW ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d3c5e3a-4dcc-419c-9297-98bfd5d2ae45", "c66080ce-aa86-457a-a0d7-5752a2d11c51", "User", "USER" });
        }
    }
}
