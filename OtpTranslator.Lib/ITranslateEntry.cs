using OtpTranslator.Lib.Model.Aegis;

namespace OtpTranslator.Lib;

public interface ITranslateEntry<T>
{
    StandardOtpEntry ToStandard(T other);

    T FromStandard(StandardOtpEntry standard);
}