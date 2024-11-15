using System.Text.Json;

namespace DeveloperTools.Pages.Tools.JsonFormatter;
public class JsonFormatter
{
    private JsonSerializerOptions _jsonSerializerOptions;

    public JsonFormatter()
    {
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };
    }

    public string FormatJson(string json)
    {
        try
        {
            var jsonElement = JsonDocument.Parse(json).RootElement;
            return JsonSerializer.Serialize(jsonElement, _jsonSerializerOptions);
        }
        catch
        {
            return json;
        }

    }
}
