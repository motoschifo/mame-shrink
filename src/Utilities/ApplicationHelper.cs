#nullable enable
using System.IO;
using System.Reflection;

namespace MAME_Shrink.Utilities;

public static class ApplicationHelper
{
    public static string GetApplicationTitle(Assembly assembly)
    {
        var version = assembly.GetName().Version;
        return $"{assembly.GetName().Name} {version.Major:0}.{version.Minor:0} build {version.Build}";
    }

    public static string GetApplicationPath(Assembly assembly)
    {
        return Path.GetDirectoryName(assembly.Location);
    }

    public static string GetApplicationRelease(Assembly assembly)
    {
        var version = assembly.GetName().Version;
        return $"{version.Major:0}.{version.Minor:0} build {version.Build}";
    }
}
