using System.Text.Json.Serialization;
using Newtonsoft.Json;
using OtpTranslator.Lib.Model.Aegis;

namespace OtpTranslator.Lib.Translations.Aegis;

public class AegisFilePlain
{
    [JsonProperty("version")]
    public int Version { get; set; }

    [JsonProperty("header")] public AegisHeader Header { get; set; } = new();

    [JsonProperty("db")]
    public AegisDb Db { get; set; }

    public class AegisDb
    {
        [JsonProperty("version")]
        public int Version { get; set; }
        
        [JsonProperty("entries")]
        public AegisEntry[] Entries { get; set; }
    }

    public class AegisHeader
    {
        [JsonProperty("slots")]
        public string Slots { get; set; }
        
        [JsonProperty("params")]
        public string Params { get; set; }
    }
}