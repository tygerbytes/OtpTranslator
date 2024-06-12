namespace OtpTranslator.Lib;

public class OtpFileTranslator
{
    public async Task TranslateAsync(
        OtpClient source,
        OtpClient target,
        string path )
    {
        if (source == OtpClient.Invalid)
        {
            throw new ArgumentOutOfRangeException($"Invalid source type {source}");
        }
            
        if (target == OtpClient.Invalid)
        {
            throw new ArgumentOutOfRangeException($"Invalid target type {target}");
        }
            
        // -- First translate the source to a "standard" type
        var sourceTranslator = Factory.GetFileTranslator(source);
        var standardEntries = await sourceTranslator.FileToStandardCollectionAsync(path);
        if (!standardEntries.Any())
        {
            throw new Exception($"Unable to parse any entries from '{path}");
        }
            
        // -- Now translate the standard type to the target type
        var dir = Path.GetDirectoryName(path) ?? "./";
        var fileName = Path.GetFileNameWithoutExtension(path) + $"-converted_to_{target}";
        var targetPath = Path.Combine(dir, fileName);
            
        var targetTranslator = Factory.GetFileTranslator(target);
        await targetTranslator.StandardCollectionToFileAsync(standardEntries, targetPath);
    }
}