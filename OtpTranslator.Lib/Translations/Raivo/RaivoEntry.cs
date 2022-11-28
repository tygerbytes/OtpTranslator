using Newtonsoft.Json;

namespace OtpTranslator.Lib.Translations.Raivo;

public class RaivoEntry
{
    [JsonProperty("kind")]
	public string Kind { get; set; }

    [JsonProperty("account")]
	public string Account { get; set; }

    [JsonProperty("issuer")]
	public string Issuer { get; set; }

    [JsonProperty("iconType")]
	public string IconType { get; set; }

    [JsonProperty("iconValue")]
	public string IconValue { get; set; }

    [JsonProperty("secret")]
	public string Secret { get; set; }

    [JsonProperty("algorithm")]
	public string Algorithm { get; set; }

    [JsonProperty("digits")]
	public string Digits { get; set; }

    [JsonProperty("timer")]
	public string Timer { get; set; }

    [JsonProperty("counter")]
	public string Counter { get; set; }

}