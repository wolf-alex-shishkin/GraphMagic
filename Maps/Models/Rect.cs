﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace GraphMagic.Maps
{
    public class Rect
    {
        public Point VertexUL { get; private set; }

        [JsonIgnore]
        public Point VertexUR { get; private set; }

        [JsonIgnore]
        public Point VertexDL { get; private set; }

        public Point VertexDR { get; private set; }

        [JsonIgnore]
        public IEnumerable<Point> Vertexes
        {
            get
            {
                return new Point[] { VertexUL, VertexUR, VertexDL, VertexDR };
            }
        }

        [JsonIgnore]
        public int Width
        {
            get
            {
                return VertexDR.X - VertexUL.X;
            }
        }

        [JsonIgnore]
        public int Height
        {
            get
            {
                return VertexDR.Y - VertexUL.Y;
            }
        }

        [JsonIgnore]
        public Section ProjectionX
        {
            get
            {
                return new Section(VertexUL.X, VertexDR.X);
            }
        }

        [JsonIgnore]
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
        public bool Contains(Point point)
        {
            return (ProjectionX.LeftNum <= point.X) && (ProjectionX.RightNum >= point.X)
                && (ProjectionY.LeftNum <= point.Y) && (ProjectionY.RightNum >= point.Y);
        }
    }
}
