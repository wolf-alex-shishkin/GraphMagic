using GraphMagic.Maps;
using NUnit.Framework;

namespace GraphMagic.MapsTester
{
    [TestFixture()]
    public class SectionTests
    {
        [Test()]
        public void TestIntersectsCase1ForTrue()
        {
            var section1 = new Section(0, 5);
            var section2 = new Section(0, 10);

            Assert.That(section1.Intersects(section2), Is.True);
        }

        [Test()]
        public void TestIntersectsCase2ForTrue()
        {
            var section1 = new Section(0, 10);
            var section2 = new Section(0, 5);

            Assert.That(section1.Intersects(section2), Is.True);
        }

        [Test()]
        public void TestIntersectsCase3ForTrue()
        {
            var section1 = new Section(0, 5);
            var section2 = new Section(0, 5);

            Assert.That(section1.Intersects(section2), Is.True);
        }

        [Test()]
        public void TestIntersectsCase4ForFalse()
        {
            var section1 = new Section(0, 5);
            var section2 = new Section(6, 11);

            Assert.That(section1.Intersects(section2), Is.False);
        }

        [Test()]
        public void TestIntersectsCase5ForTrue()
        {
            var section1 = new Section(0, 5);
            var section2 = new Section(5, 10);

            Assert.That(section1.Intersects(section2), Is.True);
        }

        [Test()]
        public void TestIntersectsCase6ForTrue()
        {
            var section1 = new Section(0, 5);
            var section2 = new Section(3, 11);

            Assert.That(section1.Intersects(section2), Is.True);
        }

        [Test()]
        public void TestIntersectsCase7ForTrue()
        {
            var section1 = new Section(3, 11);
            var section2 = new Section(0, 5);

            Assert.That(section1.Intersects(section2), Is.True);
        }

        [Test()]
        public void TestIntersectsCase8ForTrue()
        {
            var section1 = new Section(0, 5);
            var section2 = new Section(3, 5);

            Assert.That(section1.Intersects(section2), Is.True);
        }

        [Test()]
        public void TestIntersectsCase9ForTrue()
        {
            var section1 = new Section(3, 5);
            var section2 = new Section(0, 5);

            Assert.That(section1.Intersects(section2), Is.True);
        }

        [Test()]
        public void TestIntersectsCase10ForTrue()
        {
            var section1 = new Section(0, 5);
            var section2 = new Section(2, 3);

            Assert.That(section1.Intersects(section2), Is.True);
        }

        [Test()]
        public void TestIntersectsCase11ForTrue()
        {
            var section1 = new Section(2, 3);
            var section2 = new Section(0, 5);

            Assert.That(section1.Intersects(section2), Is.True);
        }
    }
}
