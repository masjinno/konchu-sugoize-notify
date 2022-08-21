using System.Text.Json.Serialization;

namespace KonchuSugoizeNotifyLambda.Resources.Nhk
{
    public class Area
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
