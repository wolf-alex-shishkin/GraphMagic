using GraphMagic.Maps;
using System.IO;
using System.Drawing;

namespace GraphMagic.GraphMagicUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            var startParamsParser = new StartParamsParser();
            var startParams = startParamsParser.Parse(args);
            var mapsGenerator = new MapsGenerator(startParams.FieldSize);
            if (!Directory.Exists(startParams.FolderPath))
                Directory.CreateDirectory(startParams.FolderPath);
            foreach (var folder in Directory.EnumerateDirectories(startParams.FolderPath))
                Directory.Delete(folder, true);
            foreach (var file in Directory.EnumerateFiles(startParams.FolderPath))
                File.Delete(file);
            var writer = new MapsWriter();
            var imageSaver = new MapsImageSaver();
            int imageSize;
            switch (startParams.ImageMode)
            {
                case ImageModeType.Small:
                    imageSize = 1024;
                    break;
                case ImageModeType.Large:
                    imageSize = 4096;
                    break;
                default:
                    imageSize = startParams.FieldSize.Value;
                    break;
            }
            for (var i = 1; i <= startParams.MapsNum; i++)
            {
                var map = mapsGenerator.Generate(startParams.RectsNum);
                var fileName = $"map{i}.json";
                var filePath = Path.Combine(startParams.FolderPath, fileName);
                var stream = File.OpenWrite(filePath);
                writer.Write(map, stream);
                fileName = $"map{i}.png";
                filePath = Path.Combine(startParams.FolderPath, fileName);
                stream = File.OpenWrite(filePath);               
                imageSaver.Save(map, stream, imageSize, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
