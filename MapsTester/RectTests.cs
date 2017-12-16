using GraphMagic.Maps;
using NUnit.Framework;

namespace GraphMagic.MapsTester
{
    [TestFixture()]
    public class RectTests
    {
        [Test()]
        public void TestIntersectsCase1ForFalse()
        {
            var rect1 = new Rect(new Point(0, 0), new Point(1, 1));
            var rect2 = new Rect(new Point(2, 0), new Point(3, 2));

            Assert.That(rect1.Intersects(rect2), Is.False);
        }

        [Test()]
        public void TestIntersectsCase2ForTrue()
        {
            var rect1 = new Rect(new Point(0, 0), new Point(2, 2));
            var rect2 = new Rect(new Point(1, 1), new Point(3, 3));

            Assert.That(rect1.Intersects(rect2), Is.True);
        }

        [Test()]
        public void TestIntersectsCase3ForTrue()
        {
            var rect1 = new Rect(new Point(0, 0), new Point(4, 4));
            var rect2 = new Rect(new Point(1, 1), new Point(3, 3));

            Assert.That(rect1.Intersects(rect2), Is.True);
        }

        [Test()]
        public void TestIntersectsCase4ForTrue()
        {
            var rect1 = new Rect(new Point(1, 1), new Point(3, 3));
            var rect2 = new Rect(new Point(0, 0), new Point(4, 4));

            Assert.That(rect1.Intersects(rect2), Is.True);
        }

        [Test()]
        public void TestIntersectsCase5ForTrue()
        {
            var rect1 = new Rect(new Point(1, 1), new Point(3, 3));
            var rect2 = new Rect(new Point(1, 1), new Point(3, 3));

            Assert.That(rect1.Intersects(rect2), Is.True);
        }

        [Test()]
        public void TestIntersectsCase6ForTrue()
        {
            var rect1 = new Rect(new Point(1, 1), new Point(3, 3));
            var rect2 = new Rect(new Point(3, 1), new Point(6, 3));

            Assert.That(rect1.Intersects(rect2), Is.True);
        }

        [Test()]
        public void TestIntersectsCase7ForTrue()
        {
            var rect1 = new Rect(new Point(1, 1), new Point(3, 3));
            var rect2 = new Rect(new Point(1, 3), new Point(3, 4));

            Assert.That(rect1.Intersects(rect2), Is.True);
        }

        [Test()]
        public void TestIntersectsCase8ForTrue()
        {
            var rect1 = new Rect(new Point(1, 1), new Point(3, 3));
            var rect2 = new Rect(new Point(3, 3), new Point(4, 4));

            Assert.That(rect1.Intersects(rect2), Is.True);
        }

        [Test()]
        public void TestContainsCase1ForTrue()
        {
            var rect = new Rect(new Point(1, 1), new Point(3, 3));
            var point = new Point(2, 2);

            Assert.That(rect.Contains(point), Is.True);
        }

        [Test()]
        public void TestContainsCase2ForTrue()
        {
            var rect = new Rect(new Point(1, 1), new Point(3, 3));
            var point = new Point(1, 3);

            Assert.That(rect.Contains(point), Is.True);
        }

        [Test()]
        public void TestContainsCase3ForTrue()
        {
            var rect = new Rect(new Point(1, 1), new Point(3, 3));
            var point = new Point(3, 2);

            Assert.That(rect.Contains(point), Is.True);
        }

        [Test()]
        public void TestContainsCase4ForFalse()
        {
            var rect = new Rect(new Point(1, 1), new Point(3, 3));
            var point = new Point(0, 2);

            Assert.That(rect.Contains(point), Is.False);
        }

        [Test()]
        public void TestContainsCase5ForFalse()
        {
            var rect = new Rect(new Point(1, 1), new Point(3, 3));
            var point = new Point(2, 0);

            Assert.That(rect.Contains(point), Is.False);
        }
    }
}
