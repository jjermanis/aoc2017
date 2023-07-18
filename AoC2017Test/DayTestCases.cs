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
    }
}