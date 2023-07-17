using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RR.DataBaseConnect.Migrations
{
    /// <inheritdoc />
    public partial class Monda1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRoles_Employee_EmployeeId",
                table: "EmployeeRoles");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeRoles_EmployeeId",
                table: "EmployeeRoles");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "EmployeeRoles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId1",
                table: "EmployeeRoles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_EmployeeId1",
                table: "EmployeeRoles",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRoles_Employee_EmployeeId1",
                table: "EmployeeRoles",
                column: "EmployeeId1",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRoles_Employee_EmployeeId1",
                table: "EmployeeRoles");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeRoles_EmployeeId1",
                table: "EmployeeRoles");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "EmployeeRoles");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeRoles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_EmployeeId",
                table: "EmployeeRoles",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRoles_Employee_EmployeeId",
                table: "EmployeeRoles",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
