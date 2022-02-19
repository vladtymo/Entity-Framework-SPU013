using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_Intro.Migrations
{
    public partial class AddFullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectWorker_Workers_WorkersId",
                table: "ProjectWorker");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Countries_CountryId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Departments_DepartmentNumber",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workers",
                table: "Workers");

            migrationBuilder.RenameTable(
                name: "Workers",
                newName: "Employees");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Employees",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_Workers_DepartmentNumber",
                table: "Employees",
                newName: "IX_Employees_DepartmentNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Workers_CountryId",
                table: "Employees",
                newName: "IX_Employees_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Countries_CountryId",
                table: "Employees",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentNumber",
                table: "Employees",
                column: "DepartmentNumber",
                principalTable: "Departments",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectWorker_Employees_WorkersId",
                table: "ProjectWorker",
                column: "WorkersId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Countries_CountryId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentNumber",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectWorker_Employees_WorkersId",
                table: "ProjectWorker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Workers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Workers",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Workers",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentNumber",
                table: "Workers",
                newName: "IX_Workers_DepartmentNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_CountryId",
                table: "Workers",
                newName: "IX_Workers_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workers",
                table: "Workers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectWorker_Workers_WorkersId",
                table: "ProjectWorker",
                column: "WorkersId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Countries_CountryId",
                table: "Workers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Departments_DepartmentNumber",
                table: "Workers",
                column: "DepartmentNumber",
                principalTable: "Departments",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
