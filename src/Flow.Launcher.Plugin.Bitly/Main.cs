using System.Windows;
using System.Windows.Controls;
using Bitly.Net.v4;

namespace Flow.Launcher.Plugin.Bitly
{
    public class Main : IAsyncPlugin, IPluginI18n, ISettingProvider, IDisposable
    {
        public Main()
        {
            //this._storage = new PluginJsonStorage<Settings>();

            //link api:
            //https://support.bitly.com/hc/en-us/articles/231140388-How-do-I-find-my-API-key-
        }

        const string Token = "b0bf1fc066b12544dec7e55510eafabe995b8455";

        private PluginInitContext _context;
        private BitlyClient _client;
        //private readonly Settings _settings;

        public Task InitAsync(PluginInitContext context)
        {
            _context = context;
            _client = new BitlyClient(Token);
            return Task.CompletedTask;
        }

        public async Task<List<Result>> QueryAsync(Query query, CancellationToken token)
        {
            List<Result> results = new List<Result>();
            token.ThrowIfCancellationRequested();

            if (query.FirstSearch.Length > 0)
            {
                if (Uri.IsWellFormedUriString(query.Search, UriKind.Absolute))
                {
                    var response = await _client.ShortenAsync(query.Search);
                    if (response.Success)
                    {

                        var result = new Result
                        {
                            Title = response.Message,
                            SubTitle = response.Message,
                            IcoPath = "Images\\bitly.png",
                            Action = e =>
                            {

                                bool ret;
                                try
                                {
                                    _context.API.CopyToClipboard(response.Message);
                                    //_context.API.Start(shorten.Results.NodeKeyVal.ShortUrl);
                                    ret = true;
                                }
                                catch (Exception)
                                {
                                    _context.API.ShowMsg(string.Format(_context.API.GetTranslation("flow_plugin_url_canot_open_url"), query.Search));
                                    ret = false;
                                }
                                return ret;
                            }
                        };
                        results.Add(result);
                    }
                    else
                    {
                        results.Add(new Result { Title = "Error", SubTitle = response.Message, IcoPath = "Images\\bitly.png" });
                    }
                }
                else
                {
                    results.Add(new Result { Title = "URL invalid", IcoPath = "Images\\bitly.png" });
                }
            }
            return results;
        }

        public string GetTranslatedPluginTitle()
        {
            return _context.API.GetTranslation("flow_plugin_bitly_plugin_name");
        }

        public string GetTranslatedPluginDescription()
        {
            return _context.API.GetTranslation("flow_plugin_bitly_plugin_description");
        }

        public Control CreateSettingPanel()
        {
            return new BitlySettings();
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
