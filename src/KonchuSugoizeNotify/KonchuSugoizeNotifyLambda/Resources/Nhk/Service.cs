using System.Text.Json.Serialization;

namespace KonchuSugoizeNotifyLambda.Resources.Nhk
{
    public class Service
    {

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("logo_s")]
        public Logo LogoS { get; set; }

        [JsonPropertyName("logo_m")]
        public Logo LogoM { get; set; }

        [JsonPropertyName("logo_l")]
        public Logo LogoL { get; set; }
    }
}
