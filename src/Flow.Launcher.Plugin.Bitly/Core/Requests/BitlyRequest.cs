using System.Text.Json.Serialization;

namespace Flow.Launcher.Plugin.Bitly.Core.Requests;

public class BitlyRequest
{
    [JsonPropertyName("long_url")]
    public string LongUrl { get; set; }
}