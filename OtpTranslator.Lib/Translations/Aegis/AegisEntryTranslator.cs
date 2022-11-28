using OtpTranslator.Lib.Translations.Aegis;

namespace OtpTranslator.Lib.Model.Aegis;

public class AegisEntryTranslator : ITranslateEntry<AegisEntry>
{
    public StandardOtpEntry ToStandard(AegisEntry aegis)
    {
        return new StandardOtpEntry
        {
            Id = aegis.Uuid,
            Issuer = aegis.Issuer,
            Name = aegis.Name,
            Note = aegis.Note,
            Type = aegis.Type,
            // IconType = ?
            IconValue = aegis.Icon,
            OtpData = new StandardOtp
            {
                Algorithm = aegis.Info.Algo,
                Digits = aegis.Info.Digits,
                Secret = aegis.Info.Secret,
                TimerSeconds = aegis.Info.Period
            }
        };
    }

    public AegisEntry FromStandard(StandardOtpEntry standard)
    {
        var aegis = new AegisEntry
        {
            // TODO: Possible to translate icon stuff?
            Icon = "",
            Info = new AegisEntry.OtpData
            {
                Algo = standard.OtpData.Algorithm,
                Digits = standard.OtpData.Digits,
                Period = standard.OtpData.TimerSeconds,
                Secret = standard.OtpData.Secret,
            },
            Issuer = standard.Issuer,
            Name = standard.Name,
            Note = standard.Note,
            Type = standard.Type.ToLower(),
            Uuid = standard.Id ?? Guid.NewGuid(),
        };
        return aegis;
    }
}