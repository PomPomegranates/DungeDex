using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DungeDexBE.Migrations
{
	/// <inheritdoc />
	public partial class InitialCreate : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "SpellTable",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SpellTable", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "User",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_User", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "MonsterDb",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserId = table.Column<int>(type: "int", nullable: true),
					BasePokemon = table.Column<string>(type: "nvarchar(max)", nullable: false),
					NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ChallengeRating = table.Column<float>(type: "real", nullable: false),
					ArmorClass = table.Column<int>(type: "int", nullable: false),
					Strength = table.Column<int>(type: "int", nullable: false),
					Dexterity = table.Column<int>(type: "int", nullable: false),
					Constitution = table.Column<int>(type: "int", nullable: false),
					Intelligence = table.Column<int>(type: "int", nullable: false),
					Wisdom = table.Column<int>(type: "int", nullable: false),
					Charisma = table.Column<int>(type: "int", nullable: false),
					HitPoints = table.Column<int>(type: "int", nullable: false),
					ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_MonsterDb", x => x.Id);
					table.ForeignKey(
						name: "FK_MonsterDb_User_UserId",
						column: x => x.UserId,
						principalTable: "User",
						principalColumn: "Id");
				});

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
				name: "IX_MonsterDb_UserId",
				table: "MonsterDb",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_MonsterSpell_SpellsId",
				table: "MonsterSpell",
				column: "SpellsId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "MonsterSpell");

			migrationBuilder.DropTable(
				name: "MonsterDb");

			migrationBuilder.DropTable(
				name: "SpellTable");

			migrationBuilder.DropTable(
				name: "User");
		}
	}
}
