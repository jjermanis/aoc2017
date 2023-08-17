namespace AoC2017Test
{
    public class DayTestCases
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void Day01()
        {
            var d = new Day01();
            Assert.Multiple(() =>
            {
                Assert.That(d.CaptchaSumNeighbors(), Is.EqualTo(1049));
                Assert.That(d.CaptchaSumOpposite(), Is.EqualTo(1508));
            });
        }

        [Test]
        public void Day02()
        {
            var d = new Day02();
            Assert.Multiple(() =>
            {
                Assert.That(d.SumOfBiggestDifferences(), Is.EqualTo(50376));
                Assert.That(d.SumOfEvenlyDivisibleNumbers(), Is.EqualTo(267));
            });
        }

        [Test]
        public void Day03()
        {
            var d = new Day03();
            Assert.Multiple(() =>
            {
                Assert.That(d.DistanceByCount(), Is.EqualTo(438));
                Assert.That(d.NeighborSumLargerThanInput(), Is.EqualTo(266330));
            });
        }

        [Test]
        public void Day04()
        {
            var d = new Day04();
            Assert.Multiple(() =>
            {
                Assert.That(d.ValidCountExactMatch(), Is.EqualTo(466));
                Assert.That(d.ValidCountAnagrams(), Is.EqualTo(251));
            });
        }

        [Test]
        public void Day05()
        {
            var d = new Day05();
            Assert.Multiple(() =>
            {
                Assert.That(d.StepsToExit(), Is.EqualTo(373543));
                Assert.That(d.StepsWithAlternation(), Is.EqualTo(27502966));
            });
        }

        [Test]
        public void Day06()
        {
            var d = new Day06();
            Assert.Multiple(() =>
            {
                Assert.That(d.CyclesUntilDuplicate(), Is.EqualTo(3156));
                Assert.That(d.DuplicateLoopSize(), Is.EqualTo(1610));
            });
        }

        [Test]
        public void Day07()
        {
            var d = new Day07();
            Assert.Multiple(() =>
            {
                Assert.That(d.BottomNodeName(), Is.EqualTo("dgoocsw"));
                Assert.That(d.WeightToAlterTo(), Is.EqualTo(1275));
            });
        }

        [Test]
        public void Day08()
        {
            var d = new Day08();
            Assert.Multiple(() =>
            {
                Assert.That(d.MaxValueAtEnd(), Is.EqualTo(7296));
                Assert.That(d.MaxValueEver(), Is.EqualTo(8186));
            });
        }

        [Test]
        public void Day09()
        {
            var d = new Day09();
            Assert.Multiple(() =>
            {
                Assert.That(d.Score(), Is.EqualTo(14190));
                Assert.That(d.CharsInGarbageCount(), Is.EqualTo(7053));
            });
        }

        [Test]
        public void Day10()
        {
            var d = new Day10();
            Assert.Multiple(() =>
            {
                Assert.That(d.KnottedListProduct(), Is.EqualTo(1935));
                Assert.That(d.KnotHash(), Is.EqualTo("dc7e7dee710d4c7201ce42713e6b8359"));
            });
        }

        [Test]
        public void Day11()
        {
            var d = new Day11();
            Assert.Multiple(() =>
            {
                Assert.That(d.EndStepCount(), Is.EqualTo(698));
                Assert.That(d.MaxStepCount(), Is.EqualTo(1435));
            });
        }

        [Test]
        public void Day12()
        {
            var d = new Day12();
            Assert.Multiple(() =>
            {
                Assert.That(d.FirstProgramCount(), Is.EqualTo(152));
                Assert.That(d.GroupCount(), Is.EqualTo(186));
            });
        }

        [Test]
        public void Day13()
        {
            var d = new Day13();
            Assert.Multiple(() =>
            {
                Assert.That(d.TripSeverity(), Is.EqualTo(648));
                Assert.That(d.SafeDelay(), Is.EqualTo(3933124));
            });
        }

        [Test]
        public void Day14()
        {
            var d = new Day14();
            Assert.Multiple(() =>
            {
                Assert.That(d.SquareCount(), Is.EqualTo(8304));
                Assert.That(d.RegionCount(), Is.EqualTo(1018));
            });
        }

        [Test]
        public void Day15()
        {
            var d = new Day15();
            Assert.Multiple(() =>
            {
                Assert.That(d.MatchingCount(), Is.EqualTo(594));
                Assert.That(d.MatchingCountWithMultiples(), Is.EqualTo(328));
            });
        }

        [Test]
        public void Day16()
        {
            var d = new Day16();
            Assert.Multiple(() =>
            {
                Assert.That(d.PositionAfterDance(), Is.EqualTo("jcobhadfnmpkglie"));
                Assert.That(d.PositionAfterGigaDance(), Is.EqualTo("pclhmengojfdkaib"));
            });
        }

        [Test]
        public void Day17()
        {
            var d = new Day17();
            Assert.Multiple(() =>
            {
                Assert.That(d.ValueAfter2017(), Is.EqualTo(136));
                Assert.That(d.ValueAfter0(), Is.EqualTo(1080289));
            });
        }

        [Test]
        public void Day18()
        {
            var d = new Day18();
            Assert.Multiple(() =>
            {
                Assert.That(d.LastSoundPlayed(), Is.EqualTo(9423));
                Assert.That(d.PlayedSoundCount(), Is.EqualTo(7620));
            });
        }

        [Test]
        public void Day19()
        {
            var d = new Day19();
            Assert.Multiple(() =>
            {
                Assert.That(d.PathLetters(), Is.EqualTo("YOHREPXWN"));
                Assert.That(d.PathStepCount(), Is.EqualTo(16734));
            });
        }

        [Test]
        public void Day20()
        {
            var d = new Day20();
            Assert.Multiple(() =>
            {
                Assert.That(d.ParticleStayingClosestToOrigin(), Is.EqualTo(308));
                Assert.That(d.ParticleCountAfterCollisions(), Is.EqualTo(504));
            });
        }

        [Test]
        public void Day21()
        {
            var d = new Day21();
            Assert.Multiple(() =>
            {
                Assert.That(d.PixelsAfter5Iterations(), Is.EqualTo(205));
                Assert.That(d.PixelsAfter18Iterations(), Is.EqualTo(3389823));
            });
        }

        [Test]
        public void Day22()
        {
            var d = new Day22();
            Assert.Multiple(() =>
            {
                Assert.That(d.InfectionBurstCount(), Is.EqualTo(5266));
                Assert.That(d.EvolvedBurstCount(), Is.EqualTo(2511895));
            });
        }

        [Test]
        public void Day23()
        {
            var d = new Day23();
            Assert.Multiple(() =>
            {
                Assert.That(d.MulInstructionCount(), Is.EqualTo(4225));
                Assert.That(d.FinalValueInRegisterH(), Is.EqualTo(905));
            });
        }

        [Test]
        public void Day24()
        {
            var d = new Day24();
            Assert.Multiple(() =>
            {
                Assert.That(d.StrongestBridgeStrength(), Is.EqualTo(1511));
                Assert.That(d.LongestBridgeStrength(), Is.EqualTo(1471));
            });
        }
    }
}