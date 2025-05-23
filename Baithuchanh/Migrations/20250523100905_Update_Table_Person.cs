using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Baithuchanh.Migrations
{
    /// <inheritdoc />
    public partial class Update_Table_Person : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Person",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Person");
        }
    }
}
