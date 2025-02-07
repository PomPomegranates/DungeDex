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
			Dungemon dungeMon0 = new Dungemon { ChallengeRating = 0f };
			Dungemon dungeMon5 = new Dungemon { ChallengeRating = 5f };
			Dungemon dungeMon9 = new Dungemon { ChallengeRating = 9f };
			Dungemon dungeMon13 = new Dungemon { ChallengeRating = 13f };
			Dungemon dungeMon17 = new Dungemon { ChallengeRating = 17f };
			Dungemon dungeMon21 = new Dungemon { ChallengeRating = 21f };
			Dungemon dungeMon25 = new Dungemon { ChallengeRating = 25f };
			Dungemon dungeMon29 = new Dungemon { ChallengeRating = 29f };

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
