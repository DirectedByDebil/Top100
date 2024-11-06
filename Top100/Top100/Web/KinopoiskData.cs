using Scratches;
using System.Text.Json.Serialization;

namespace Web
{

    [Serializable]
    public struct KinopoiskData
    {

        [JsonPropertyName("docs")]
        public List<CardData> Docs { get; set; }


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
