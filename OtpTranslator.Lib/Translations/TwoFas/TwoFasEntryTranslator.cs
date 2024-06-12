namespace OtpTranslator.Lib.Translations.TwoFas;

public class TwoFasEntryTranslator : ITranslateEntry<TwoFasEntry>
{
    public StandardOtpEntry ToStandard(TwoFasEntry twoFas)
    {
        var std = new StandardOtpEntry
        {
            Id = null,
            Issuer = twoFas.Otp.Issuer,
            Name = twoFas.Name,
            Note = null,
            Type = twoFas.Otp.TokenType,
            OtpData = new StandardOtp
            {
                Algorithm = twoFas.Otp.Algorithm,
                Digits = twoFas.Otp.Digits,
                Secret = twoFas.Secret,
                TimerSeconds = twoFas.Otp.Period
            } 
        };
        return std;
    }

    public TwoFasEntry FromStandard(StandardOtpEntry standard)
    {
        return new TwoFasEntry
        {
            Name = standard.Name,
            // Generic label icon
            Icon = new TwoFasEntry.TwoFasIcon
            {
                Label = new TwoFasEntry.TwoFasIcon.TwoFasLabel
                {
                    Text = standard.Name[..2].ToUpper(),
                    BackgroundColor = GetRandomColor(),
                },
                IconCollection = new TwoFasEntry.TwoFasIcon.TwoFasIconCollection
                {
                    Id = "A5B3FB65-4EC5-43E6-8EC1-49E24CA9E7AD"
                },
                Selected = "Label",
            },
            UpdatedAt = GetUnixTimeStamp(),
            Secret = standard.OtpData.Secret,
            Otp = new TwoFasEntry.TwoFasOtp
            {
                TokenType = standard.Type.ToUpper(),
                Counter = 0,
                Algorithm = standard.OtpData.Algorithm.ToUpper(),
                Issuer = standard.Issuer,
                Period = standard.OtpData.TimerSeconds,
                Digits = standard.OtpData.Digits,
                Source = "link",
                Link = $"otpauth://totp/{standard.Name}?secret=[hidden]&issuer={standard.Issuer}",
            },
        };
    }

    private static long GetUnixTimeStamp()
    {
        return (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
    }

    private static string GetRandomColor()
    {
        var random = new Random();
        var color = random.Next(0, 0xFFFFFF);
        return "#" + color.ToString("X6");
    }
}