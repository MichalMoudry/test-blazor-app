using Microsoft.EntityFrameworkCore.Migrations;

namespace FormCapture.Server.Migrations
{
    public partial class FieldExpectedValueMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ExpectedValue",
                table: "Fields",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ExpectedValue",
                table: "Fields");

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
    }
}
