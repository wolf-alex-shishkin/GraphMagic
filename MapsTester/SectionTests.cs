using GraphMagic.Maps;
using NUnit.Framework;

namespace GraphMagic.MapsTester
{
    [TestFixture()]
    public class SectionTests
    {
        [Test()]
        public void TestCase1ForTrue()
        {
            var section1 = new Section(0, 5);
            var section2 = new Section(0, 10);

            Assert.That(section1.Intersects(section2), Is.True);
        }

        [Test()]
        public void TestCase2ForTrue()
        {
            var section1 = new Section(0, 10);
            var section2 = new Section(0, 5);

            Assert.That(section1.Intersects(section2), Is.True);
        }

        [Test()]
        public void TestCase3ForTrue()
        {
            var section1 = new Section(0, 5);
            var section2 = new Section(0, 5);

            Assert.That(section1.Intersects(section2), Is.True);
        }

        [Test()]
        public void TestCase4ForFalse()
        {
            var section1 = new Section(0, 5);
            var section2 = new Section(6, 11);

            Assert.That(section1.Intersects(section2), Is.False);
        }

        [Test()]
        public void TestCase5ForTrue()
        {
            var section1 = new Section(0, 5);
            var section2 = new Section(5, 10);

            Assert.That(section1.Intersects(section2), Is.True);
        }

        [Test()]
        public void TestCase6ForTrue()
        {
            var section1 = new Section(0, 5);
            var section2 = new Section(3, 11);

            Assert.That(section1.Intersects(section2), Is.True);
        }

        [Test()]
        public void TestCase7ForTrue()
        {
            var section1 = new Section(3, 11);
            var section2 = new Section(0, 5);

            Assert.That(section1.Intersects(section2), Is.True);
        }

        [Test()]
        public void TestCase8ForTrue()
        {
            var section1 = new Section(0, 5);
            var section2 = new Section(3, 5);

            Assert.That(section1.Intersects(section2), Is.True);
        }

        [Test()]
        public void TestCase9ForTrue()
        {
            var section1 = new Section(3, 5);
            var section2 = new Section(0, 5);

            Assert.That(section1.Intersects(section2), Is.True);
        }

        [Test()]
        public void TestCase10ForTrue()
        {
            var section1 = new Section(0, 5);
            var section2 = new Section(2, 3);

            Assert.That(section1.Intersects(section2), Is.True);
        }

        [Test()]
        public void TestCase11ForTrue()
        {
            var section1 = new Section(2, 3);
            var section2 = new Section(0, 5);

            Assert.That(section1.Intersects(section2), Is.True);
        }
    }
}
