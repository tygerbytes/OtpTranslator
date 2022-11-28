using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace OtpTranslator.Lib.Translations.Aegis;

public class AegisEntry
{
    [JsonProperty("type")]
    public string Type { get; set; }
    
    [JsonProperty("uuid")]
    public Guid Uuid { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("issuer")]
    public string Issuer { get; set; }
    
    [JsonProperty("note")]
    public string Note { get; set; }
    
    [JsonProperty("icon")]
    public string Icon { get; set; }
    
    [JsonProperty("icon_mime")]
    public string IconMime { get; set; }

    [JsonProperty("info")]
    public OtpData Info { get; set; }
    
    public class OtpData
    {
        [JsonProperty("secret")]
        public string Secret { get; set; } 
        
        [JsonProperty("algo")]
        public string Algo { get; set; }
        
        [JsonProperty("digits")]
        
        public int Digits { get; set; }
        
        [JsonProperty("period")]
        public int Period { get; set; }
    }
}