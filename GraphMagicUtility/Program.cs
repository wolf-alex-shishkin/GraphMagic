using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphMagic.Maps;
using System.IO;

namespace GraphMagicUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapsGenerator = new MapsGenerator(1024);
            var map = mapsGenerator.Generate(10);
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
