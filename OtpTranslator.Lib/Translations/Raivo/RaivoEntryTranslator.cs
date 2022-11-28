using System.Text.Json.Serialization;

namespace OtpTranslator.Lib.Translations.Raivo;

public class RaivoEntryTranslator : ITranslateEntry<RaivoEntry>
{
    public StandardOtpEntry ToStandard(RaivoEntry raivo)
    {
        var std = new StandardOtpEntry
        {
            Id = null,
            Issuer = raivo.Issuer,
            Name = raivo.Account,
            Note = string.Empty,
            Type = raivo.Kind,
            IconType = raivo.IconType,
            IconValue = raivo.IconValue,
            OtpData = new StandardOtp
            {
                Algorithm = raivo.Algorithm,
                Digits = int.Parse(raivo.Digits),
                Secret = raivo.Secret,
                TimerSeconds = int.Parse(raivo.Timer),
            },
        };
        return std;
    }

    public RaivoEntry FromStandard(StandardOtpEntry standard)
    {
        return new RaivoEntry
        {
            Account = standard.Name,
            Algorithm = standard.OtpData.Algorithm,
            Counter = "0",
            Digits = standard.OtpData.Digits.ToString(),
            Issuer = standard.Issuer,
            Kind = standard.Type.ToUpper(),
            Secret = standard.OtpData.Secret,
            Timer = standard.OtpData.TimerSeconds.ToString(),
            IconType = standard.IconType,
            IconValue = standard.IconValue,
        };
    }

    

    
}