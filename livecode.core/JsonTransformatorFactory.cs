
using System.Text.Json;

namespace livecode.core
{
    public class JsonTransformatorFactory
    {

        public JsonTransformator GenerateParser(string jsonMap)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };


            var mapFormats = JsonSerializer.Deserialize<IEnumerable<MapFormat>>(jsonMap, options)!;
            

            return new JsonTransformator(mapFormats.SelectMany(m => m.Map));
        }
    }
}
