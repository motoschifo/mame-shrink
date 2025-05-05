#nullable enable
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MAME_Shrink.Utilities;

public class Dialogs
{
    public static void ProgressUpdate(Label label, string? text = null, string? step = null)
    {
        label.Text = string.IsNullOrEmpty(step) ?
            (text ?? string.Empty) :
            string.IsNullOrEmpty(text) ? $"[{step!.ToUpper()}]" : $"[{step!.ToUpper()}] - {text}";
        Application.DoEvents();
    }

    public static string? SelectFileDialog(string filterName, List<string> filters, string initialFolder = "")
    {
        try
        {
            OpenFileDialog openFileDialog = new()
            {
                FileName = filterName,
                Filter = string.Join("|", filters) + "|Tutti i file|*.*",
                FilterIndex = 0,
                Multiselect = false,
                InitialDirectory = string.IsNullOrEmpty(initialFolder) ? null : initialFolder
            };
            DialogResult dr = openFileDialog.ShowDialog();
            return dr != DialogResult.OK ? null : openFileDialog.FileName;
        }
        catch (Exception ex)
        {
            _ = MessageBox.Show($"Errore durante la selezione del file.\n{ex.Message}");
            return null;
        }
    }

    public static string? SelectFolderDialog(string selectedPath, Environment.SpecialFolder rootFolder = Environment.SpecialFolder.MyComputer)
    {
        try
        {
            FolderBrowserDialog openFolderDialog = new()
            {
                SelectedPath = selectedPath,
                ShowNewFolderButton = true,
                RootFolder = rootFolder
            };
            DialogResult dr = openFolderDialog.ShowDialog();
            return dr != DialogResult.OK ? null : openFolderDialog.SelectedPath;
        }
        catch (Exception ex)
        {
            _ = MessageBox.Show($"Errore durante la lettura del percorso.\n\n{ex.Message}");
            return null;
        }
    }

    public static void OpenFile(string? filename, string verb = "open")
    {
        try
        {
            if (string.IsNullOrEmpty(filename) || !File.Exists(filename))
            {
                return;
            }

            Process proc = new();
            proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(filename);
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = filename;
            proc.StartInfo.Verb = verb;
            _ = proc.Start();
        }
        catch (Exception ex)
        {
            _ = MessageBox.Show($"Caricamento non riuscito per il file \n{filename}\n\n{ex.Message}");
        }
    }

    public static void OpenUrl(string url)
    {
        try
        {
            if (string.IsNullOrEmpty(url)) return;

            Process proc = new();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = url;
            proc.StartInfo.Verb = "open";
            _ = proc.Start();
        }
        catch (Exception ex)
        {
            _ = MessageBox.Show($"Caricamento non riuscito\n\n{ex.Message}");
        }
    }

    public static void ShowErrorDialog(Exception ex)
    {
        MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static void ShowErrorDialog(string error)
    {
        MessageBox.Show(error, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static void ShowInfoDialog(string text)
    {
        MessageBox.Show(text, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static void DoSomethingSafe(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            ShowErrorDialog(ex);
        }
    }

}
