using System.Text.Json;
using System.Text.Json.Serialization;

namespace livecode.core.Converters
{

    public class InputConverter : JsonConverter<dynamic>
    {
        public override dynamic Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                if (doc.RootElement.ValueKind == JsonValueKind.String)
                {
                    return doc.RootElement.GetString()!;
                }
                else if (doc.RootElement.ValueKind == JsonValueKind.Object)
                {
                    return JsonSerializer.Deserialize<ConstInputFormat>(doc.RootElement.GetRawText(), options)!;
                }
                else
                {
                    throw new JsonException("Unsupported type for VariableProperty");
                }
            }
        }

        public override void Write(Utf8JsonWriter writer, dynamic value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }

}
