using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthSystem.Migrations.ApplicationDb
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartments_DepartmentId",
                table: "EmployeeDepartments",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDepartments_Departments_DepartmentId",
                table: "EmployeeDepartments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDepartments_Employees_EmployeeId",
                table: "EmployeeDepartments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartments_Departments_DepartmentId",
                table: "EmployeeDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartments_Employees_EmployeeId",
                table: "EmployeeDepartments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDepartments_DepartmentId",
                table: "EmployeeDepartments");
        }
    }
}
