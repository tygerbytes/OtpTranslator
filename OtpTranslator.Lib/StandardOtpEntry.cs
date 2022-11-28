namespace OtpTranslator.Lib;

public class StandardOtpEntry
{
    public string Type { get; set; }
    
    public Guid? Id { get; set; }
    
    public string Name { get; set; }
    
    public string Issuer { get; set; }
    
    public string Note { get; set; }
    
    public string IconType { get; set; }
    public string IconValue { get; set; }
    
    public StandardOtp OtpData { get; set; }
}