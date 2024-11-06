using System.Text.Json;
using Scratches;

namespace Web
{

    public sealed class RestService
    {

        private HttpClient _client;
        
        private JsonSerializerOptions _serializerOptions;


        public RestService()
        {

            _client = new HttpClient();
            
            _client.DefaultRequestHeaders.Add("X-API-KEY",
                
                "1C34DM1-T0P43D3-KJM6SXA-BASTTPZ");

            
            _serializerOptions = new JsonSerializerOptions
            {

                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }


        public async Task<List<CardData>> RefreshDataAsync(string url)
        {

            Uri uri = new Uri(url);


            HttpResponseMessage responseMessage = await _client.GetAsync(uri);


            List<CardData> items = new();

            if(responseMessage.IsSuccessStatusCode)
            {

                string content = await responseMessage.Content.ReadAsStringAsync();


                KinopoiskData data = JsonSerializer.Deserialize<
                    
                    KinopoiskData>(content, _serializerOptions);

                items = data.Docs;
            }

            return items;
        }
    }
}
