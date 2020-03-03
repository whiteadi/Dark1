using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dark1.Models;
using Newtonsoft.Json;

namespace Dark1.Data
{
    public class RestService
    {
        HttpClient _client;

        public TheJoke Joke { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<TheJoke> RefreshDataAsync()
        {
            var definition = new { type = "", joke = "", setup = "", delivery = "" };
            var uri = new Uri(string.Format(Constants.JokesUrl, string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var joke = JsonConvert.DeserializeAnonymousType(content, definition);

                    switch (joke.type)
                    {
                        case "single":
                            Joke = new TheJoke { Type = joke.type, Joke = joke.joke };
                            break;
                        case "twopart":
                            Joke = new TheJoke { Type = joke.type, Joke = $"{joke.setup}. {joke.delivery}" };
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Joke;
        }

    }
}
