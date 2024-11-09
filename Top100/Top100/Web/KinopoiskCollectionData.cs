using System.Text.Json.Serialization;


namespace Web
{

    [Serializable]
    public struct KinopoiskCollectionData
    {

        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("category")]
        public string Category { get; set; }


        [JsonPropertyName("slug")]
        public string Slug { get; set; }


        [JsonPropertyName("cover")]
        public PosterData Poster { get; set; }


        [JsonPropertyName("moviesCount")]
        public int MoviesCount { get; set; }


        [JsonPropertyName("id")]
        public string ID { get; set; }
    }
}
