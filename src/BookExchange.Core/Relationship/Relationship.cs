using Newtonsoft.Json;

namespace BookExchange.Core.Relationship
{
    public class Relationship
    {
        [JsonProperty("SUBSCRIBE")]
        public bool Knows { get;set;}


        [JsonProperty("HAVE")]
        public bool Have { get;set;}
    }
}