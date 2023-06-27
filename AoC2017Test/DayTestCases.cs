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
    }
}