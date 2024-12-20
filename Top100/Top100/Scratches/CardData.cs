﻿using System.Text.Json.Serialization;
using Web;

namespace Scratches
{
    [Serializable]
    public sealed class CardData
    {

        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("poster")]
        public PosterData Poster { get; set; }


        [JsonPropertyName("year")]
        public int Year { get; set; }


        public bool IsLocked { get; set; } = true;
    }
}
