using System.Text.Json.Serialization;

namespace KonchuSugoizeNotifyLambda.Resources.Nhk
{
    public class NhkProgram
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("event_id")]
        public string EventId { get; set; }

        [JsonPropertyName("start_time")]
        public string StartTime { get; set; }

        [JsonPropertyName("end_time")]
        public string EndTime { get; set; }

        [JsonPropertyName("area")]
        public Area Area { get; set; }

        [JsonPropertyName("service")]
        public Service Service { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("subtitle")]
        public string SubTitle { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("act")]
        public string Act { get; set; }

        [JsonPropertyName("genres")]
        public List<string> Genres { get; set; }

        // 以下は内部処理用に設けるプロパティ

        [JsonPropertyName("areas")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Area>? Areas { get; set; } = null;

        public NhkProgram CopyForInternalLogic()
        {
            return new NhkProgram
            {
                Id = Id,
                EventId = EventId,
                StartTime = StartTime,
                EndTime = EndTime,
                Area = null,
                Areas = new List<Area> { Area },
                Service = Service,
                Title = Title,
                SubTitle = SubTitle,
                Content = Content,
                Act = Act,
                Genres = Genres
            };
        }
    }
}
