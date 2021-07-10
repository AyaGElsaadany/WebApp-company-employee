using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_companies_CompanyId",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_CompanyId",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "employees");

            migrationBuilder.CreateIndex(
                name: "IX_employees_Company_ID",
                table: "employees",
                column: "Company_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_companies_Company_ID",
                table: "employees",
                column: "Company_ID",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_companies_Company_ID",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_Company_ID",
                table: "employees");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_CompanyId",
                table: "employees",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_companies_CompanyId",
                table: "employees",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
