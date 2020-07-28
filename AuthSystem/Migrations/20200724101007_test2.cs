using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthSystem.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0438b96b-cda3-46dd-b746-288cfd6796ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b037d832-161a-4710-9695-d738e158d62f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "b6283755-6857-41a4-aa52-0744a805de35");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "de1be586-8ecc-456d-b06c-68dce1a8508e", "7c337dbc-86ee-43c1-9861-609ec4a205ed", "UserCreate", "USERCREATE" },
                    { "25b8d776-4db0-4354-8ad0-6314652f0370", "06540ec0-23ad-4e27-8936-8ecdf83dd733", "UserList", "USERLIST" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEN7ppbJuC55M5adCOLDDJlEWAxn/dRuswPD33IBO/IqVy9gaU76BaFn/9sSlRy+vbA==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25b8d776-4db0-4354-8ad0-6314652f0370");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de1be586-8ecc-456d-b06c-68dce1a8508e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "fa22a9ef-7774-4b36-99e4-16ac2cc2643f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b037d832-161a-4710-9695-d738e158d62f", "6d65ed05-974f-4c8e-9344-99aa67e31454", "UserCreate", "USERCREATE" },
                    { "0438b96b-cda3-46dd-b746-288cfd6796ec", "50091e84-18d4-445e-8a6e-379f4aac9729", "UserList", "USERLIST" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBVlfNkHc2XIYowdUAyBsXAeqwS6x59ABZaStwAb89zIDUBOaDQEc/SyK3YX5zaWrA==");
        }
    }
}
