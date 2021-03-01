using Microsoft.EntityFrameworkCore.Migrations;

namespace FormCapture.Server.Migrations
{
    public partial class QueueWorkflowIdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05d537cd-0d5a-4af0-b939-6c1147da7d22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d75db4e-f192-4093-9720-4012803ebd5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80cf0060-15a0-48b1-abdb-d3477bf590c1");

            migrationBuilder.AddColumn<string>(
                name: "WorkflowID",
                table: "Queue",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a471c618-1573-4ef5-b963-d2e3b24da2bb", "e13a3e9d-036b-48b1-b875-5b2e42bdee04", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cc6fe928-69c2-4214-80f6-c5ed323bef95", "985af968-5b73-4cd1-9883-e2b08c511714", "Workflow admin", "WORKFLOW ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "22f54eb2-563f-4a7a-9197-2d79b420ada8", "43fd0329-9f63-49b7-9341-443bb81305da", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22f54eb2-563f-4a7a-9197-2d79b420ada8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a471c618-1573-4ef5-b963-d2e3b24da2bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc6fe928-69c2-4214-80f6-c5ed323bef95");

            migrationBuilder.DropColumn(
                name: "WorkflowID",
                table: "Queue");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80cf0060-15a0-48b1-abdb-d3477bf590c1", "06c557bd-3f50-4660-bfcf-dd836e822557", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "05d537cd-0d5a-4af0-b939-6c1147da7d22", "f06053fd-8885-4655-a5de-3167f4fa04e7", "Workflow admin", "WORKFLOW ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4d75db4e-f192-4093-9720-4012803ebd5c", "e24bd948-a4f7-4ce7-8f29-1cc97c5e56a9", "User", "USER" });
        }
    }
}
