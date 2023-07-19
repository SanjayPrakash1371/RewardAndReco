using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RR.DataBaseConnect.Migrations
{
    /// <inheritdoc />
    public partial class EmailAddinEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailId",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Employee");
        }
    }
}
