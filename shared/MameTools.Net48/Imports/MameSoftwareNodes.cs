#nullable enable
namespace MameTools.Net48.Imports;

public static class MameSoftwareNodes
{
    // Definizione delle costanti per ogni configurazione
    public const int Info = 1 << 0;           // 00000001
    public const int SharedFeature = 1 << 1;  // 00000010
    public const int Part = 1 << 2;           // 00000100
    public const int Part_Feature = 1 << 3;   // 00001000
    public const int Part_DataArea = 1 << 4;  // 00010000
    public const int Part_DiskArea = 1 << 5;  // 00100000
    public const int Part_DipSwitch = 1 << 6; // 01000000
    public const int All = Info | SharedFeature | Part | Part_Feature | Part_DataArea | Part_DiskArea | Part_DipSwitch;
    public const int Defaults = Part | Part_DiskArea;
}
