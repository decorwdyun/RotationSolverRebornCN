using System.IO;
using System.Reflection;
using ECommons.Logging;

namespace RotationSolver.Helpers;

/// <summary>
/// 提供国际化（i18n）功能的帮助类。
/// </summary>
internal static class I18NHelper
{
    private static readonly Lazy<Dictionary<string, string>> Translations = new(LoadTranslations);
    private static Dictionary<string, string> LoadTranslations()
    {
        var assembly = Assembly.GetExecutingAssembly();
        const string resourceName = "RotationSolver.Translations.json";

        try
        {
            using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null) return new Dictionary<string, string>();

            using var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json) ?? new Dictionary<string, string>();
        }
        catch (Exception ex)
        {
            PluginLog.Error($"Failed to load translations from embedded resource: {ex.Message} {ex.StackTrace}");
            return new Dictionary<string, string>();
        }
    }

    public static string Translate(string key)
    {
        if (string.IsNullOrEmpty(key)) return string.Empty;

        return Translations.Value.TryGetValue(key, out var translatedText) && !string.IsNullOrEmpty(translatedText)
            ? translatedText
            : key;
    }
}