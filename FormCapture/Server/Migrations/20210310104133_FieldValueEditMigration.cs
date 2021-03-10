using Microsoft.EntityFrameworkCore.Migrations;

namespace FormCapture.Server.Migrations
{
    public partial class FieldValueEditMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "FieldName",
                table: "FieldValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileID",
                table: "FieldValues",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "FieldName",
                table: "FieldValues");

            migrationBuilder.DropColumn(
                name: "FileID",
                table: "FieldValues");

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
    }
}
