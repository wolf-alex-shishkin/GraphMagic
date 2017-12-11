namespace GraphMagic.Maps
{
    public class Map
    {
        public Point StartPoint { get; private set; }

        public Point FinishPoint { get; private set; }

        public Rect[] Rects { get; private set; }

        public Map(Point startPoint, Point finishPoint, Rect[] rects)
        {
            StartPoint = startPoint;
            FinishPoint = finishPoint;
            Rects = rects;
        }
    }
}
