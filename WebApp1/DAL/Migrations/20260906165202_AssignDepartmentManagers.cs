using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AssignDepartmentManagers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "UPDATE Departments SET ManagerId = 1 WHERE Id = 1");

            migrationBuilder.Sql(
                "UPDATE Departments SET ManagerId = 2 WHERE Id = 2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "UPDATE Departments SET ManagerId = NULL WHERE Id IN (1, 2)");
        }
    }
}
