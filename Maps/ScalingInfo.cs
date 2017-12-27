namespace GraphMagic.Maps
{
    public class ScalingInfo
    {
        public int XMin { get; private set; }

        public int XMax { get; private set; }

        public int YMin { get; private set; }

        public int YMax { get; private set; }

        public int XSize { get; private set; }

        public int YSize { get; private set; }

        public int XOffset { get; private set; }

        public int YOffset { get; private set; }

        public double Scale { get; private set; }

        public ScalingInfo(int xMin, int xMax, int yMin, int yMax, int xSize, int ySize, int xOffset, int yOffset, double scale)
        {
            XMin = xMin;
            XMax = xMax;
            YMin = yMin;
            YMax = yMax;
            XSize = xSize;
            YSize = ySize;
            XOffset = xOffset;
            YOffset = yOffset;
            Scale = scale;
        }
    }
}
