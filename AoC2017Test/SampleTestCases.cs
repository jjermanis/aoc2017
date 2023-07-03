
namespace AoC2017Test
{
    internal class SampleTestCases
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Day01()
        {
            var t1 = new Day01("Day01Test01.txt");
            Assert.That(t1.CaptchaSumNeighbors(), Is.EqualTo(3));

            var t2 = new Day01("Day01Test02.txt");
            Assert.That(t2.CaptchaSumNeighbors(), Is.EqualTo(4));

            var t3 = new Day01("Day01Test03.txt");
            Assert.That(t3.CaptchaSumNeighbors(), Is.EqualTo(0));

            var t4 = new Day01("Day01Test04.txt");
            Assert.That(t4.CaptchaSumNeighbors(), Is.EqualTo(9));

            var t5 = new Day01("Day01Test05.txt");
            Assert.That(t5.CaptchaSumOpposite(), Is.EqualTo(6));

            var t6 = new Day01("Day01Test06.txt");
            Assert.That(t6.CaptchaSumOpposite(), Is.EqualTo(0));

            var t7 = new Day01("Day01Test07.txt");
            Assert.That(t7.CaptchaSumOpposite(), Is.EqualTo(4));

            var t8 = new Day01("Day01Test08.txt");
            Assert.That(t8.CaptchaSumOpposite(), Is.EqualTo(12));

            var t9 = new Day01("Day01Test09.txt");
            Assert.That(t9.CaptchaSumOpposite(), Is.EqualTo(4));
        }

        [Test]
        public void Day02()
        {
            var t1 = new Day02("Day02Test01.txt");
            Assert.That(t1.SumOfBiggestDifferences(), Is.EqualTo(18));

            var t2 = new Day02("Day02Test02.txt");
            Assert.That(t2.SumOfEvenlyDivisibleNumbers(), Is.EqualTo(9));
        }

        [Test]
        public void Day03()
        {
            var t11 = new Day03(1);
            Assert.That(t11.DistanceByCount(), Is.EqualTo(0));
            var t12 = new Day03(12);
            Assert.That(t12.DistanceByCount(), Is.EqualTo(3));
            var t13 = new Day03(23);
            Assert.That(t13.DistanceByCount(), Is.EqualTo(2));
            var t14 = new Day03(1024);
            Assert.That(t14.DistanceByCount(), Is.EqualTo(31));

            var t21 = new Day03(9);
            Assert.That(t21.NeighborSumLargerThanInput(), Is.EqualTo(10));
            var t22 = new Day03(50);
            Assert.That(t22.NeighborSumLargerThanInput(), Is.EqualTo(54));
            var t23 = new Day03(500);
            Assert.That(t23.NeighborSumLargerThanInput(), Is.EqualTo(747));
        }

        [Test]
        public void Day04()
        {
            var t1 = new Day04("Day04Test01.txt");
            Assert.That(t1.ValidCountExactMatch(), Is.EqualTo(2));

            var t2 = new Day04("Day04Test02.txt");
            Assert.That(t2.ValidCountAnagrams(), Is.EqualTo(3));
        }

        [Test]
        public void Day05()
        {
            var t = new Day05("Day05Test01.txt");
            Assert.Multiple(() =>
            {
                Assert.That(t.StepsToExit(), Is.EqualTo(5));
                Assert.That(t.StepsWithAlternation(), Is.EqualTo(10));
            });
        }

        [Test]
        public void Day06()
        {
            var t = new Day06("Day06Test01.txt");
            Assert.Multiple(() =>
            {
                Assert.That(t.CyclesUntilDuplicate(), Is.EqualTo(5));
                Assert.That(t.DuplicateLoopSize(), Is.EqualTo(4));
            });
        }
    }
}
