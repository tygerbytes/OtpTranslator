namespace OtpTranslator.Lib;

public class StandardOtp
{
    public string Secret { get; set; }
    public string Algorithm { get; set; }
    public int Digits { get; set; }
    public int TimerSeconds { get; set; }
}