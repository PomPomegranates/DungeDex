using DungeDexBE.Models;

namespace DungeDexBE.ConversionFunctions
{
	public static class Convert
	{
		public static Dungemon ToMonster(this Pokemon pokemon)
		{

			Dungemon monster = new();

			monster.BasePokemon = pokemon.Name;

			ConvertBaseStats(pokemon, monster);

			monster.ChallengeRating = DetermineExpectedCR(pokemon); // Will need to be moved from here once all stats are available for correct CR

			monster.ProficiencyBonus = DetermineProficiencyBonus(monster.ChallengeRating);

			monster.ImageLink = pokemon.ImageLink;

			monster.Cry = pokemon.Cry;

			monster.GiveMeleeAttack(pokemon);

			monster.AssignDungemonType(pokemon);

			ProficiencyDeciders.UpdateDungemon(monster, pokemon);

			return monster;
		}
		public static void ConvertBaseStats(Pokemon pokemon, Dungemon monster)
		{
			ConvertAttackToStrength(pokemon, monster);
			ConvertHPToConstitution(pokemon, monster);
			ConvertSpeedToDexterity(pokemon, monster);
			ConvertSpAtkToIntelligence(pokemon, monster);
			ConvertSpDefToWisdom(pokemon, monster);
			ConvertDefenseToCharisma(pokemon, monster);
			ConvertStatstoAC(pokemon, monster);
			ConvertStatstoHitPoints(pokemon, monster);
		}
		public static void ConvertAttackToStrength(Pokemon pokemon, Dungemon monster)
		{
			if (pokemon.Attack < 11) monster.Strength = 1;
			if (pokemon.Attack >= 11 && pokemon.Attack < 17) monster.Strength = 2;
			if (pokemon.Attack >= 17 && pokemon.Attack < 23) monster.Strength = 3;
			if (pokemon.Attack >= 23 && pokemon.Attack < 29) monster.Strength = 4;
			if (pokemon.Attack >= 29 && pokemon.Attack < 35) monster.Strength = 5;
			if (pokemon.Attack >= 35 && pokemon.Attack < 41) monster.Strength = 6;
			if (pokemon.Attack >= 41 && pokemon.Attack < 47) monster.Strength = 7;
			if (pokemon.Attack >= 47 && pokemon.Attack < 53) monster.Strength = 8;
			if (pokemon.Attack >= 53 && pokemon.Attack < 59) monster.Strength = 9;
			if (pokemon.Attack >= 59 && pokemon.Attack < 65) monster.Strength = 10;
			if (pokemon.Attack >= 65 && pokemon.Attack < 71) monster.Strength = 11;
			if (pokemon.Attack >= 71 && pokemon.Attack < 77) monster.Strength = 12;
			if (pokemon.Attack >= 77 && pokemon.Attack < 83) monster.Strength = 13;
			if (pokemon.Attack >= 83 && pokemon.Attack < 89) monster.Strength = 14;
			if (pokemon.Attack >= 89 && pokemon.Attack < 95) monster.Strength = 15;
			if (pokemon.Attack >= 95 && pokemon.Attack < 101) monster.Strength = 16;
			if (pokemon.Attack >= 101 && pokemon.Attack < 107) monster.Strength = 17;
			if (pokemon.Attack >= 107 && pokemon.Attack < 113) monster.Strength = 18;
			if (pokemon.Attack >= 113 && pokemon.Attack < 119) monster.Strength = 19;
			if (pokemon.Attack >= 119 && pokemon.Attack < 125) monster.Strength = 20;
			if (pokemon.Attack >= 125 && pokemon.Attack < 131) monster.Strength = 21;
			if (pokemon.Attack >= 131 && pokemon.Attack < 137) monster.Strength = 22;
			if (pokemon.Attack >= 137 && pokemon.Attack < 143) monster.Strength = 23;
			if (pokemon.Attack >= 143 && pokemon.Attack < 149) monster.Strength = 24;
			if (pokemon.Attack >= 149 && pokemon.Attack < 155) monster.Strength = 25;
			if (pokemon.Attack >= 155 && pokemon.Attack < 161) monster.Strength = 26;
			if (pokemon.Attack >= 161 && pokemon.Attack < 167) monster.Strength = 27;
			if (pokemon.Attack >= 167 && pokemon.Attack < 173) monster.Strength = 28;
			if (pokemon.Attack >= 173 && pokemon.Attack < 179) monster.Strength = 29;
			if (pokemon.Attack >= 179) monster.Strength = 30;
		}
		public static void ConvertHPToConstitution(Pokemon pokemon, Dungemon monster)
		{
			if (pokemon.HP < 9) monster.Constitution = 1;
			if (pokemon.HP >= 9 && pokemon.HP < 18) monster.Constitution = 2;
			if (pokemon.HP >= 18 && pokemon.HP < 26) monster.Constitution = 3;
			if (pokemon.HP >= 26 && pokemon.HP < 35) monster.Constitution = 4;
			if (pokemon.HP >= 35 && pokemon.HP < 43) monster.Constitution = 5;
			if (pokemon.HP >= 43 && pokemon.HP < 52) monster.Constitution = 6;
			if (pokemon.HP >= 52 && pokemon.HP < 60) monster.Constitution = 7;
			if (pokemon.HP >= 60 && pokemon.HP < 69) monster.Constitution = 8;
			if (pokemon.HP >= 69 && pokemon.HP < 77) monster.Constitution = 9;
			if (pokemon.HP >= 77 && pokemon.HP < 86) monster.Constitution = 10;
			if (pokemon.HP >= 86 && pokemon.HP < 94) monster.Constitution = 11;
			if (pokemon.HP >= 94 && pokemon.HP < 103) monster.Constitution = 12;
			if (pokemon.HP >= 103 && pokemon.HP < 111) monster.Constitution = 13;
			if (pokemon.HP >= 111 && pokemon.HP < 120) monster.Constitution = 14;
			if (pokemon.HP >= 120 && pokemon.HP < 128) monster.Constitution = 15;
			if (pokemon.HP >= 128 && pokemon.HP < 137) monster.Constitution = 16;
			if (pokemon.HP >= 137 && pokemon.HP < 145) monster.Constitution = 17;
			if (pokemon.HP >= 145 && pokemon.HP < 154) monster.Constitution = 18;
			if (pokemon.HP >= 154 && pokemon.HP < 162) monster.Constitution = 19;
			if (pokemon.HP >= 162 && pokemon.HP < 171) monster.Constitution = 20;
			if (pokemon.HP >= 171 && pokemon.HP < 179) monster.Constitution = 21;
			if (pokemon.HP >= 179 && pokemon.HP < 188) monster.Constitution = 22;
			if (pokemon.HP >= 188 && pokemon.HP < 196) monster.Constitution = 23;
			if (pokemon.HP >= 196 && pokemon.HP < 205) monster.Constitution = 24;
			if (pokemon.HP >= 205 && pokemon.HP < 213) monster.Constitution = 25;
			if (pokemon.HP >= 213 && pokemon.HP < 222) monster.Constitution = 26;
			if (pokemon.HP >= 222 && pokemon.HP < 230) monster.Constitution = 27;
			if (pokemon.HP >= 230 && pokemon.HP < 239) monster.Constitution = 28;
			if (pokemon.HP >= 239 && pokemon.HP < 247) monster.Constitution = 29;
			if (pokemon.HP >= 247) monster.Constitution = 30;
		}
		public static void ConvertSpeedToDexterity(Pokemon pokemon, Dungemon monster)
		{
			if (pokemon.Speed < 11) monster.Dexterity = 1;
			if (pokemon.Speed >= 11 && pokemon.Speed < 17) monster.Dexterity = 2;
			if (pokemon.Speed >= 17 && pokemon.Speed < 23) monster.Dexterity = 3;
			if (pokemon.Speed >= 23 && pokemon.Speed < 29) monster.Dexterity = 4;
			if (pokemon.Speed >= 29 && pokemon.Speed < 34) monster.Dexterity = 5;
			if (pokemon.Speed >= 34 && pokemon.Speed < 40) monster.Dexterity = 6;
			if (pokemon.Speed >= 40 && pokemon.Speed < 46) monster.Dexterity = 7;
			if (pokemon.Speed >= 46 && pokemon.Speed < 52) monster.Dexterity = 8;
			if (pokemon.Speed >= 52 && pokemon.Speed < 58) monster.Dexterity = 9;
			if (pokemon.Speed >= 58 && pokemon.Speed < 64) monster.Dexterity = 10;
			if (pokemon.Speed >= 64 && pokemon.Speed < 70) monster.Dexterity = 11;
			if (pokemon.Speed >= 70 && pokemon.Speed < 76) monster.Dexterity = 12;
			if (pokemon.Speed >= 76 && pokemon.Speed < 82) monster.Dexterity = 13;
			if (pokemon.Speed >= 82 && pokemon.Speed < 88) monster.Dexterity = 14;
			if (pokemon.Speed >= 88 && pokemon.Speed < 94) monster.Dexterity = 15;
			if (pokemon.Speed >= 94 && pokemon.Speed < 99) monster.Dexterity = 16;
			if (pokemon.Speed >= 99 && pokemon.Speed < 104) monster.Dexterity = 17;
			if (pokemon.Speed >= 104 && pokemon.Speed < 110) monster.Dexterity = 18;
			if (pokemon.Speed >= 110 && pokemon.Speed < 116) monster.Dexterity = 19;
			if (pokemon.Speed >= 116 && pokemon.Speed < 122) monster.Dexterity = 20;
			if (pokemon.Speed >= 122 && pokemon.Speed < 128) monster.Dexterity = 21;
			if (pokemon.Speed >= 128 && pokemon.Speed < 134) monster.Dexterity = 22;
			if (pokemon.Speed >= 134 && pokemon.Speed < 140) monster.Dexterity = 23;
			if (pokemon.Speed >= 140 && pokemon.Speed < 145) monster.Dexterity = 24;
			if (pokemon.Speed >= 145 && pokemon.Speed < 151) monster.Dexterity = 25;
			if (pokemon.Speed >= 151 && pokemon.Speed < 157) monster.Dexterity = 26;
			if (pokemon.Speed >= 157 && pokemon.Speed < 163) monster.Dexterity = 27;
			if (pokemon.Speed >= 163 && pokemon.Speed < 169) monster.Dexterity = 28;
			if (pokemon.Speed >= 169 && pokemon.Speed < 175) monster.Dexterity = 29;
			if (pokemon.Speed >= 175) monster.Dexterity = 30;
		}
		public static void ConvertSpAtkToIntelligence(Pokemon pokemon, Dungemon monster)
		{
			if (pokemon.SpecialAttack < 16) monster.Intelligence = 1;
			if (pokemon.SpecialAttack >= 16 && pokemon.SpecialAttack < 22) monster.Intelligence = 2;
			if (pokemon.SpecialAttack >= 22 && pokemon.SpecialAttack < 28) monster.Intelligence = 3;
			if (pokemon.SpecialAttack >= 28 && pokemon.SpecialAttack < 34) monster.Intelligence = 4;
			if (pokemon.SpecialAttack >= 34 && pokemon.SpecialAttack < 40) monster.Intelligence = 5;
			if (pokemon.SpecialAttack >= 40 && pokemon.SpecialAttack < 46) monster.Intelligence = 6;
			if (pokemon.SpecialAttack >= 46 && pokemon.SpecialAttack < 52) monster.Intelligence = 7;
			if (pokemon.SpecialAttack >= 52 && pokemon.SpecialAttack < 58) monster.Intelligence = 8;
			if (pokemon.SpecialAttack >= 58 && pokemon.SpecialAttack < 64) monster.Intelligence = 9;
			if (pokemon.SpecialAttack >= 64 && pokemon.SpecialAttack < 70) monster.Intelligence = 10;
			if (pokemon.SpecialAttack >= 70 && pokemon.SpecialAttack < 76) monster.Intelligence = 11;
			if (pokemon.SpecialAttack >= 76 && pokemon.SpecialAttack < 82) monster.Intelligence = 12;
			if (pokemon.SpecialAttack >= 82 && pokemon.SpecialAttack < 88) monster.Intelligence = 13;
			if (pokemon.SpecialAttack >= 88 && pokemon.SpecialAttack < 94) monster.Intelligence = 14;
			if (pokemon.SpecialAttack >= 94 && pokemon.SpecialAttack < 100) monster.Intelligence = 15;
			if (pokemon.SpecialAttack >= 100 && pokemon.SpecialAttack < 106) monster.Intelligence = 16;
			if (pokemon.SpecialAttack >= 106 && pokemon.SpecialAttack < 112) monster.Intelligence = 17;
			if (pokemon.SpecialAttack >= 112 && pokemon.SpecialAttack < 118) monster.Intelligence = 18;
			if (pokemon.SpecialAttack >= 118 && pokemon.SpecialAttack < 124) monster.Intelligence = 19;
			if (pokemon.SpecialAttack >= 124 && pokemon.SpecialAttack < 130) monster.Intelligence = 20;
			if (pokemon.SpecialAttack >= 130 && pokemon.SpecialAttack < 136) monster.Intelligence = 21;
			if (pokemon.SpecialAttack >= 136 && pokemon.SpecialAttack < 142) monster.Intelligence = 22;
			if (pokemon.SpecialAttack >= 142 && pokemon.SpecialAttack < 148) monster.Intelligence = 23;
			if (pokemon.SpecialAttack >= 148 && pokemon.SpecialAttack < 154) monster.Intelligence = 24;
			if (pokemon.SpecialAttack >= 154 && pokemon.SpecialAttack < 160) monster.Intelligence = 25;
			if (pokemon.SpecialAttack >= 160 && pokemon.SpecialAttack < 166) monster.Intelligence = 26;
			if (pokemon.SpecialAttack >= 166 && pokemon.SpecialAttack < 172) monster.Intelligence = 27;
			if (pokemon.SpecialAttack >= 172 && pokemon.SpecialAttack < 178) monster.Intelligence = 28;
			if (pokemon.SpecialAttack >= 178 && pokemon.SpecialAttack < 184) monster.Intelligence = 29;
			if (pokemon.SpecialAttack >= 184) monster.Intelligence = 30;
		}
		public static void ConvertSpDefToWisdom(Pokemon pokemon, Dungemon monster)
		{
			if (pokemon.SpecialDefense < 27) monster.Wisdom = 1;
			if (pokemon.SpecialDefense >= 27 && pokemon.SpecialDefense < 34) monster.Wisdom = 2;
			if (pokemon.SpecialDefense >= 34 && pokemon.SpecialDefense < 41) monster.Wisdom = 3;
			if (pokemon.SpecialDefense >= 41 && pokemon.SpecialDefense < 48) monster.Wisdom = 4;
			if (pokemon.SpecialDefense >= 48 && pokemon.SpecialDefense < 55) monster.Wisdom = 5;
			if (pokemon.SpecialDefense >= 55 && pokemon.SpecialDefense < 62) monster.Wisdom = 6;
			if (pokemon.SpecialDefense >= 62 && pokemon.SpecialDefense < 69) monster.Wisdom = 7;
			if (pokemon.SpecialDefense >= 69 && pokemon.SpecialDefense < 76) monster.Wisdom = 8;
			if (pokemon.SpecialDefense >= 76 && pokemon.SpecialDefense < 83) monster.Wisdom = 9;
			if (pokemon.SpecialDefense >= 83 && pokemon.SpecialDefense < 90) monster.Wisdom = 10;
			if (pokemon.SpecialDefense >= 90 && pokemon.SpecialDefense < 97) monster.Wisdom = 11;
			if (pokemon.SpecialDefense >= 97 && pokemon.SpecialDefense < 104) monster.Wisdom = 12;
			if (pokemon.SpecialDefense >= 104 && pokemon.SpecialDefense < 111) monster.Wisdom = 13;
			if (pokemon.SpecialDefense >= 111 && pokemon.SpecialDefense < 118) monster.Wisdom = 14;
			if (pokemon.SpecialDefense >= 118 && pokemon.SpecialDefense < 125) monster.Wisdom = 15;
			if (pokemon.SpecialDefense >= 125 && pokemon.SpecialDefense < 132) monster.Wisdom = 16;
			if (pokemon.SpecialDefense >= 132 && pokemon.SpecialDefense < 139) monster.Wisdom = 17;
			if (pokemon.SpecialDefense >= 139 && pokemon.SpecialDefense < 146) monster.Wisdom = 18;
			if (pokemon.SpecialDefense >= 146 && pokemon.SpecialDefense < 153) monster.Wisdom = 19;
			if (pokemon.SpecialDefense >= 153 && pokemon.SpecialDefense < 160) monster.Wisdom = 20;
			if (pokemon.SpecialDefense >= 160 && pokemon.SpecialDefense < 167) monster.Wisdom = 21;
			if (pokemon.SpecialDefense >= 167 && pokemon.SpecialDefense < 174) monster.Wisdom = 22;
			if (pokemon.SpecialDefense >= 174 && pokemon.SpecialDefense < 181) monster.Wisdom = 23;
			if (pokemon.SpecialDefense >= 181 && pokemon.SpecialDefense < 188) monster.Wisdom = 24;
			if (pokemon.SpecialDefense >= 188 && pokemon.SpecialDefense < 195) monster.Wisdom = 25;
			if (pokemon.SpecialDefense >= 195 && pokemon.SpecialDefense < 202) monster.Wisdom = 26;
			if (pokemon.SpecialDefense >= 202 && pokemon.SpecialDefense < 209) monster.Wisdom = 27;
			if (pokemon.SpecialDefense >= 209 && pokemon.SpecialDefense < 216) monster.Wisdom = 28;
			if (pokemon.SpecialDefense >= 216 && pokemon.SpecialDefense < 223) monster.Wisdom = 29;
			if (pokemon.SpecialDefense >= 223) monster.Wisdom = 30;
		}
		public static void ConvertDefenseToCharisma(Pokemon pokemon, Dungemon monster)
		{
			if (pokemon.Defense < 12) monster.Charisma = 1;
			if (pokemon.Defense >= 12 && pokemon.Defense < 19) monster.Charisma = 2;
			if (pokemon.Defense >= 19 && pokemon.Defense < 26) monster.Charisma = 3;
			if (pokemon.Defense >= 26 && pokemon.Defense < 33) monster.Charisma = 4;
			if (pokemon.Defense >= 33 && pokemon.Defense < 40) monster.Charisma = 5;
			if (pokemon.Defense >= 40 && pokemon.Defense < 47) monster.Charisma = 6;
			if (pokemon.Defense >= 47 && pokemon.Defense < 54) monster.Charisma = 7;
			if (pokemon.Defense >= 54 && pokemon.Defense < 61) monster.Charisma = 8;
			if (pokemon.Defense >= 61 && pokemon.Defense < 68) monster.Charisma = 9;
			if (pokemon.Defense >= 68 && pokemon.Defense < 75) monster.Charisma = 10;
			if (pokemon.Defense >= 75 && pokemon.Defense < 82) monster.Charisma = 11;
			if (pokemon.Defense >= 82 && pokemon.Defense < 89) monster.Charisma = 12;
			if (pokemon.Defense >= 89 && pokemon.Defense < 96) monster.Charisma = 13;
			if (pokemon.Defense >= 96 && pokemon.Defense < 103) monster.Charisma = 14;
			if (pokemon.Defense >= 103 && pokemon.Defense < 110) monster.Charisma = 15;
			if (pokemon.Defense >= 110 && pokemon.Defense < 118) monster.Charisma = 16;
			if (pokemon.Defense >= 118 && pokemon.Defense < 126) monster.Charisma = 17;
			if (pokemon.Defense >= 126 && pokemon.Defense < 134) monster.Charisma = 18;
			if (pokemon.Defense >= 134 && pokemon.Defense < 142) monster.Charisma = 19;
			if (pokemon.Defense >= 142 && pokemon.Defense < 150) monster.Charisma = 20;
			if (pokemon.Defense >= 150 && pokemon.Defense < 158) monster.Charisma = 21;
			if (pokemon.Defense >= 158 && pokemon.Defense < 166) monster.Charisma = 22;
			if (pokemon.Defense >= 166 && pokemon.Defense < 174) monster.Charisma = 23;
			if (pokemon.Defense >= 174 && pokemon.Defense < 182) monster.Charisma = 24;
			if (pokemon.Defense >= 182 && pokemon.Defense < 190) monster.Charisma = 25;
			if (pokemon.Defense >= 190 && pokemon.Defense < 198) monster.Charisma = 26;
			if (pokemon.Defense >= 198 && pokemon.Defense < 206) monster.Charisma = 27;
			if (pokemon.Defense >= 206 && pokemon.Defense < 214) monster.Charisma = 28;
			if (pokemon.Defense >= 214 && pokemon.Defense < 222) monster.Charisma = 29;
			if (pokemon.Defense >= 222) monster.Charisma = 30;
		}
		public static void ConvertStatstoHitPoints(Pokemon pokemon, Dungemon monster)
		{
			float expectedCR = DetermineExpectedCR(pokemon);

			switch (expectedCR)
			{
				case 0:
					monster.HitPoints = 1;
					break;
				case 0.125f:
					monster.HitPoints = 7;
					break;
				case 0.25f:
					monster.HitPoints = 36;
					break;
				case 0.5f:
					monster.HitPoints = 50;
					break;
				case 1:
					monster.HitPoints = 71;
					break;
				case 2:
					monster.HitPoints = 86;
					break;
				case 3:
					monster.HitPoints = 101;
					break;
				case 4:
					monster.HitPoints = 116;
					break;
				case 5:
					monster.HitPoints = 131;
					break;
				case 6:
					monster.HitPoints = 146;
					break;
				case 7:
					monster.HitPoints = 161;
					break;
				case 8:
					monster.HitPoints = 176;
					break;
				case 9:
					monster.HitPoints = 191;
					break;
				case 11:
					monster.HitPoints = 221;
					break;
				case 12:
					monster.HitPoints = 236;
					break;
				case 13:
					monster.HitPoints = 251;
					break;
				case 14:
					monster.HitPoints = 266;
					break;
				case 15:
					monster.HitPoints = 281;
					break;
				case 16:
					monster.HitPoints = 296;
					break;
				case 17:
					monster.HitPoints = 311;
					break;
				case 18:
					monster.HitPoints = 326;
					break;
				case 19:
					monster.HitPoints = 341;
					break;
				case 20:
					monster.HitPoints = 356;
					break;
				case 21:
					monster.HitPoints = 401;
					break;
				case 22:
					monster.HitPoints = 446;
					break;
				case 23:
					monster.HitPoints = 491;
					break;
				case 24:
					monster.HitPoints = 536;
					break;
				case 25:
					monster.HitPoints = 581;
					break;
				case 26:
					monster.HitPoints = 626;
					break;
				case 27:
					monster.HitPoints = 671;
					break;
				case 28:
					monster.HitPoints = 716;
					break;
				case 29:
					monster.HitPoints = 761;
					break;
				case 30:
					monster.HitPoints = 806;
					break;
				default:
				case 10:
					monster.HitPoints = 206;
					break;
			}

			monster.HitPoints += monster.Constitution;
		}
		public static void ConvertStatstoAC(Pokemon pokemon, Dungemon monster)
		{
			float expectedCR = DetermineExpectedCR(pokemon);

			switch (expectedCR)
			{
				case 0:
					monster.ArmorClass = 10;
					break;
				case 0.125f:
				case 0.25f:
				case 0.5f:
				case 1:
				case 2:
				case 3:
					monster.ArmorClass = 13;
					break;
				case 4:
					monster.ArmorClass = 14;
					break;
				case 5:
				case 6:
				case 7:
					monster.ArmorClass = 15;
					break;
				case 8:
				case 9:
					monster.ArmorClass = 16;
					break;
				case 10:
				case 11:
				case 12:
					monster.ArmorClass = 17;
					break;
				case 13:
				case 14:
				case 15:
				case 16:
					monster.ArmorClass = 18;
					break;
				default:
					monster.ArmorClass = 19;
					break;
			}

			if (pokemon.Defense > 189) monster.ArmorClass += 3;
			else if (pokemon.Defense > 129) monster.ArmorClass += 2;
			else if (pokemon.Defense > 74) monster.ArmorClass += 1;

		}
		public static float DetermineExpectedCR(Pokemon pokemon)
		{
			float expectedCR = 0f;
			int BST = pokemon.HP + pokemon.Attack + pokemon.Defense + pokemon.SpecialAttack + pokemon.SpecialDefense + pokemon.Speed;

			if (BST < 193) expectedCR = 0;
			if (BST >= 193 && BST < 211) expectedCR = 0.125f;
			if (BST >= 211 && BST < 229) expectedCR = 0.25f;
			if (BST >= 229 && BST < 247) expectedCR = 0.5f;
			if (BST >= 247 && BST < 265) expectedCR = 1f;
			if (BST >= 265 && BST < 229) expectedCR = 2f;
			if (BST >= 283 && BST < 283) expectedCR = 3f;
			if (BST >= 301 && BST < 319) expectedCR = 4f;
			if (BST >= 319 && BST < 337) expectedCR = 5f;
			if (BST >= 337 && BST < 355) expectedCR = 6f;
			if (BST >= 355 && BST < 373) expectedCR = 7f;
			if (BST >= 373 && BST < 391) expectedCR = 8f;
			if (BST >= 391 && BST < 409) expectedCR = 9f;
			if (BST >= 409 && BST < 427) expectedCR = 10f;
			if (BST >= 427 && BST < 445) expectedCR = 11f;
			if (BST >= 445 && BST < 463) expectedCR = 12f;
			if (BST >= 463 && BST < 481) expectedCR = 13f;
			if (BST >= 481 && BST < 499) expectedCR = 14f;
			if (BST >= 499 && BST < 517) expectedCR = 15f;
			if (BST >= 517 && BST < 535) expectedCR = 16f;
			if (BST >= 535 && BST < 553) expectedCR = 17f;
			if (BST >= 553 && BST < 571) expectedCR = 18f;
			if (BST >= 571 && BST < 589) expectedCR = 19f;
			if (BST >= 589 && BST < 607) expectedCR = 20f;
			if (BST >= 607 && BST < 626) expectedCR = 21f;
			if (BST >= 626 && BST < 645) expectedCR = 22f;
			if (BST >= 645 && BST < 664) expectedCR = 23f;
			if (BST >= 664 && BST < 683) expectedCR = 24f;
			if (BST >= 683 && BST < 702) expectedCR = 25f;
			if (BST >= 702 && BST < 721) expectedCR = 26f;
			if (BST >= 721 && BST < 740) expectedCR = 27f;
			if (BST >= 740 && BST < 759) expectedCR = 28f;
			if (BST >= 759 && BST < 778) expectedCR = 29f;
			if (BST >= 778) expectedCR = 30f;

			return expectedCR;
		}
		public static int GetModifier(int attribute)
		{
			return (int)Math.Floor(((double)attribute / 2) - 5);
		}

		//public static void SetFinalCR(Pokemon pokemon, Monster monster) {} Needs attack data before actionable
		public static int DetermineProficiencyBonus(float CR)
		{
			switch (CR)
			{
				case 5f: case 6f: case 7f: case 8f:
					return 3;
				case 9f: case 10f: case 11f: case 12f:
					return 4;
				case 13f: case 14f: case 15f: case 16f:
					return 5;
				case 17f: case 18f: case 19f: case 20f:
					return 6;
				case 21f: case 22f: case 23f: case 24f:
					return 7;
				case 25f: case 26f: case 27f: case 28f:
					return 8;
				case 29f: case 30f:
					return 9;
				case 0f: case 0.125f: case 0.25f: case 0.5f:
				case 1f: case 2f: case 3f: case 4f:
				default:
					return 2;
			}
		}

	}
}
