#nullable enable
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MameTools.Net48.Extensions;
using MameTools.Net48.Resources;
namespace MameTools.Net48.Exports;

public static class FileFactory
{
    public static async Task<string?> GenerateGamelistXml(string executableFilePath, string outputFile,
        Action<string?>? progressUpdate = null, string? prefix = "", CancellationToken cancellationToken = default)
    {
        try
        {
            if (string.IsNullOrEmpty(executableFilePath) || !File.Exists(executableFilePath))
                throw new Exception(string.Format(Strings.FileNotFound, executableFilePath));
            FileInfo fi = new(executableFilePath);
            progressUpdate?.Invoke($"{prefix}{Strings.MachinesFileCreation}");
            using var proc = new Process();
            proc.StartInfo.WorkingDirectory = fi.Directory.FullName;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.FileName = executableFilePath;
            proc.StartInfo.Arguments = "-listxml";
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.CreateNoWindow = true;
            _ = proc.Start();

            var j = 0;
            var size = 0;
            cancellationToken.ThrowIfCancellationRequested();
            using (StreamWriter w = new(outputFile, false, Encoding.UTF8))
            {
                var line = string.Empty;
                while ((line = await proc.StandardOutput.ReadLineAsync()) is not null)
                {
                    await w.WriteLineAsync(line);
                    j++;
                    size += line.Length;
                    if (j % 1000 == 0)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        progressUpdate?.Invoke($"{prefix}{Strings.MachinesFileCreation} ({size.ToFormattedString()})");
                    }
                }
                w.Close();
            }
            return !File.Exists(outputFile) ? throw new Exception(Strings.FileGenerationFailed) : await proc.StandardError.ReadToEndAsync();
        }
        catch (Exception ex)
        {
            if (File.Exists(outputFile))
                File.Delete(outputFile);
            return ex.Message;
        }
    }

    public static async Task<string?> GeneraSoftwarelistXml(string executableFilePath, string outputFile,
        Action<string?>? progressUpdate = null, string? prefix = "", string? hashPath = null, CancellationToken cancellationToken = default)
    {
        try
        {
            if (string.IsNullOrEmpty(executableFilePath) || !File.Exists(executableFilePath))
                throw new Exception(string.Format(Strings.FileNotFound, executableFilePath));
            FileInfo fi = new(executableFilePath);
            progressUpdate?.Invoke($"{prefix}{Strings.SoftwareFileCreation}");
            Process proc = new();
            proc.StartInfo.WorkingDirectory = fi.Directory.FullName;
            proc.StartInfo.UseShellExecute = false;
            //if (!File.Exists(folder + @"\mame.exe"))
            //    throw new Exception("Scaricare il file MAME.EXE corrispondente alla versione in uso.\n" +
            //        "http://www.mamedev.org/release.html oppure\n" + 
            //        "http://www.mamedev.org/oldrel.html.");
            proc.StartInfo.FileName = executableFilePath;
            proc.StartInfo.Arguments = "-listsoftware";
            if (!string.IsNullOrEmpty(hashPath) && Directory.Exists(hashPath))
                proc.StartInfo.Arguments += $" -hashpath \"{hashPath}\"";
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.CreateNoWindow = true;
            _ = proc.Start();

            var j = 0;
            var size = 0;
            cancellationToken.ThrowIfCancellationRequested();
            using (StreamWriter w = new(outputFile, false, Encoding.UTF8))
            {
                var line = string.Empty;
                while ((line = await proc.StandardOutput.ReadLineAsync()) is not null)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await w.WriteLineAsync(line);
                    j++;
                    size += line.Length;
                    if (j % 1000 == 0)
                        progressUpdate?.Invoke($"{prefix}{Strings.SoftwareFileCreation} ({size.ToFormattedString()})");
                }
                w.Close();
                if (size == 39) // No software lists found for this system
                {
                    File.Delete(outputFile);
                }
            }
            return !File.Exists(outputFile) ? throw new Exception(Strings.FileGenerationFailed) : await proc.StandardError.ReadToEndAsync();
        }
        catch (Exception ex)
        {
            if (File.Exists(outputFile))
                File.Delete(outputFile);
            return ex.Message;
        }
    }


}
