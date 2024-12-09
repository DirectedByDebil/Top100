using System.Text.Json;

namespace Web
{

    public sealed class RestService
    {

        private HttpClient _client;
        
        private JsonSerializerOptions _serializerOptions;


        public RestService()
        {

            _client = new HttpClient();
            
            _serializerOptions = new JsonSerializerOptions
            {

                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }


        public void AddHeader(string key, string value)
        {

            _client.DefaultRequestHeaders.Add(key, value);
        }


        public async Task<T> GetAsync<T>(string url) 
            
            where T : struct
        {

            Uri uri = new Uri(url);


            HttpResponseMessage responseMessage =

                await _client.GetAsync(uri);


            if(responseMessage.IsSuccessStatusCode)
            {

                string content = await responseMessage.
                    
                    Content.ReadAsStringAsync();


                T data = JsonSerializer.Deserialize<
                    
                    T>(content, _serializerOptions);

                return data;
            }

            return default;
        }
    }
}
