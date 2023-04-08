namespace Flow.Launcher.Plugin.Bitly.Core.Responses;

public class BitlySuccessResponse : BitlyBaseResponse
{
    public string created_at { get; set; }
    public string id { get; set; }
    public string link { get; set; }
    public object[] custom_bitlinks { get; set; }
    public string long_url { get; set; }
    public bool archived { get; set; }
    public object[] tags { get; set; }
    public object[] deeplinks { get; set; }
    public BitlyResponseReferences references { get; set; }

    public override bool Success => true;
    public override string Message => link;
}