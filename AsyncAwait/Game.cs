using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class Game
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("alternative_names")]
        public List<int> AlternativeNames { get; set; }
        [JsonProperty("category")]
        public int Category { get; set; }
        [JsonProperty("collection")]
        public int Collection { get; set; }
        [JsonProperty("cover")]
        public int Cover { get; set; }
        [JsonProperty("created_at")]
        public int CreationDate { get; set; }
        [JsonProperty("external_games")]
        public List<int> ExternalGames { get; set; }
        [JsonProperty("first_release_date")]
        public int FirstReleaseDate { get; set; }
        [JsonProperty("franchise")]
        public int Franchise { get; set; }
        [JsonProperty("franchises")]
        public List<int> Franchises { get; set; }
        [JsonProperty("game_modes")]
        public List<int> GameModes { get; set; }
        [JsonProperty("genres")]
        public List<int> Genres { get; set; }
        [JsonProperty("involved_companies")]
        public List<int> InvolvedCompanies { get; set; }
        [JsonProperty("keywords")]
        public List<int> Keywords { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("platforms")]
        public List<int> Platforms { get; set; }
        [JsonProperty("player_perspectives")]
        public List<int> PlayerPerspectives { get; set; }
        [JsonProperty("popularity")]
        public double Popularity { get; set; }
        [JsonProperty("pulse_count")]
        public int PulseCount { get; set; }
        [JsonProperty("release_dates")]
        public List<int> ReleaseDates { get; set; }
        [JsonProperty("screeshots")]
        public List<int> Screenshots { get; set; }
        [JsonProperty("similar_games")]
        public List<int> SimilarGames { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        [JsonProperty("tags")]
        public List<int> Tags { get; set; }
        [JsonProperty("themes")]
        public List<int> Themes { get; set; }
        [JsonProperty("updated_at")]
        public int UpdateDate { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("videos")]
        public List<int> Videos { get; set; }
        [JsonProperty("websites")]
        public List<int> Websites { get; set; }
    }
}
