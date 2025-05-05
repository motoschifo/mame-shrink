#nullable enable
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace MameTools.Net48.Helpers;

public static class RecycleBinHelper
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    private struct SHFILEOPSTRUCT
    {
        public IntPtr hwnd;
        public FileOperationType wFunc;
        [MarshalAs(UnmanagedType.LPTStr)] public string pFrom;
        [MarshalAs(UnmanagedType.LPTStr)] public string pTo;
        public FileOperationFlags fFlags;
        [MarshalAs(UnmanagedType.Bool)] public bool fAnyOperationsAborted;
        public IntPtr hNameMappings;
        [MarshalAs(UnmanagedType.LPTStr)] public string lpszProgressTitle;
    }

    private enum FileOperationType : uint
    {
        FO_DELETE = 0x0003
    }

    [Flags]
    private enum FileOperationFlags : ushort
    {
        FOF_SILENT = 0x0004,
        FOF_NOCONFIRMATION = 0x0010,
        FOF_ALLOWUNDO = 0x0040,
        FOF_NOERRORUI = 0x0400
    }

    [DllImport("shell32.dll", CharSet = CharSet.Auto)]
    private static extern int SHFileOperation(ref SHFILEOPSTRUCT fileOp);

    public static bool RecycleFiles(string[] filePaths)
    {
        if (filePaths.Length == 0)
            return false;

        // Filtra solo i file esistenti
        var validPaths = filePaths.Where(System.IO.File.Exists).ToArray();
        if (validPaths.Length == 0)
            return false;

        // Crea stringa con tutti i path separati da '\0', e un '\0' finale
        var multiFileString = string.Join("\0", validPaths) + "\0\0";

        var shf = new SHFILEOPSTRUCT
        {
            wFunc = FileOperationType.FO_DELETE,
            pFrom = multiFileString,
            fFlags = FileOperationFlags.FOF_ALLOWUNDO |
                     FileOperationFlags.FOF_NOCONFIRMATION |
                     FileOperationFlags.FOF_NOERRORUI |
                     FileOperationFlags.FOF_SILENT
        };

        var result = SHFileOperation(ref shf);
        return result == 0 && !shf.fAnyOperationsAborted;
    }

    public static bool RecycleFile(string filePath) => !string.IsNullOrEmpty(filePath) && RecycleFiles([filePath]);
}