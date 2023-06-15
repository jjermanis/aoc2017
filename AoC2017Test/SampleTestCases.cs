
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
    }
}
