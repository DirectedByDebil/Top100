using System;
using System.Text.Json.Serialization;

namespace Web
{

    [Serializable]
    public struct RawgTag
    {

        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Slug { get; set; }


        [JsonPropertyName("games_count")]
        public int GamesCount { get; set; }


        [JsonPropertyName("image_background")]
        public string ImageBackground { get; set; }


        [JsonPropertyName("background_image")]
        public string BackgroundImage { get; set; }


        public string Category { get; set; }

        public PosterData Poster { get; set; }


        public string Language { get; set; }
    }
}
