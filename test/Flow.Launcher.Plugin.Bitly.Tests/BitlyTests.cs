using Bitly.Net.v4;

namespace Flow.Launcher.Plugin.Bitly.Tests
{
    public class BitlyTests
    {
        private readonly BitlyClient _client;
        private const string Token = "b0bf1fc066b12544dec7e55510eafabe995b8455";

        public BitlyTests()
        {
            _client = new BitlyClient(Token);
        }

        [Fact]
        public async Task TestBitlyClient()
        {
            var url = "https://totpe.ro";
            var r = await _client.ShortenAsync(url);

            Assert.NotNull(r);
            Assert.True(r.Success);
        }
    }
}