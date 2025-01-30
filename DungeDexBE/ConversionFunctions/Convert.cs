using DungeDexBE.Models;

namespace DungeDexBE.ConversionFunctions
{
	public class Convert
	{
		public static void ConvertBaseStats(Pokemon pokemon, Monster monster)
		{
			ConvertAttackToStrength(pokemon, monster);
			ConvertHPToConstitution(pokemon, monster);
			ConvertSpeedToDexterity(pokemon, monster);
			ConvertSpAtkToIntelligence(pokemon, monster);
		}

		public static void ConvertAttackToStrength(Pokemon pokemon, Monster monster)
		{
			if (pokemon.Attack < 11) monster.Attributes.Strength = 1;
			if (pokemon.Attack >= 11 && pokemon.Attack < 17) monster.Attributes.Strength = 2;
			if (pokemon.Attack >= 17 && pokemon.Attack < 23) monster.Attributes.Strength = 3;
			if (pokemon.Attack >= 23 && pokemon.Attack < 29) monster.Attributes.Strength = 4;
			if (pokemon.Attack >= 29 && pokemon.Attack < 35) monster.Attributes.Strength = 5;
			if (pokemon.Attack >= 35 && pokemon.Attack < 41) monster.Attributes.Strength = 6;
			if (pokemon.Attack >= 41 && pokemon.Attack < 47) monster.Attributes.Strength = 7;
			if (pokemon.Attack >= 47 && pokemon.Attack < 53) monster.Attributes.Strength = 8;
			if (pokemon.Attack >= 53 && pokemon.Attack < 59) monster.Attributes.Strength = 9;
			if (pokemon.Attack >= 59 && pokemon.Attack < 65) monster.Attributes.Strength = 10;
			if (pokemon.Attack >= 65 && pokemon.Attack < 71) monster.Attributes.Strength = 11;
			if (pokemon.Attack >= 71 && pokemon.Attack < 77) monster.Attributes.Strength = 12;
			if (pokemon.Attack >= 77 && pokemon.Attack < 83) monster.Attributes.Strength = 13;
			if (pokemon.Attack >= 83 && pokemon.Attack < 89) monster.Attributes.Strength = 14;
			if (pokemon.Attack >= 89 && pokemon.Attack < 95) monster.Attributes.Strength = 15;
			if (pokemon.Attack >= 95 && pokemon.Attack < 101) monster.Attributes.Strength = 16;
			if (pokemon.Attack >= 101 && pokemon.Attack < 107) monster.Attributes.Strength = 17;
			if (pokemon.Attack >= 107 && pokemon.Attack < 113) monster.Attributes.Strength = 18;
			if (pokemon.Attack >= 113 && pokemon.Attack < 119) monster.Attributes.Strength = 19;
			if (pokemon.Attack >= 119 && pokemon.Attack < 125) monster.Attributes.Strength = 20;
			if (pokemon.Attack >= 125 && pokemon.Attack < 131) monster.Attributes.Strength = 21;
			if (pokemon.Attack >= 131 && pokemon.Attack < 137) monster.Attributes.Strength = 22;
			if (pokemon.Attack >= 137 && pokemon.Attack < 143) monster.Attributes.Strength = 23;
			if (pokemon.Attack >= 143 && pokemon.Attack < 149) monster.Attributes.Strength = 24;
			if (pokemon.Attack >= 149 && pokemon.Attack < 155) monster.Attributes.Strength = 25;
			if (pokemon.Attack >= 155 && pokemon.Attack < 161) monster.Attributes.Strength = 26;
			if (pokemon.Attack >= 161 && pokemon.Attack < 167) monster.Attributes.Strength = 27;
			if (pokemon.Attack >= 167 && pokemon.Attack < 173) monster.Attributes.Strength = 28;
			if (pokemon.Attack >= 173 && pokemon.Attack < 179) monster.Attributes.Strength = 29;
			if (pokemon.Attack >= 179) monster.Attributes.Strength = 30;
		}
		public static void ConvertHPToConstitution(Pokemon pokemon, Monster monster)
		{
			if (pokemon.HP < 9) monster.Attributes.Constitution = 1;
			if (pokemon.HP >= 9 && pokemon.HP < 18) monster.Attributes.Constitution = 2;
			if (pokemon.HP >= 18 && pokemon.HP < 26) monster.Attributes.Constitution = 3;
			if (pokemon.HP >= 26 && pokemon.HP < 35) monster.Attributes.Constitution = 4;
			if (pokemon.HP >= 35 && pokemon.HP < 43) monster.Attributes.Constitution = 5;
			if (pokemon.HP >= 43 && pokemon.HP < 52) monster.Attributes.Constitution = 6;
			if (pokemon.HP >= 52 && pokemon.HP < 60) monster.Attributes.Constitution = 7;
			if (pokemon.HP >= 60 && pokemon.HP < 69) monster.Attributes.Constitution = 8;
			if (pokemon.HP >= 69 && pokemon.HP < 77) monster.Attributes.Constitution = 9;
			if (pokemon.HP >= 77 && pokemon.HP < 86) monster.Attributes.Constitution = 10;
			if (pokemon.HP >= 86 && pokemon.HP < 94) monster.Attributes.Constitution = 11;
			if (pokemon.HP >= 94 && pokemon.HP < 103) monster.Attributes.Constitution = 12;
			if (pokemon.HP >= 103 && pokemon.HP < 111) monster.Attributes.Constitution = 13;
			if (pokemon.HP >= 111 && pokemon.HP < 120) monster.Attributes.Constitution = 14;
			if (pokemon.HP >= 120 && pokemon.HP < 128) monster.Attributes.Constitution = 15;
			if (pokemon.HP >= 128 && pokemon.HP < 137) monster.Attributes.Constitution = 16;
			if (pokemon.HP >= 137 && pokemon.HP < 145) monster.Attributes.Constitution = 17;
			if (pokemon.HP >= 145 && pokemon.HP < 154) monster.Attributes.Constitution = 18;
			if (pokemon.HP >= 154 && pokemon.HP < 162) monster.Attributes.Constitution = 19;
			if (pokemon.HP >= 162 && pokemon.HP < 171) monster.Attributes.Constitution = 20;
			if (pokemon.HP >= 171 && pokemon.HP < 179) monster.Attributes.Constitution = 21;
			if (pokemon.HP >= 179 && pokemon.HP < 188) monster.Attributes.Constitution = 22;
			if (pokemon.HP >= 188 && pokemon.HP < 196) monster.Attributes.Constitution = 23;
			if (pokemon.HP >= 196 && pokemon.HP < 205) monster.Attributes.Constitution = 24;
			if (pokemon.HP >= 205 && pokemon.HP < 213) monster.Attributes.Constitution = 25;
			if (pokemon.HP >= 213 && pokemon.HP < 222) monster.Attributes.Constitution = 26;
			if (pokemon.HP >= 222 && pokemon.HP < 230) monster.Attributes.Constitution = 27;
			if (pokemon.HP >= 230 && pokemon.HP < 239) monster.Attributes.Constitution = 28;
			if (pokemon.HP >= 239 && pokemon.HP < 247) monster.Attributes.Constitution = 29;
			if (pokemon.HP >= 247) monster.Attributes.Constitution = 30;
		}
		public static void ConvertSpeedToDexterity(Pokemon pokemon, Monster monster)
		{
			if (pokemon.Speed < 11) monster.Attributes.Dexterity = 1;
			if (pokemon.Speed >= 11 && pokemon.Speed < 17) monster.Attributes.Dexterity = 2;
			if (pokemon.Speed >= 17 && pokemon.Speed < 23) monster.Attributes.Dexterity = 3;
			if (pokemon.Speed >= 23 && pokemon.Speed < 29) monster.Attributes.Dexterity = 4;
			if (pokemon.Speed >= 29 && pokemon.Speed < 34) monster.Attributes.Dexterity = 5;
			if (pokemon.Speed >= 34 && pokemon.Speed < 40) monster.Attributes.Dexterity = 6;
			if (pokemon.Speed >= 40 && pokemon.Speed < 46) monster.Attributes.Dexterity = 7;
			if (pokemon.Speed >= 46 && pokemon.Speed < 52) monster.Attributes.Dexterity = 8;
			if (pokemon.Speed >= 52 && pokemon.Speed < 58) monster.Attributes.Dexterity = 9;
			if (pokemon.Speed >= 58 && pokemon.Speed < 64) monster.Attributes.Dexterity = 10;
			if (pokemon.Speed >= 64 && pokemon.Speed < 70) monster.Attributes.Dexterity = 11;
			if (pokemon.Speed >= 70 && pokemon.Speed < 76) monster.Attributes.Dexterity = 12;
			if (pokemon.Speed >= 76 && pokemon.Speed < 82) monster.Attributes.Dexterity = 13;
			if (pokemon.Speed >= 82 && pokemon.Speed < 88) monster.Attributes.Dexterity = 14;
			if (pokemon.Speed >= 88 && pokemon.Speed < 94) monster.Attributes.Dexterity = 15;
			if (pokemon.Speed >= 94 && pokemon.Speed < 99) monster.Attributes.Dexterity = 16;
			if (pokemon.Speed >= 99 && pokemon.Speed < 104) monster.Attributes.Dexterity = 17;
			if (pokemon.Speed >= 104 && pokemon.Speed < 110) monster.Attributes.Dexterity = 18;
			if (pokemon.Speed >= 110 && pokemon.Speed < 116) monster.Attributes.Dexterity = 19;
			if (pokemon.Speed >= 116 && pokemon.Speed < 122) monster.Attributes.Dexterity = 20;
			if (pokemon.Speed >= 122 && pokemon.Speed < 128) monster.Attributes.Dexterity = 21;
			if (pokemon.Speed >= 128 && pokemon.Speed < 134) monster.Attributes.Dexterity = 22;
			if (pokemon.Speed >= 134 && pokemon.Speed < 140) monster.Attributes.Dexterity = 23;
			if (pokemon.Speed >= 140 && pokemon.Speed < 145) monster.Attributes.Dexterity = 24;
			if (pokemon.Speed >= 145 && pokemon.Speed < 151) monster.Attributes.Dexterity = 25;
			if (pokemon.Speed >= 151 && pokemon.Speed < 157) monster.Attributes.Dexterity = 26;
			if (pokemon.Speed >= 157 && pokemon.Speed < 163) monster.Attributes.Dexterity = 27;
			if (pokemon.Speed >= 163 && pokemon.Speed < 169) monster.Attributes.Dexterity = 28;
			if (pokemon.Speed >= 169 && pokemon.Speed < 175) monster.Attributes.Dexterity = 29;
			if (pokemon.Speed >= 175) monster.Attributes.Dexterity = 30;
		}
		public static void ConvertSpAtkToIntelligence(Pokemon pokemon, Monster monster)
		{
			if (pokemon.SpecialAttack < 16) monster.Attributes.Intelligence = 1;
			if (pokemon.SpecialAttack >= 16 && pokemon.SpecialAttack < 22) monster.Attributes.Intelligence = 2;
			if (pokemon.SpecialAttack >= 22 && pokemon.SpecialAttack < 28) monster.Attributes.Intelligence = 3;
			if (pokemon.SpecialAttack >= 28 && pokemon.SpecialAttack < 34) monster.Attributes.Intelligence = 4;
			if (pokemon.SpecialAttack >= 34 && pokemon.SpecialAttack < 40) monster.Attributes.Intelligence = 5;
			if (pokemon.SpecialAttack >= 40 && pokemon.SpecialAttack < 46) monster.Attributes.Intelligence = 6;
			if (pokemon.SpecialAttack >= 46 && pokemon.SpecialAttack < 52) monster.Attributes.Intelligence = 7;
			if (pokemon.SpecialAttack >= 52 && pokemon.SpecialAttack < 58) monster.Attributes.Intelligence = 8;
			if (pokemon.SpecialAttack >= 58 && pokemon.SpecialAttack < 64) monster.Attributes.Intelligence = 9;
			if (pokemon.SpecialAttack >= 64 && pokemon.SpecialAttack < 70) monster.Attributes.Intelligence = 10;
			if (pokemon.SpecialAttack >= 70 && pokemon.SpecialAttack < 76) monster.Attributes.Intelligence = 11;
			if (pokemon.SpecialAttack >= 76 && pokemon.SpecialAttack < 82) monster.Attributes.Intelligence = 12;
			if (pokemon.SpecialAttack >= 82 && pokemon.SpecialAttack < 88) monster.Attributes.Intelligence = 13;
			if (pokemon.SpecialAttack >= 88 && pokemon.SpecialAttack < 94) monster.Attributes.Intelligence = 14;
			if (pokemon.SpecialAttack >= 94 && pokemon.SpecialAttack < 100) monster.Attributes.Intelligence = 15;
			if (pokemon.SpecialAttack >= 100 && pokemon.SpecialAttack < 106) monster.Attributes.Intelligence = 16;
			if (pokemon.SpecialAttack >= 106 && pokemon.SpecialAttack < 112) monster.Attributes.Intelligence = 17;
			if (pokemon.SpecialAttack >= 112 && pokemon.SpecialAttack < 118) monster.Attributes.Intelligence = 18;
			if (pokemon.SpecialAttack >= 118 && pokemon.SpecialAttack < 124) monster.Attributes.Intelligence = 19;
			if (pokemon.SpecialAttack >= 124 && pokemon.SpecialAttack < 130) monster.Attributes.Intelligence = 20;
			if (pokemon.SpecialAttack >= 130 && pokemon.SpecialAttack < 136) monster.Attributes.Intelligence = 21;
			if (pokemon.SpecialAttack >= 136 && pokemon.SpecialAttack < 142) monster.Attributes.Intelligence = 22;
			if (pokemon.SpecialAttack >= 142 && pokemon.SpecialAttack < 148) monster.Attributes.Intelligence = 23;
			if (pokemon.SpecialAttack >= 148 && pokemon.SpecialAttack < 154) monster.Attributes.Intelligence = 24;
			if (pokemon.SpecialAttack >= 154 && pokemon.SpecialAttack < 160) monster.Attributes.Intelligence = 25;
			if (pokemon.SpecialAttack >= 160 && pokemon.SpecialAttack < 166) monster.Attributes.Intelligence = 26;
			if (pokemon.SpecialAttack >= 166 && pokemon.SpecialAttack < 172) monster.Attributes.Intelligence = 27;
			if (pokemon.SpecialAttack >= 172 && pokemon.SpecialAttack < 178) monster.Attributes.Intelligence = 28;
			if (pokemon.SpecialAttack >= 178 && pokemon.SpecialAttack < 184) monster.Attributes.Intelligence = 29;
			if (pokemon.SpecialAttack >= 184) monster.Attributes.Intelligence = 30;
		}
		public static void ConvertSpDefToWisdom(Pokemon pokemon, Monster monster)
		{
			if (pokemon.SpecialAttack < 16) monster.Attributes.Intelligence = 1;
			if (pokemon.SpecialAttack >= 16 && pokemon.SpecialAttack < 22) monster.Attributes.Intelligence = 2;
			if (pokemon.SpecialAttack >= 22 && pokemon.SpecialAttack < 28) monster.Attributes.Intelligence = 3;
			if (pokemon.SpecialAttack >= 28 && pokemon.SpecialAttack < 34) monster.Attributes.Intelligence = 4;
			if (pokemon.SpecialAttack >= 34 && pokemon.SpecialAttack < 40) monster.Attributes.Intelligence = 5;
			if (pokemon.SpecialAttack >= 40 && pokemon.SpecialAttack < 46) monster.Attributes.Intelligence = 6;
			if (pokemon.SpecialAttack >= 46 && pokemon.SpecialAttack < 52) monster.Attributes.Intelligence = 7;
			if (pokemon.SpecialAttack >= 52 && pokemon.SpecialAttack < 58) monster.Attributes.Intelligence = 8;
			if (pokemon.SpecialAttack >= 58 && pokemon.SpecialAttack < 64) monster.Attributes.Intelligence = 9;
			if (pokemon.SpecialAttack >= 64 && pokemon.SpecialAttack < 70) monster.Attributes.Intelligence = 10;
			if (pokemon.SpecialAttack >= 70 && pokemon.SpecialAttack < 76) monster.Attributes.Intelligence = 11;
			if (pokemon.SpecialAttack >= 76 && pokemon.SpecialAttack < 82) monster.Attributes.Intelligence = 12;
			if (pokemon.SpecialAttack >= 82 && pokemon.SpecialAttack < 88) monster.Attributes.Intelligence = 13;
			if (pokemon.SpecialAttack >= 88 && pokemon.SpecialAttack < 94) monster.Attributes.Intelligence = 14;
			if (pokemon.SpecialAttack >= 94 && pokemon.SpecialAttack < 100) monster.Attributes.Intelligence = 15;
			if (pokemon.SpecialAttack >= 100 && pokemon.SpecialAttack < 106) monster.Attributes.Intelligence = 16;
			if (pokemon.SpecialAttack >= 106 && pokemon.SpecialAttack < 112) monster.Attributes.Intelligence = 17;
			if (pokemon.SpecialAttack >= 112 && pokemon.SpecialAttack < 118) monster.Attributes.Intelligence = 18;
			if (pokemon.SpecialAttack >= 118 && pokemon.SpecialAttack < 124) monster.Attributes.Intelligence = 19;
			if (pokemon.SpecialAttack >= 124 && pokemon.SpecialAttack < 130) monster.Attributes.Intelligence = 20;
			if (pokemon.SpecialAttack >= 130 && pokemon.SpecialAttack < 136) monster.Attributes.Intelligence = 21;
			if (pokemon.SpecialAttack >= 136 && pokemon.SpecialAttack < 142) monster.Attributes.Intelligence = 22;
			if (pokemon.SpecialAttack >= 142 && pokemon.SpecialAttack < 148) monster.Attributes.Intelligence = 23;
			if (pokemon.SpecialAttack >= 148 && pokemon.SpecialAttack < 154) monster.Attributes.Intelligence = 24;
			if (pokemon.SpecialAttack >= 154 && pokemon.SpecialAttack < 160) monster.Attributes.Intelligence = 25;
			if (pokemon.SpecialAttack >= 160 && pokemon.SpecialAttack < 166) monster.Attributes.Intelligence = 26;
			if (pokemon.SpecialAttack >= 166 && pokemon.SpecialAttack < 172) monster.Attributes.Intelligence = 27;
			if (pokemon.SpecialAttack >= 172 && pokemon.SpecialAttack < 178) monster.Attributes.Intelligence = 28;
			if (pokemon.SpecialAttack >= 178 && pokemon.SpecialAttack < 184) monster.Attributes.Intelligence = 29;
			if (pokemon.SpecialAttack >= 184) monster.Attributes.Intelligence = 30;
		}
	}
}
