namespace Flow.Launcher.Plugin.Bitly.Core.Responses;

public abstract class BitlyBaseResponse
{
    public abstract bool Success { get; }
    public abstract string Message { get; }
}