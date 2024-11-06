using System.Text.Json.Serialization;

namespace Web
{
    [Serializable]
    public struct PosterData
    {

        [JsonPropertyName("url")]
        public string Url { get; set; }


        [JsonPropertyName("previewUrl")]
        public string PreviewUrl { get; set; }


        public PosterData(string url, string previewUrl)
        {

            Url = url;

            PreviewUrl = previewUrl;
        }
    }
}
