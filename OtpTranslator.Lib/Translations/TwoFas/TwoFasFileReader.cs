using Newtonsoft.Json;

namespace OtpTranslator.Lib.Translations.TwoFas;

public class TwoFasFileReader
{
    private readonly string _path;

    public TwoFasFileReader(string path)
    {
        _path = path;
    }

    public TwoFasFilePlain? ReadPlain()
    {
        if (!File.Exists(_path))
        {
            throw new FileNotFoundException($"Can't find file '{_path}'");
        }
        
        var json = File.ReadAllText(_path);

        var twoFasData = JsonConvert.DeserializeObject<TwoFasFilePlain>(json);

        return twoFasData;
    }
}