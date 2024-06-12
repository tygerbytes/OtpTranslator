using System.Text.Json;
using Newtonsoft.Json;
using OtpTranslator.Lib.Model.Aegis;

namespace OtpTranslator.Lib.Translations.Aegis;

public class AegisFileTranslator : ITranslateFile
{
    public async Task<List<StandardOtpEntry>> FileToStandardCollectionAsync(string filePath)
    {
        var reader = new AegisFileReader(filePath);
        var aegisData = reader.ReadPlain();

        var translator = new AegisEntryTranslator();
        var standardEntries = new List<StandardOtpEntry>();

        foreach (var aegisEntry in aegisData.Db.Entries)
        {
            var standard = translator.ToStandard(aegisEntry);
            standardEntries.Add(standard);
        }

        return await Task.FromResult(standardEntries);
    }

    public async Task StandardCollectionToFileAsync(List<StandardOtpEntry> standardEntries, string targetPath)
    {
        var translator = new AegisEntryTranslator();

        var aegisEntries = new List<AegisEntry>();
        foreach (var standard in standardEntries)
        {
            var aegis = translator.FromStandard(standard);
            aegisEntries.Add(aegis);
        }

        var aegisPlain = new AegisFilePlain
        {
            Version = 1,
            Db = new AegisFilePlain.AegisDb
            {
                Version = 2,
                Entries = aegisEntries.ToArray()
            }
        };

        var json = JsonConvert.SerializeObject(aegisPlain, Formatting.Indented);

        await File.WriteAllTextAsync(targetPath + ".json", json); 
    } 
}