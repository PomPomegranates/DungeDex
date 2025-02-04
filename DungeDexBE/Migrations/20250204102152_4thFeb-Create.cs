using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DungeDexBE.Migrations
{
    /// <inheritdoc />
    public partial class _4thFebCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonsterDb_User_UserId",
                table: "MonsterDb");

            migrationBuilder.DropTable(
                name: "MonsterSpell");

            migrationBuilder.AddColumn<string>(
                name: "DungeMonIds",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MonsterDb",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DungeMonSpell",
                columns: table => new
                {
                    MonstersId = table.Column<int>(type: "int", nullable: false),
                    SpellsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DungeMonSpell", x => new { x.MonstersId, x.SpellsId });
                    table.ForeignKey(
                        name: "FK_DungeMonSpell_MonsterDb_MonstersId",
                        column: x => x.MonstersId,
                        principalTable: "MonsterDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DungeMonSpell_SpellTable_SpellsId",
                        column: x => x.SpellsId,
                        principalTable: "SpellTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DungeMonSpell_SpellsId",
                table: "DungeMonSpell",
                column: "SpellsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonsterDb_User_UserId",
                table: "MonsterDb",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonsterDb_User_UserId",
                table: "MonsterDb");

            migrationBuilder.DropTable(
                name: "DungeMonSpell");

            migrationBuilder.DropColumn(
                name: "DungeMonIds",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MonsterDb",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "MonsterSpell",
                columns: table => new
                {
                    MonstersId = table.Column<int>(type: "int", nullable: false),
                    SpellsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterSpell", x => new { x.MonstersId, x.SpellsId });
                    table.ForeignKey(
                        name: "FK_MonsterSpell_MonsterDb_MonstersId",
                        column: x => x.MonstersId,
                        principalTable: "MonsterDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonsterSpell_SpellTable_SpellsId",
                        column: x => x.SpellsId,
                        principalTable: "SpellTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonsterSpell_SpellsId",
                table: "MonsterSpell",
                column: "SpellsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonsterDb_User_UserId",
                table: "MonsterDb",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
