namespace Flow.Launcher.Plugin.Bitly.Core.Responses;

public class BitlyGeneralErrorResponse : BitlyBaseResponse
{
    public BitlyGeneralErrorResponse(string message)
    {
        Message = message;
    }

    public override bool Success => false;
    public override string Message { get; }
}