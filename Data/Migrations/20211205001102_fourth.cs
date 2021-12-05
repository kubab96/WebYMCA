using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebYMCA.Data.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "YMCA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "YMCA",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
