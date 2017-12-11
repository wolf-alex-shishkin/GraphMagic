using GraphMagic.Maps;
using NUnit.Framework;

namespace GraphMagic.MapsTester
{
    [TestFixture()]
    public class RectTests
    {
        [Test()]
        public void TestCase1ForFalse()
        {
            var rect1 = new Rect(new Point(0, 0), new Point(1, 1));
            var rect2 = new Rect(new Point(2, 0), new Point(3, 2));

            Assert.That(rect1.Intersects(rect2), Is.False);
        }

        [Test()]
        public void TestCase2ForTrue()
        {
            var rect1 = new Rect(new Point(0, 0), new Point(2, 2));
            var rect2 = new Rect(new Point(1, 1), new Point(3, 3));

            Assert.That(rect1.Intersects(rect2), Is.True);
        }

        [Test()]
        public void TestCase3ForTrue()
        {
            var rect1 = new Rect(new Point(0, 0), new Point(4, 4));
            var rect2 = new Rect(new Point(1, 1), new Point(3, 3));

            Assert.That(rect1.Intersects(rect2), Is.True);
        }

        [Test()]
        public void TestCase4ForTrue()
        {
            var rect1 = new Rect(new Point(1, 1), new Point(3, 3));
            var rect2 = new Rect(new Point(0, 0), new Point(4, 4));

            Assert.That(rect1.Intersects(rect2), Is.True);
        }

        [Test()]
        public void TestCase5ForTrue()
        {
            var rect1 = new Rect(new Point(1, 1), new Point(3, 3));
            var rect2 = new Rect(new Point(1, 1), new Point(3, 3));

            Assert.That(rect1.Intersects(rect2), Is.True);
        }

        [Test()]
        public void TestCase6ForTrue()
        {
            var rect1 = new Rect(new Point(1, 1), new Point(3, 3));
            var rect2 = new Rect(new Point(3, 1), new Point(6, 3));

            Assert.That(rect1.Intersects(rect2), Is.True);
        }

        [Test()]
        public void TestCase7ForTrue()
        {
            var rect1 = new Rect(new Point(1, 1), new Point(3, 3));
            var rect2 = new Rect(new Point(1, 3), new Point(3, 4));

            Assert.That(rect1.Intersects(rect2), Is.True);
        }

        [Test()]
        public void TestCase8ForTrue()
        {
            var rect1 = new Rect(new Point(1, 1), new Point(3, 3));
            var rect2 = new Rect(new Point(3, 3), new Point(4, 4));

            Assert.That(rect1.Intersects(rect2), Is.True);
        }
    }
}
