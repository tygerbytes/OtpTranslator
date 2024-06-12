using Newtonsoft.Json;

namespace OtpTranslator.Lib.Translations.TwoFas;

public class TwoFasFileTranslator : ITranslateFile
{
    public Task<List<StandardOtpEntry>> FileToStandardCollectionAsync(string filePath)
    {
        var reader = new TwoFasFileReader(filePath);
        var twoFasData = reader.ReadPlain();
        
        var translator = new TwoFasEntryTranslator();
        var standardEntries = new List<StandardOtpEntry>();
        
        foreach (var twoFasEntry in twoFasData.Services)
        {
            var standard = translator.ToStandard(twoFasEntry);
            standardEntries.Add(standard);
        }
        
        return Task.FromResult(standardEntries);
    }

    public Task StandardCollectionToFileAsync(List<StandardOtpEntry> standardEntries, string targetPath)
    {
        var translator = new TwoFasEntryTranslator();
        
        var twoFasEntries = new List<TwoFasEntry>();
        var order = 0;
        foreach (var standard in standardEntries.OrderBy(x => x.Name))
        {
            var twoFas = translator.FromStandard(standard);
            twoFas.Order = new TwoFasEntry.TwoFasOrder
            {
                Position = order++
            };
            twoFasEntries.Add(twoFas);
        }
        
        var twoFasPlain = new TwoFasFilePlain
        {
            AppVersionName = "5.3.6",
            AppOrigin = "ios",
            Services = twoFasEntries,
            SchemaVersion = 4,
            Groups = new List<object>(),
            AppVersionCode = 50306
        };
        
        var json = JsonConvert.SerializeObject(twoFasPlain, Formatting.Indented);
        
        return File.WriteAllTextAsync(targetPath + ".2fas", json);
    }
}