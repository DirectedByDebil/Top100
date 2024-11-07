using System.Text.Json.Serialization;

namespace Web
{

    [Serializable]
    public struct KinopoiskData<T>
    {

        [JsonPropertyName("docs")]
        public List<T> Docs { get; set; }


        [JsonPropertyName("total")]
        public int Total { get; set; }
        

        [JsonPropertyName("limit")]
        public int Limit { get; set; }
        

        [JsonPropertyName("page")]
        public int Page { get; set; }
        

        [JsonPropertyName("pages")]
        public int Pages { get; set; }
    }
}
