using System.Text.Json.Serialization;

namespace KonchuSugoizeNotifyLambda.Resources.Nhk
{
    public class Logo
    {

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("width")]
        public string Width { get; set; }

        [JsonPropertyName("height")]
        public string Height { get; set; }
    }
}
