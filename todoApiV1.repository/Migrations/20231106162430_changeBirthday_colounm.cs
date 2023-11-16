using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todoApiV1.repository.Migrations
{
    /// <inheritdoc />
    public partial class changeBirthday_colounm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "AppUsers",
                newName: "Birthday");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "AppUsers",
                newName: "Birthdate");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AppUsers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
