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
            
            _client.DefaultRequestHeaders.Add("X-API-KEY",
                
                "1C34DM1-T0P43D3-KJM6SXA-BASTTPZ");

            
            _serializerOptions = new JsonSerializerOptions
            {

                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }


        public async Task<T> GetRequestAsync<T>(string url) 
            
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
