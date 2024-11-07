using System.Text.Json.Serialization;


namespace Web
{

    [Serializable]
    public struct KinopoiskCollectionData
    {

        [JsonPropertyName("category")]
        public string Category { get; set; }


        [JsonPropertyName("cover")]
        public PosterData Cover { get; set; }


        [JsonPropertyName("moviesCount")]
        public int MoviesCount { get; set; }


        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("id")]
        public string ID { get; set; }
    }
}
