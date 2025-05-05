using System;
using System.IO;
using System.Windows.Forms;
using MAME_Shrink.Settings;
using MAME_Shrink.Utilities;
using MameTools.Net48;
using MameTools.Net48.Config;
using static MAME_Shrink.Settings.UserPreferences;
using static MAME_Shrink.Settings.UserPreferences.ArcadeDatabaseSection;
using static MAME_Shrink.Settings.UserPreferences.MameSection;

namespace MAME_Shrink.Forms;

public partial class OptionsForm : Form
{
    private UserPreferences _userPreferences = new();

    public OptionsForm()
    {
        InitializeComponent();
    }

    private void OptionsForm_Load(object sender, EventArgs e)
    {
        _userPreferences = UserPreferencesManager.Get() ?? new();
    }

    private void OptionsForm_Shown(object sender, EventArgs e)
    {
        OptionXmlAuto.Checked = _userPreferences.Mame.GenerateGameListFromExecutable;
        txtMameExe.Text = _userPreferences.Mame.ExecutableFilePath;
        txtGamelistXml.Text = _userPreferences.Mame.GameListFilePath;
        txtRomsPath.Text = _userPreferences.Mame.RomPaths;
        ForceGeneration.Checked = _userPreferences.Mame.ForceGameListGeneration;
        RomPathsAuto.Checked = _userPreferences.Mame.AutoDetectRomPaths;

        CleanMoveToFolder.Checked = _userPreferences.CleanOptions.CleanMethod == CleanMethodKind.MoveFilesToFolder;
        CleanMoveToRecycleBin.Checked = _userPreferences.CleanOptions.CleanMethod == CleanMethodKind.MoveFilesToRecycleBin;
        CleanDeleteFiles.Checked = _userPreferences.CleanOptions.CleanMethod == CleanMethodKind.DeleteFiles;
        //txtRemovedFilesFolder.Enabled = CleanMoveToFolder.Checked;
        //cmdSfogliaRemovedFilesFolder.Enabled = CleanMoveToFolder.Checked;

        MameSetType = _userPreferences.Mame.MameSetType;

        ArcadeDatabaseConnectionOption = _userPreferences.ArcadeDatabase.ConnectionOption;
    }

    private async void CmdSaveData_Click(object sender, EventArgs e)
    {
        try
        {
            _userPreferences.Mame.ExecutableFilePath = txtMameExe.Text;
            _userPreferences.Mame.ForceGameListGeneration = ForceGeneration.Checked;
            _userPreferences.Mame.GameListFilePath = txtGamelistXml.Text;
            _userPreferences.Mame.RomPaths = txtRomsPath.Text;
            _userPreferences.Mame.GenerateGameListFromExecutable = OptionXmlAuto.Checked;
            _userPreferences.Mame.AutoDetectRomPaths = RomPathsAuto.Checked;
            if (_userPreferences.Mame.GenerateGameListFromExecutable)
            {
                if (string.IsNullOrEmpty(_userPreferences.Mame.ExecutableFilePath))
                    throw new Exception("Eseguibile Mame non specificato");
                if (!File.Exists(txtMameExe.Text))
                    throw new Exception("Eseguibile Mame non trovato");
                // TODO: Generazione XML
            }
            else
            {
                if (string.IsNullOrEmpty(txtGamelistXml.Text))
                    throw new Exception("Lista giochi XML non specificata");
                if (!File.Exists(txtGamelistXml.Text))
                    throw new Exception("Lista giochi XML non trovata");
                // TODO: Lettura XML
            }
            var mameConfig = await Mame.LoadMameConfiguration(_userPreferences.Mame.ExecutableFilePath);
            if (RomPathsAuto.Checked)
            {
                _userPreferences.Mame.RomPaths = mameConfig.RomPath;
            }
            else
            {
                if (string.IsNullOrEmpty(txtRomsPath.Text))
                    throw new Exception("Percorso roms non specificato");
                var basePath = Path.GetDirectoryName(_userPreferences.Mame.ExecutableFilePath);
                foreach (var folder in MameConfiguration.SplitPath(txtRomsPath.Text))
                {
                    var path = Path.Combine(basePath, mameConfig.HomePath, folder);
                    if (!Directory.Exists(path))
                        throw new Exception($"Percorso {path} non trovato");
                }
                _userPreferences.Mame.RomPaths = txtRomsPath.Text;
            }
            _userPreferences.Mame.MameSetType = MameSetType;

            _userPreferences.CleanOptions.CleanMethod = CleanMethod;
            if (_userPreferences.CleanOptions.CleanMethod == CleanMethodKind.MoveFilesToFolder)
            {
                if (!string.IsNullOrEmpty(_userPreferences.Mame.ExecutableFilePath))
                    _userPreferences.CleanOptions.RemovedFilesFolder = Path.Combine(Path.GetDirectoryName(_userPreferences.Mame.ExecutableFilePath), "REMOVED-FILES");
                if (string.IsNullOrEmpty(_userPreferences.CleanOptions.RemovedFilesFolder))
                    throw new Exception("Percorso di pulizia non specificato");
                if (!Directory.Exists(_userPreferences.CleanOptions.RemovedFilesFolder))
                    Directory.CreateDirectory(_userPreferences.CleanOptions.RemovedFilesFolder);
            }

            _userPreferences.ArcadeDatabase.ConnectionOption = ArcadeDatabaseConnectionOption;

            UserPreferencesManager.Set(_userPreferences);
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            Dialogs.ShowErrorDialog(ex);
        }
    }

    private void CmdSfogliaMameExe_Click(object sender, EventArgs e)
    {
        var path = Dialogs.SelectFileDialog(
            filterName: "mame*.exe",
            filters:
            [
                "Eseguibile MAME|mame*.exe",
                "Eseguibile|*.exe"
            ],
            initialFolder: txtMameExe.Text
        );
        if (!string.IsNullOrEmpty(path))
            txtMameExe.Text = path;
    }

    private void CmdSfogliaGamelistXml_Click(object sender, EventArgs e)
    {
        var path = Dialogs.SelectFileDialog(
            filterName: "gamelist*.xml",
            filters:
            [
                "File Gamelist XML|gamelist*.xml",
                "File XML|*.xml"
            ],
            initialFolder: txtGamelistXml.Text
        );
        if (!string.IsNullOrEmpty(path))
            txtGamelistXml.Text = path;
    }

    private void CmdSfogliaRomPath_Click(object sender, EventArgs e)
    {
        var path = Dialogs.SelectFolderDialog(txtGamelistXml.Text);
        if (!string.IsNullOrEmpty(path))
            txtRomsPath.Text = path;
    }

    private void CmdSfogliaRemovedFilesFolder_Click(object sender, EventArgs e)
    {
        var path = Dialogs.SelectFolderDialog(txtRemovedFilesFolder.Text);
        if (!string.IsNullOrEmpty(path))
            txtRemovedFilesFolder.Text = path;
    }

    public ConnectionOptionKind ArcadeDatabaseConnectionOption
    {
        get
        {
            if (ArcadeDatabaseConnectionOffline.Checked)
                return ConnectionOptionKind.Offline;
            else if (ArcadeDatabaseConnectionAuto.Checked)
                return ConnectionOptionKind.Auto;
            else
                return ConnectionOptionKind.Auto;
        }
        set
        {
            ArcadeDatabaseConnectionOffline.Checked = value == ConnectionOptionKind.Offline;
            ArcadeDatabaseConnectionAuto.Checked = value == ConnectionOptionKind.Auto;
        }
    }

    private void OptionXml_CheckedChanged(object sender, EventArgs e)
    {
        var optionAuto = OptionXmlAuto.Checked;
        txtMameExe.Enabled = optionAuto;
        cmdSfogliaMameExe.Enabled = optionAuto;
        ForceGeneration.Enabled = optionAuto;

        OptionXmlManual.Checked = !optionAuto;
        txtGamelistXml.Enabled = !optionAuto;
        cmdSfogliaGamelistXml.Enabled = !optionAuto;
    }

    public MameSetKind MameSetType
    {
        get
        {
            if (MameSetTypeAuto.Checked)
                return MameSetKind.Auto;
            else if (MameSetTypeSplitted.Checked)
                return MameSetKind.Splitted;
            else if (MameSetTypeMerged.Checked)
                return MameSetKind.Merged;
            else if (MameSetTypeNonMerged.Checked)
                return MameSetKind.NonMerged;
            else
                return MameSetKind.Auto;
        }
        set
        {
            MameSetTypeSplitted.Checked = value == MameSetKind.Splitted;
            MameSetTypeMerged.Checked = value == MameSetKind.Merged;
            MameSetTypeNonMerged.Checked = value == MameSetKind.NonMerged;
            MameSetTypeAuto.Checked = value == MameSetKind.Splitted;
        }
    }

    private void RomPathsAuto_CheckedChanged(object sender, EventArgs e)
    {
        var romPathsAudo = RomPathsAuto.Checked;
        RomPathsAuto.Checked = romPathsAudo;
        txtRomsPath.Enabled = romPathsAudo;
        cmdSfogliaRomsPath.Enabled = romPathsAudo;

        RomPathsManual.Checked = !romPathsAudo;
        txtRomsPath.Enabled = !romPathsAudo;
        cmdSfogliaRomsPath.Enabled = !romPathsAudo;
    }

    public CleanMethodKind CleanMethod
    {
        get
        {
            if (CleanMoveToFolder.Checked)
                return CleanMethodKind.MoveFilesToFolder;
            else if (CleanMoveToRecycleBin.Checked)
                return CleanMethodKind.MoveFilesToRecycleBin;
            else if (CleanDeleteFiles.Checked)
                return CleanMethodKind.DeleteFiles;
            else
                return CleanMethodKind.MoveFilesToFolder;
        }
        set
        {
            CleanMoveToFolder.Checked = value == CleanMethodKind.MoveFilesToFolder;
            CleanMoveToRecycleBin.Checked = value == CleanMethodKind.MoveFilesToRecycleBin;
            CleanDeleteFiles.Checked = value == CleanMethodKind.DeleteFiles;
        }
    }

    private void CleanMoveToFolder_CheckedChanged(object sender, EventArgs e)
    {
        txtRemovedFilesFolder.Enabled = CleanMoveToFolder.Checked;
        cmdSfogliaRemovedFilesFolder.Enabled = CleanMoveToFolder.Checked;
    }

    private void OpenRomsetWebPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Dialogs.OpenUrl(ArcadeDatabaseSdk.Net48.Common.Constants.HomePage);
    }
}
