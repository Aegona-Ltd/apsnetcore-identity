using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthSystem.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fd14937-2e8d-4c23-b365-0c2f08457436");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb292b75-6b9d-4112-a69a-e18c48e1d1c6");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "27bdc01b-0d34-4a2d-bf00-a9daa9ba1887");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fb292b75-6b9d-4112-a69a-e18c48e1d1c6", "53122db6-ca89-49ed-b47e-e5b11eeefec9", "UserCreate", "USERCREATE" },
                    { "5fd14937-2e8d-4c23-b365-0c2f08457436", "e7a1cac6-8ad9-409e-8423-def39ff67909", "UserList", "USERLIST" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAED2EbtjkwpEaQTSKRMmsFd7wAgbtAx1qWQHEAVzTEgHaG8tIw5pGxOnsdwl52ka7eQ==");
        }
    }
}
