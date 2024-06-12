using Newtonsoft.Json;

namespace OtpTranslator.Lib.Translations.TwoFas;

public class TwoFasEntry
{
	[JsonProperty("name")] 
	public string Name { get; set; }

	[JsonProperty("icon")] 
	public TwoFasIcon Icon { get; set; }

	[JsonProperty("updatedAt")] 
	public long UpdatedAt { get; set; }

	[JsonProperty("secret")] 
	public string Secret { get; set; }

	[JsonProperty("otp")] 
	public TwoFasOtp Otp { get; set; }

	[JsonProperty("order")] 
	public TwoFasOrder Order { get; set; }

	[JsonProperty("serviceTypeID")] 
	public string ServiceTypeID { get; set; }

	public class TwoFasIcon
	{
		[JsonProperty("selected")] 
		public string Selected { get; set; }

		[JsonProperty("label")] 
		public TwoFasLabel Label { get; set; }

		[JsonProperty("iconCollection")] 
		public TwoFasIconCollection IconCollection { get; set; }
		
		public class TwoFasLabel
		{
			[JsonProperty("text")]
			public string Text { get; set; }

			[JsonProperty("backgroundColor")]
			public string BackgroundColor { get; set; }
		}
		
		public class TwoFasIconCollection
		{
			[JsonProperty("id")]
			public string Id { get; set; }
		}
	}
	
	public class TwoFasOrder
	{
		[JsonProperty("position")]
		public int Position { get; set; }
	}	
	
	public class TwoFasOtp
	{
		[JsonProperty("tokenType")]
		public string TokenType { get; set; }

		[JsonProperty("counter")]
		public int Counter { get; set; }

		[JsonProperty("algorithm")]
		public string Algorithm { get; set; }

		[JsonProperty("issuer")]
		public string Issuer { get; set; }

		[JsonProperty("period")]
		public int Period { get; set; }

		[JsonProperty("digits")]
		public int Digits { get; set; }

		[JsonProperty("source")]
		public string Source { get; set; }

		[JsonProperty("link")]
		public string Link { get; set; }
	}
}
