using System.Text.Json;
using System.Text.Json.Serialization;

namespace EcommerceCRUD2.Models
{
    public class ActionConverter : JsonConverter<Action>
    {
        public override Action Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Implementar deserialización personalizada si es necesario
            return null; // O retornar el método que deseas
        }

        public override void Write(Utf8JsonWriter writer, Action value, JsonSerializerOptions options)
        {
            // Implementar serialización personalizada si es necesario
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
    }
}
