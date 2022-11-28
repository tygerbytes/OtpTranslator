using System.Text.Json;
using Newtonsoft.Json;

namespace OtpTranslator.Lib.Translations.Raivo;

public class RaivoFileTranslator : ITranslateFile
{
    public async Task<List<StandardOtpEntry>> FileToStandardCollectionAsync(string filePath)
    {
        var reader = new RaivoFileReader(filePath);
        var raivoEntries = reader.Read();
            
        var translator = new RaivoEntryTranslator();
        var standardEntries = new List<StandardOtpEntry>();

        foreach (var raivoEntry in raivoEntries)
        {
            var standard = translator.ToStandard(raivoEntry);
            standardEntries.Add(standard);
        }

        return await Task.FromResult(standardEntries);
    } 
    
    public async Task StandardCollectionToFileAsync(List<StandardOtpEntry> standardEntries, string targetPath)
    {
        var translator = new RaivoEntryTranslator();

        var raivoEntries = new List<RaivoEntry>();
        foreach (var standard in standardEntries)
        {
            var raivo = translator.FromStandard(standard);
            raivoEntries.Add(raivo);
        }

        var json = JsonConvert.SerializeObject(raivoEntries.ToArray(), Formatting.Indented);
            
        await File.WriteAllTextAsync(targetPath, json);
    }
}