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
    }
}