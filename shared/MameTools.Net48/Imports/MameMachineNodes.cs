#nullable enable
namespace MameTools.Net48.Imports;

public static class MameMachineNodes
{
    // Definizione delle costanti per ogni configurazione
    public const int BiosSet = 1 << 0;        // 00000001
    public const int Rom = 1 << 1;            // 00000010
    public const int Disk = 1 << 2;           // 00000100
    public const int DeviceRef = 1 << 3;      // 00001000
    public const int Sample = 1 << 4;         // 00010000
    public const int Chip = 1 << 5;           // 00100000
    public const int Display = 1 << 6;        // 01000000
    public const int Sound = 1 << 7;          // 10000000
    public const int Input = 1 << 8;          // 000000010
    public const int DipSwitch = 1 << 9;      // 000000100
    public const int Configuration = 1 << 10; // 000001000
    public const int Port = 1 << 11;          // 000010000
    public const int Adjuster = 1 << 12;      // 000100000
    public const int Driver = 1 << 13;        // 001000000
    public const int Feature = 1 << 14;       // 010000000
    public const int Device = 1 << 15;        // 100000000
    public const int Slot = 1 << 16;          // 0000000001
    public const int SoftwareList = 1 << 17;  // 0000000010
    public const int RamOption = 1 << 18;     // 0000000100
    public const int InputControl = 1 << 19;  // 0000001000
    public const int All = BiosSet | Rom | Disk | DeviceRef | Sample | Chip |
        Display | Sound | Input | DipSwitch | Configuration | Port | Adjuster |
        Driver | Feature | Device | Slot | SoftwareList | RamOption | InputControl;
    public const int Defaults = Rom | Disk | DeviceRef | Sample | Display | Sound | Input |
        Driver | Feature | SoftwareList | InputControl;
}
