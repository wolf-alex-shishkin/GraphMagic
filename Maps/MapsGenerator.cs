﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphMagic.Maps
{
    public class MapsGenerator
    {
        private readonly Random rnd;
        private readonly int fieldSize;

        public MapsGenerator(int? fieldSize = null, int? initNum = null)
        {
            rnd = initNum.HasValue ? new Random(initNum.Value) : new Random();
            this.fieldSize = fieldSize.HasValue ? fieldSize.Value : int.MaxValue;
        }

        public Map Generate(int rectNum)
        {
            var startPoint = GeneratePoint();
            var finishPoint = GeneratePoint();
            var rects = GenerateRects(startPoint, finishPoint, rectNum);
            var map = new Map(startPoint, finishPoint, rects);
            return map;
        }

        private Rect[] GenerateRects(Point startPoint, Point finishPoint, int rectNum)
        {
            var rects = new List<Rect>();
            var count = 0;
            while(count < rectNum)
            {
                var rect = GenerateRect();
                if (!RectIsValid(rect, startPoint, finishPoint, rects))
                    continue;
                rects.Add(rect);
                count++;
            }
            return rects.ToArray();
        }

        private bool RectIsValid(Rect rect, Point startPoint, Point finishPoint, List<Rect> rects)
        {
            var baseRect = new Rect(startPoint, finishPoint);
            if (!rect.Intersects(baseRect))
                return false;
            if (rect.Contains(startPoint) || rect.Contains(finishPoint))
                return false;
            return rects.All(r => !rect.Intersects(r));
        }

        private Rect GenerateRect()
        {
            var point1 = GeneratePoint();
            var point2 = GeneratePoint();
            var rect = new Rect(point1, point2);
            return rect;
        }

        private Point GeneratePoint()
        {
            var x = rnd.Next(fieldSize);
            var y = rnd.Next(fieldSize);
            var point = new Point(x, y);
            return point;
        }
    }
}
