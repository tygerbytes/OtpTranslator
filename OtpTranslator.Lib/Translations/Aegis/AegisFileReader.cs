using System.Text.Json;
using Newtonsoft.Json;
using OtpTranslator.Lib.Model.Aegis;
using OtpTranslator.Lib.Translations.Raivo;

namespace OtpTranslator.Lib.Translations.Aegis;

public class AegisFileReader
{
    private readonly string _path;

    public AegisFileReader(string path)
    {
        _path = path;
    }

    public AegisFilePlain? ReadPlain()
    {
        if (!File.Exists(_path))
        {
            throw new FileNotFoundException($"Can't find file '{_path}'");
        }
        
        var json = File.ReadAllText(_path);

        var aegisData = JsonConvert.DeserializeObject<AegisFilePlain>(json);

        return aegisData;
    }
}