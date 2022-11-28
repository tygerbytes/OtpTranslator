namespace OtpTranslator.Lib;

public interface ITranslateFile
{
    Task<List<StandardOtpEntry>> FileToStandardCollectionAsync(string filePath);

    Task StandardCollectionToFileAsync(List<StandardOtpEntry> standardEntries, string targetPath);
}