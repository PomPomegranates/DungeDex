using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeDexBE.ConversionFunctions;
using DungeDexBE.Models;
using FluentAssertions;

namespace Tests
{
	internal class ConversionTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void DetermineProficiencyBonus()
		{
			DungeMon dungeMon0 = new DungeMon { ChallengeRating = 0f };
			DungeMon dungeMon5 = new DungeMon { ChallengeRating = 5f };
			DungeMon dungeMon9 = new DungeMon { ChallengeRating = 9f };
			DungeMon dungeMon13 = new DungeMon { ChallengeRating = 13f };
			DungeMon dungeMon17 = new DungeMon { ChallengeRating = 17f };
			DungeMon dungeMon21 = new DungeMon { ChallengeRating = 21f };
			DungeMon dungeMon25 = new DungeMon { ChallengeRating = 25f };
			DungeMon dungeMon29 = new DungeMon { ChallengeRating = 29f };

			int expected2 = DungeDexBE.ConversionFunctions.Convert.DetermineProficiencyBonus(dungeMon0.ChallengeRating);
			int expected3 = DungeDexBE.ConversionFunctions.Convert.DetermineProficiencyBonus(dungeMon5.ChallengeRating);
			int expected4 = DungeDexBE.ConversionFunctions.Convert.DetermineProficiencyBonus(dungeMon9.ChallengeRating);
			int expected5 = DungeDexBE.ConversionFunctions.Convert.DetermineProficiencyBonus(dungeMon13.ChallengeRating);
			int expected6 = DungeDexBE.ConversionFunctions.Convert.DetermineProficiencyBonus(dungeMon17.ChallengeRating);
			int expected7 = DungeDexBE.ConversionFunctions.Convert.DetermineProficiencyBonus(dungeMon21.ChallengeRating);
			int expected8 = DungeDexBE.ConversionFunctions.Convert.DetermineProficiencyBonus(dungeMon25.ChallengeRating);
			int expected9 = DungeDexBE.ConversionFunctions.Convert.DetermineProficiencyBonus(dungeMon29.ChallengeRating);

			expected2.Should().Be(2);
			expected3.Should().Be(3);
			expected4.Should().Be(4);
			expected5.Should().Be(5);
			expected6.Should().Be(6);
			expected7.Should().Be(7);
			expected8.Should().Be(8);	
			expected9.Should().Be(9);
		}
	}
}
