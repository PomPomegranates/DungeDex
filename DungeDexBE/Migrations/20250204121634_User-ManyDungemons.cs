using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DungeDexBE.Migrations
{
    /// <inheritdoc />
    public partial class UserManyDungemons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DungeMonIds",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DungeMonIds",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
