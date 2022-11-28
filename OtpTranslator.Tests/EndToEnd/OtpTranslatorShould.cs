using System.Diagnostics;
using OtpTranslator.Lib;
using OtpTranslator.Lib.Translations.Aegis;
using OtpTranslator.Lib.Translations.Raivo;
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
}