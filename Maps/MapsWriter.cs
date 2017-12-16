using System.IO;
using Newtonsoft.Json;

namespace GraphMagic.Maps
{
    public class MapsWriter
    {
        public void Write(Map map, Stream stream)
        {
            var writer = new StreamWriter(stream);
            var jsonWriter = new JsonTextWriter(writer);
            jsonWriter.Formatting = Formatting.Indented;
            var jsonSerializer = new JsonSerializer();
            jsonSerializer.Serialize(jsonWriter, map);
            jsonWriter.Flush();
        }
    }
}
