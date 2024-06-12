using System.ComponentModel;
using OtpTranslator.Lib.Translations.Aegis;
using OtpTranslator.Lib.Translations.Raivo;
using OtpTranslator.Lib.Translations.TwoFas;

namespace OtpTranslator.Lib;

public static class Factory
{
    public static ITranslateFile GetFileTranslator(OtpClient otpClient)
    {
        return otpClient switch
        {
            OtpClient.Aegis => new AegisFileTranslator(),
            OtpClient.Raivo => new RaivoFileTranslator(),
            OtpClient.TwoFas => new TwoFasFileTranslator(),
            _ => throw new InvalidEnumArgumentException($"Unsupported OTP client")
        };
    }
}