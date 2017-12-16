using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphMagic.Maps;
using System.IO;

namespace GraphMagic.GraphMagicUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            var startParamsParser = new StartParamsParser();
            var startParams = startParamsParser.Parse(args);
            var mapsGenerator = new MapsGenerator(startParams.FieldSize);
            var map = mapsGenerator.Generate(startParams.RectsNum);
            var stream = new MemoryStream();
            var writer = new MapsWriter();
            writer.Write(map, stream);
            stream.Position = 0;
            var reader = new StreamReader(stream);
            var mapString = reader.ReadToEnd();
            Console.Write(mapString);
            Console.ReadLine();
        }
    }
}
