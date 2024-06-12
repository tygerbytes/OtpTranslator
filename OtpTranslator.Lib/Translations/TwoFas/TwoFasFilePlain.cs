using Newtonsoft.Json;

namespace OtpTranslator.Lib.Translations.TwoFas;

public class TwoFasFilePlain
{
    [JsonProperty("appVersionName")]
    public string AppVersionName { get; set; }

    [JsonProperty("appOrigin")]
    public string AppOrigin { get; set; }

    [JsonProperty("services")]
    public List<TwoFasEntry> Services { get; set; }

    [JsonProperty("schemaVersion")]
    public int SchemaVersion { get; set; }

    [JsonProperty("groups")]
    public List<object> Groups { get; set; }

    [JsonProperty("appVersionCode")]
    public int AppVersionCode { get; set; }  
}

