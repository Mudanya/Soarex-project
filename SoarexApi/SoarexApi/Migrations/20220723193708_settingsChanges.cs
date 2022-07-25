using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoarexApi.Migrations
{
    public partial class settingsChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeyAreasDescOne",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "KeyAreasDescThree",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "KeyAreasDescTwo",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "KeyAreasIconOne",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "KeyAreasIconThree",
                table: "Settings");

            migrationBuilder.RenameColumn(
                name: "KeyAreasIconTwo",
                table: "Settings",
                newName: "Slogan");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AH5E7",
                column: "ConcurrencyStamp",
                value: "a1f9704e-27d1-4786-a299-172791d68a99");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D22698A8-42D2-4115-9631-1C2D1E2AH5E7",
                column: "ConcurrencyStamp",
                value: "6e8f0c00-3ab5-4f6d-a8a8-960c4f9ccd82");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95B168FE-810B-432D-9010-233BA0B380E9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd4eceaa-7afc-4edf-aec2-8a5cac056fdb", "AQAAAAEAACcQAAAAENIoA5HpSDO7GUNSX9bT6mCEOodvCDIqRN/j3+Et+vZWZ7Ku1SzM9xTXLuzUnVnNKg==", "37b7da86-8da5-482b-ad38-57c7db7b11b9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Slogan",
                table: "Settings",
                newName: "KeyAreasIconTwo");

            migrationBuilder.AddColumn<string>(
                name: "KeyAreasDescOne",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyAreasDescThree",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyAreasDescTwo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyAreasIconOne",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyAreasIconThree",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AH5E7",
                column: "ConcurrencyStamp",
                value: "1afc43f6-d99e-4e9c-870d-acd278f9f805");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D22698A8-42D2-4115-9631-1C2D1E2AH5E7",
                column: "ConcurrencyStamp",
                value: "3c8fa508-51ec-4113-b919-d15718f1eb0c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95B168FE-810B-432D-9010-233BA0B380E9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7ea473c-b89a-4bf6-89e1-cee6f77647eb", "AQAAAAEAACcQAAAAEJO4ddot52Nh9vBPXaAl4EOHQoz1Y7TvQOcQPpJrKXYKekXSnss2Fbif8dy0BkUdlg==", "d6c204a2-9133-4e86-b0e4-9440d426b682" });
        }
    }
}
