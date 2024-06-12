namespace OtpTranslator.Lib;

public enum OtpClient
{
    Invalid,
    Aegis,
    Raivo,
    TwoFas,
}

public static class OtpClientEnum
{
    public static OtpClient Parse(string otpClient)
    {
        if (string.IsNullOrEmpty(otpClient))
        {
            return OtpClient.Invalid;
        }

        return Enum.TryParse(otpClient, ignoreCase: true, result: out OtpClient client) 
            ? client
            : OtpClient.Invalid;
    }
}