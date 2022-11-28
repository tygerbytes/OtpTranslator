using System.ComponentModel;
using OtpTranslator.Lib.Translations.Aegis;
using OtpTranslator.Lib.Translations.Raivo;

namespace OtpTranslator.Lib;

public static class Factory
{
    public static ITranslateFile GetFileTranslator(OtpClient otpClient)
    {
        return otpClient switch
        {
            OtpClient.Aegis => new AegisFileTranslator(),
            OtpClient.Raivo => new RaivoFileTranslator(),
            _ => throw new InvalidEnumArgumentException($"Unsupported OTP client")
        };
    }
}