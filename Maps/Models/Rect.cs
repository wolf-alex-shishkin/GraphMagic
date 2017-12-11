namespace GraphMagic.Maps
{
    public class Rect
    {
        public Point VertexUL { get; private set; }

        public Point VertexUR { get; private set; }

        public Point VertexDL { get; private set; }

        public Point VertexDR { get; private set; }

        public Section ProjectionX
        {
            get
            {
                return new Section(VertexUL.X, VertexDR.X);
            }
        }

        public Section ProjectionY
        {
            get
            {
                return new Section(VertexUL.Y, VertexDR.Y);
            }
        }

        public Rect(Point p1, Point p2)
        {
            var minX = p1.X < p2.X ? p1.X : p2.X;
            var maxX = p1.X > p2.X ? p1.X : p2.X;
            var minY = p1.Y < p2.Y ? p1.Y : p2.Y;
            var maxY = p1.Y > p2.Y ? p1.Y : p2.Y;

            VertexUL = new Point(minX, minY);
            VertexUR = new Point(maxX, minY);
            VertexDL = new Point(minX, maxY);
            VertexDR = new Point(maxX, maxY);
        }

        public bool Intersects(Rect rect)
        {
            return ProjectionX.Intersects(rect.ProjectionX) && ProjectionY.Intersects(rect.ProjectionY);
        }
    }
}
