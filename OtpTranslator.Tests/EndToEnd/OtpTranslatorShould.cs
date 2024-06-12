using System.Diagnostics;
using OtpTranslator.Lib;
using OtpTranslator.Lib.Translations.Aegis;
using OtpTranslator.Lib.Translations.Raivo;
using OtpTranslator.Lib.Translations.TwoFas;
using Shouldly;

namespace OtpTranslator.Tests.EndToEnd;

public class OtpTranslatorShould
{
    [Fact]
    public async Task TranslatePlainRaivoFileToPlainAegisFile()
    {
        var translator = new OtpFileTranslator();
        
        await translator.TranslateAsync(
            source: OtpClient.Raivo,
            target: OtpClient.Aegis,
            path: "EndToEnd/RaivoPlain.json");

        const string targetPath = "EndToEnd/RaivoPlain-converted_to_Aegis.json";
        File.Exists(targetPath).ShouldBeTrue();

        // Now read file and make sure it was properly converted
        var aegisReader = new AegisFileReader(targetPath);
        var aegisFile = aegisReader.ReadPlain();

        aegisFile.ShouldNotBeNull();
        aegisFile.Version.ShouldBe(1);
        aegisFile.Header.ShouldNotBeNull();
        aegisFile.Header.Params.ShouldBeNull();

        var aegisEntry = aegisFile.Db.Entries.First();
        aegisEntry.Type.ShouldBe("totp");
        aegisEntry.Issuer.ShouldBe("Google.com");
        aegisEntry.Name.ShouldBe("google@gmail.com");
        aegisEntry.Info.Secret.ShouldBe("GoogleSecret");
        aegisEntry.Info.Algo.ShouldBe("SHA1");
        aegisEntry.Info.Digits.ShouldBe(6);
        aegisEntry.Info.Period.ShouldBe(30);
    }
    
    [Fact]
    public async Task TranslatePlainAegisFileToPlainRaivoFile()
    {
        var aegisFileTranslator = new OtpFileTranslator();
        
        await aegisFileTranslator.TranslateAsync(
            source: OtpClient.Aegis,
            target: OtpClient.Raivo,
            path: "EndToEnd/AegisPlain.json");

        const string targetPath = "EndToEnd/AegisPlain-converted_to_Raivo.json";
        File.Exists(targetPath).ShouldBeTrue();

        // Now read file and make sure it was properly converted

        var raivoReader = new RaivoFileReader(targetPath);
        var raivoEntries = raivoReader.Read();
        raivoEntries.Length.ShouldBe(2);
        
        var raivoEntry = raivoEntries.First();
        raivoEntry.Kind.ShouldBe("TOTP");
        raivoEntry.Issuer.ShouldBe("Google.com");
        raivoEntry.Account.ShouldBe("google@gmail.com");
        raivoEntry.Secret.ShouldBe("GoogleSecret");
        raivoEntry.Timer.ShouldBe("30");
        raivoEntry.Algorithm.ShouldBe("SHA1");
        raivoEntry.Digits.ShouldBe("6");
    }

    [Fact]
    public async Task TranslatePlain2FasFileToPlainAegisFile()
    {
        var twoFasFileTranslator = new OtpFileTranslator();
        
        await twoFasFileTranslator.TranslateAsync(
            source: OtpClient.TwoFas,
            target: OtpClient.Aegis,
            path: "EndToEnd/2fasPlain.json");
        
        const string targetPath = "EndToEnd/2FasPlain-converted_to_Aegis.json";
        File.Exists(targetPath).ShouldBeTrue();
        
        // Now read file and make sure it was properly converted
        var aegisReader = new AegisFileReader(targetPath);
        var aegisFile = aegisReader.ReadPlain();

        aegisFile.ShouldNotBeNull();
        aegisFile.Version.ShouldBe(1);
        aegisFile.Header.ShouldNotBeNull();
        aegisFile.Header.Params.ShouldBeNull();

        var aegisEntry = aegisFile.Db.Entries.First();
        aegisEntry.Type.ShouldBe("totp");
        aegisEntry.Issuer.ShouldBe("2FAS");
        aegisEntry.Name.ShouldBe("2FAS");
        aegisEntry.Info.Secret.ShouldBe("2FASTEST");
        aegisEntry.Info.Algo.ShouldBe("SHA1");
        aegisEntry.Info.Digits.ShouldBe(6);
        aegisEntry.Info.Period.ShouldBe(30);
    }
    
    [Fact]
    public async Task TranslatePlainRaivoFileToPlain2FasFile()
    {
        var raivoFileTranslator = new OtpFileTranslator();
        
        await raivoFileTranslator.TranslateAsync(
            source: OtpClient.Raivo,
            target: OtpClient.TwoFas,
            path: "EndToEnd/RaivoPlain.json");
        
        const string targetPath = "EndToEnd/RaivoPlain-converted_to_TwoFas.2fas";
        File.Exists(targetPath).ShouldBeTrue();
        
        // Now read file and make sure it was properly converted
        
        var twoFasReader = new TwoFasFileReader(targetPath);
        var twoFasData = twoFasReader.ReadPlain();
        twoFasData.ShouldNotBeNull();
        
        var twoFasEntry = twoFasData.Services.Last();
        twoFasEntry.Name.ShouldBe("google@gmail.com");
        twoFasEntry.Otp.Issuer.ShouldBe("Google.com");
        twoFasEntry.Secret.ShouldBe("GoogleSecret");
        twoFasEntry.Otp.Algorithm.ShouldBe("SHA1");
        twoFasEntry.Otp.Digits.ShouldBe(6);
        twoFasEntry.Otp.Period.ShouldBe(30);
        
        twoFasEntry.Secret.ShouldBe("GoogleSecret");
        twoFasEntry.Otp.Algorithm.ShouldBe("SHA1");
        twoFasEntry.Otp.Digits.ShouldBe(6);
        twoFasEntry.Otp.Period.ShouldBe(30);
        
        twoFasEntry.Secret.ShouldBe("GoogleSecret");
        twoFasEntry.Otp.Algorithm.ShouldBe("SHA1");
        twoFasEntry.Otp.Digits.ShouldBe(6);
        twoFasEntry.Otp.Period.ShouldBe(30);
    }
}
