using Newtonsoft.Json;

namespace BookExchange.Core.Relationship
{
    public class Relationship
    {
        [JsonProperty("SUBSCRIBE")]
        public bool Subscribe { get;set;}

        [JsonProperty("HAVE")]
        public bool Have { get;set;}

        [JsonProperty("LENT_ON")]
        public bool Lent { get;set;}

    }
}