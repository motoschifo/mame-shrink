#nullable enable
using System.Globalization;
using ArcadeDatabaseSdk.Net48.Extensions;

namespace ArcadeDatabaseSdk.Net48.Common;

public partial class ApiResponse
{
    public enum LanguageKind
    {
        en,
        it
    }

    public static LanguageKind ParseLanguage(string? value) => value.ToEnum(LanguageKind.en, LanguageKind.en);

    public static LanguageKind GetCurrentLanguage()
    {
        var lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
        if ("it".EqualsIgnoreCase(lang))
            return LanguageKind.it;
        return LanguageKind.en;
    }
}