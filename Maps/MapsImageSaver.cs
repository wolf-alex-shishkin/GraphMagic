using System;
using System.IO;
using System.Linq;
using System.Drawing;

namespace GraphMagic.Maps
{
    public class MapsImageSaver
    {
        private const int Offset = 10;
        private const int PointSize = 10;
        private Brush BackGroundBrush = Brushes.White;
        private Brush StartPointBrush = Brushes.Red;
        private Brush FinishPointBrush = Brushes.Green;
        private Brush RectangleBrush = Brushes.Blue;

        public void Save(Map map, Stream stream, int size, System.Drawing.Imaging.ImageFormat format)
        {
            var scale = CalcScale(map, size);
            var image = PrepareImage(map, scale);
            DrawImage(image, map, scale);
            SaveImage(image, stream, format);
        }

        private void SaveImage(Bitmap image, Stream stream, System.Drawing.Imaging.ImageFormat format)
        {
            image.Save(stream, format);
        }

        private void DrawImage(Bitmap image, Map map, ScalingInfo scale)
        {
            var graphics = Graphics.FromImage(image);
            graphics.FillRectangle(BackGroundBrush, 0, 0, scale.XSize - 1, scale.YSize - 1);
            var pointShift = (PointSize - 1) / 2;
            graphics.FillEllipse(StartPointBrush, new Rectangle(GetScaledX(map.StartPoint.X, scale) - pointShift, GetScaledY(map.StartPoint.Y, scale) - pointShift, PointSize, PointSize));
            graphics.FillEllipse(FinishPointBrush, new Rectangle(GetScaledX(map.FinishPoint.X, scale) - pointShift, GetScaledY(map.FinishPoint.Y, scale) - pointShift, PointSize, PointSize));
            foreach (var rect in map.Rects)
                graphics.FillRectangle(RectangleBrush, GetScaledX(rect.VertexUL.X, scale), GetScaledY(rect.VertexUL.Y, scale), GetScaledSize(rect.Width, scale), GetScaledSize(rect.Height, scale));
        }

        private Bitmap PrepareImage(Map map, ScalingInfo scale)
        {
            return new Bitmap(scale.XSize, scale.YSize);
        }

        private ScalingInfo CalcScale(Map map, int size)
        {
            var points = map.Rects.SelectMany(r => r.Vertexes).Concat(new Point[] { map.StartPoint, map.FinishPoint });
            var xMin = points.Select(p => p.X).Min();
            var xMax = points.Select(p => p.X).Max();
            var yMin = points.Select(p => p.Y).Min();
            var yMax = points.Select(p => p.Y).Max();
            var xSize = size;
            var ySize = size;
            var scale = 1.0;
            if ((xMax - xMin) >= (yMax - yMin))
            {
                scale = ((double)(size - 2 * Offset)) / (xMax - xMin);
                ySize = (int)Math.Round((yMax - yMin) * scale) + 2 * Offset;
            }
            else
            {
                scale = ((double)(size - 2 * Offset)) / (yMax - yMin);
                xSize = (int)Math.Round((xMax - xMin) * scale) + 2 * Offset;
            }
            return new ScalingInfo(xMin, xMax, yMin, yMax, xSize, ySize, Offset, Offset, scale);
        }

        private int GetScaledX(int x, ScalingInfo scale)
        {
            return (int)Math.Round(scale.XOffset + (x - scale.XMin) * scale.Scale);
        }

        private int GetScaledY(int y, ScalingInfo scale)
        {
            return (int)Math.Round(scale.YOffset + (y - scale.YMin) * scale.Scale);
        }

        private int GetScaledSize(int size, ScalingInfo scale)
        {
            return (int)Math.Round(size * scale.Scale);
        }
    }
}
