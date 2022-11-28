using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace OtpTranslator.Lib.Translations.Raivo;

public class RaivoFileReader
{
    private readonly string _path;

    public RaivoFileReader(string path)
    {
        _path = path;
    }

    public RaivoEntry[] Read()
    {
        if (!File.Exists(_path))
        {
            throw new FileNotFoundException($"Can't find file '{_path}'");
        }
        
        var json = File.ReadAllText(_path);

        var entries = JsonConvert.DeserializeObject<RaivoEntry[]>(json);

        return entries ?? Array.Empty<RaivoEntry>();
    }
}