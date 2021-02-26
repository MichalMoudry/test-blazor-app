using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormCapture.Server.Migrations
{
    public partial class RemoveBatchAndMetadata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropTable(
                name: "Metadata");

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

            migrationBuilder.DropColumn(
                name: "BatchID",
                table: "Queue");

            migrationBuilder.RenameColumn(
                name: "BatchID",
                table: "ProcessedFiles",
                newName: "QueueID");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8d77ed8-436e-4cb0-890e-643cafea03c5", "07963233-8ca6-4dbb-b97f-2d001bc31137", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3200c86-eb4e-4fa0-81d0-6179ddf404d6", "fa916dd7-0b67-4699-94c4-34d7790ce986", "Workflow admin", "WORKFLOW ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e4a6bcd-d7dd-4afe-b501-cc0f45ed0b14", "9100cf84-e7d4-450c-a868-a96bc26ad1f6", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e4a6bcd-d7dd-4afe-b501-cc0f45ed0b14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3200c86-eb4e-4fa0-81d0-6179ddf404d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8d77ed8-436e-4cb0-890e-643cafea03c5");

            migrationBuilder.RenameColumn(
                name: "QueueID",
                table: "ProcessedFiles",
                newName: "BatchID");

            migrationBuilder.AddColumn<string>(
                name: "BatchID",
                table: "Queue",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Added = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetadataID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Metadata",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Added = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metadata", x => x.ID);
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
    }
}
