namespace MAME_Shrink.Forms;

partial class OptionsForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.ForceGeneration = new System.Windows.Forms.CheckBox();
            this.OptionXmlManual = new System.Windows.Forms.RadioButton();
            this.OptionXmlAuto = new System.Windows.Forms.RadioButton();
            this.txtGamelistXml = new System.Windows.Forms.TextBox();
            this.txtMameExe = new System.Windows.Forms.TextBox();
            this.RomPathsManual = new System.Windows.Forms.RadioButton();
            this.RomPathsAuto = new System.Windows.Forms.RadioButton();
            this.txtRomsPath = new System.Windows.Forms.TextBox();
            this.CleanDeleteFiles = new System.Windows.Forms.RadioButton();
            this.CleanMoveToFolder = new System.Windows.Forms.RadioButton();
            this.CleanMoveToRecycleBin = new System.Windows.Forms.RadioButton();
            this.txtRemovedFilesFolder = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPageGamelist = new System.Windows.Forms.TabPage();
            this.TabPageRoms = new System.Windows.Forms.TabPage();
            this.TabPageMame = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.MameSetTypeAuto = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MameSetTypeNonMerged = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.MameSetTypeMerged = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.MameSetTypeSplitted = new System.Windows.Forms.RadioButton();
            this.TabPageClean = new System.Windows.Forms.TabPage();
            this.TabPageConnections = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ArcadeDatabaseConnectionOffline = new System.Windows.Forms.RadioButton();
            this.ArcadeDatabaseConnectionAuto = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdSfogliaGamelistXml = new System.Windows.Forms.Button();
            this.cmdSfogliaMameExe = new System.Windows.Forms.Button();
            this.cmdSfogliaRomsPath = new System.Windows.Forms.Button();
            this.cmdSfogliaRemovedFilesFolder = new System.Windows.Forms.Button();
            this.OpenRomsetWebPage = new System.Windows.Forms.LinkLabel();
            this.cmdLoadData = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.TabPageGamelist.SuspendLayout();
            this.TabPageRoms.SuspendLayout();
            this.TabPageMame.SuspendLayout();
            this.TabPageClean.SuspendLayout();
            this.TabPageConnections.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ForceGeneration
            // 
            resources.ApplyResources(this.ForceGeneration, "ForceGeneration");
            this.ForceGeneration.Name = "ForceGeneration";
            this.ForceGeneration.UseVisualStyleBackColor = true;
            // 
            // OptionXmlManual
            // 
            resources.ApplyResources(this.OptionXmlManual, "OptionXmlManual");
            this.OptionXmlManual.Name = "OptionXmlManual";
            this.OptionXmlManual.UseVisualStyleBackColor = true;
            this.OptionXmlManual.CheckedChanged += new System.EventHandler(this.OptionXml_CheckedChanged);
            // 
            // OptionXmlAuto
            // 
            resources.ApplyResources(this.OptionXmlAuto, "OptionXmlAuto");
            this.OptionXmlAuto.Checked = true;
            this.OptionXmlAuto.Name = "OptionXmlAuto";
            this.OptionXmlAuto.TabStop = true;
            this.OptionXmlAuto.UseVisualStyleBackColor = true;
            this.OptionXmlAuto.CheckedChanged += new System.EventHandler(this.OptionXml_CheckedChanged);
            // 
            // txtGamelistXml
            // 
            resources.ApplyResources(this.txtGamelistXml, "txtGamelistXml");
            this.txtGamelistXml.Name = "txtGamelistXml";
            // 
            // txtMameExe
            // 
            resources.ApplyResources(this.txtMameExe, "txtMameExe");
            this.txtMameExe.Name = "txtMameExe";
            // 
            // RomPathsManual
            // 
            resources.ApplyResources(this.RomPathsManual, "RomPathsManual");
            this.RomPathsManual.Name = "RomPathsManual";
            this.RomPathsManual.UseVisualStyleBackColor = true;
            // 
            // RomPathsAuto
            // 
            resources.ApplyResources(this.RomPathsAuto, "RomPathsAuto");
            this.RomPathsAuto.Checked = true;
            this.RomPathsAuto.Name = "RomPathsAuto";
            this.RomPathsAuto.TabStop = true;
            this.RomPathsAuto.UseVisualStyleBackColor = true;
            this.RomPathsAuto.CheckedChanged += new System.EventHandler(this.RomPathsAuto_CheckedChanged);
            // 
            // txtRomsPath
            // 
            resources.ApplyResources(this.txtRomsPath, "txtRomsPath");
            this.txtRomsPath.Name = "txtRomsPath";
            // 
            // CleanDeleteFiles
            // 
            resources.ApplyResources(this.CleanDeleteFiles, "CleanDeleteFiles");
            this.CleanDeleteFiles.Name = "CleanDeleteFiles";
            this.CleanDeleteFiles.UseVisualStyleBackColor = true;
            // 
            // CleanMoveToFolder
            // 
            resources.ApplyResources(this.CleanMoveToFolder, "CleanMoveToFolder");
            this.CleanMoveToFolder.Checked = true;
            this.CleanMoveToFolder.Name = "CleanMoveToFolder";
            this.CleanMoveToFolder.TabStop = true;
            this.CleanMoveToFolder.UseVisualStyleBackColor = true;
            this.CleanMoveToFolder.CheckedChanged += new System.EventHandler(this.CleanMoveToFolder_CheckedChanged);
            // 
            // CleanMoveToRecycleBin
            // 
            resources.ApplyResources(this.CleanMoveToRecycleBin, "CleanMoveToRecycleBin");
            this.CleanMoveToRecycleBin.Name = "CleanMoveToRecycleBin";
            this.CleanMoveToRecycleBin.UseVisualStyleBackColor = true;
            // 
            // txtRemovedFilesFolder
            // 
            resources.ApplyResources(this.txtRemovedFilesFolder, "txtRemovedFilesFolder");
            this.txtRemovedFilesFolder.Name = "txtRemovedFilesFolder";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.TabPageGamelist);
            this.tabControl1.Controls.Add(this.TabPageRoms);
            this.tabControl1.Controls.Add(this.TabPageMame);
            this.tabControl1.Controls.Add(this.TabPageClean);
            this.tabControl1.Controls.Add(this.TabPageConnections);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // TabPageGamelist
            // 
            resources.ApplyResources(this.TabPageGamelist, "TabPageGamelist");
            this.TabPageGamelist.Controls.Add(this.OptionXmlManual);
            this.TabPageGamelist.Controls.Add(this.txtGamelistXml);
            this.TabPageGamelist.Controls.Add(this.ForceGeneration);
            this.TabPageGamelist.Controls.Add(this.cmdSfogliaGamelistXml);
            this.TabPageGamelist.Controls.Add(this.txtMameExe);
            this.TabPageGamelist.Controls.Add(this.cmdSfogliaMameExe);
            this.TabPageGamelist.Controls.Add(this.OptionXmlAuto);
            this.TabPageGamelist.Name = "TabPageGamelist";
            this.TabPageGamelist.UseVisualStyleBackColor = true;
            // 
            // TabPageRoms
            // 
            resources.ApplyResources(this.TabPageRoms, "TabPageRoms");
            this.TabPageRoms.Controls.Add(this.RomPathsManual);
            this.TabPageRoms.Controls.Add(this.RomPathsAuto);
            this.TabPageRoms.Controls.Add(this.txtRomsPath);
            this.TabPageRoms.Controls.Add(this.cmdSfogliaRomsPath);
            this.TabPageRoms.Name = "TabPageRoms";
            this.TabPageRoms.UseVisualStyleBackColor = true;
            // 
            // TabPageMame
            // 
            resources.ApplyResources(this.TabPageMame, "TabPageMame");
            this.TabPageMame.Controls.Add(this.label5);
            this.TabPageMame.Controls.Add(this.MameSetTypeAuto);
            this.TabPageMame.Controls.Add(this.label4);
            this.TabPageMame.Controls.Add(this.label3);
            this.TabPageMame.Controls.Add(this.MameSetTypeNonMerged);
            this.TabPageMame.Controls.Add(this.label2);
            this.TabPageMame.Controls.Add(this.MameSetTypeMerged);
            this.TabPageMame.Controls.Add(this.label1);
            this.TabPageMame.Controls.Add(this.MameSetTypeSplitted);
            this.TabPageMame.Name = "TabPageMame";
            this.TabPageMame.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // MameSetTypeAuto
            // 
            resources.ApplyResources(this.MameSetTypeAuto, "MameSetTypeAuto");
            this.MameSetTypeAuto.Checked = true;
            this.MameSetTypeAuto.Name = "MameSetTypeAuto";
            this.MameSetTypeAuto.TabStop = true;
            this.MameSetTypeAuto.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // MameSetTypeNonMerged
            // 
            resources.ApplyResources(this.MameSetTypeNonMerged, "MameSetTypeNonMerged");
            this.MameSetTypeNonMerged.Name = "MameSetTypeNonMerged";
            this.MameSetTypeNonMerged.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // MameSetTypeMerged
            // 
            resources.ApplyResources(this.MameSetTypeMerged, "MameSetTypeMerged");
            this.MameSetTypeMerged.Name = "MameSetTypeMerged";
            this.MameSetTypeMerged.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // MameSetTypeSplitted
            // 
            resources.ApplyResources(this.MameSetTypeSplitted, "MameSetTypeSplitted");
            this.MameSetTypeSplitted.Name = "MameSetTypeSplitted";
            this.MameSetTypeSplitted.UseVisualStyleBackColor = true;
            // 
            // TabPageClean
            // 
            resources.ApplyResources(this.TabPageClean, "TabPageClean");
            this.TabPageClean.Controls.Add(this.CleanDeleteFiles);
            this.TabPageClean.Controls.Add(this.txtRemovedFilesFolder);
            this.TabPageClean.Controls.Add(this.CleanMoveToFolder);
            this.TabPageClean.Controls.Add(this.CleanMoveToRecycleBin);
            this.TabPageClean.Controls.Add(this.cmdSfogliaRemovedFilesFolder);
            this.TabPageClean.Name = "TabPageClean";
            this.TabPageClean.UseVisualStyleBackColor = true;
            // 
            // TabPageConnections
            // 
            resources.ApplyResources(this.TabPageConnections, "TabPageConnections");
            this.TabPageConnections.Controls.Add(this.panel1);
            this.TabPageConnections.Controls.Add(this.label6);
            this.TabPageConnections.Controls.Add(this.OpenRomsetWebPage);
            this.TabPageConnections.Name = "TabPageConnections";
            this.TabPageConnections.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.ArcadeDatabaseConnectionOffline);
            this.panel1.Controls.Add(this.ArcadeDatabaseConnectionAuto);
            this.panel1.Name = "panel1";
            // 
            // ArcadeDatabaseConnectionOffline
            // 
            resources.ApplyResources(this.ArcadeDatabaseConnectionOffline, "ArcadeDatabaseConnectionOffline");
            this.ArcadeDatabaseConnectionOffline.Checked = true;
            this.ArcadeDatabaseConnectionOffline.Name = "ArcadeDatabaseConnectionOffline";
            this.ArcadeDatabaseConnectionOffline.TabStop = true;
            this.ArcadeDatabaseConnectionOffline.UseVisualStyleBackColor = true;
            // 
            // ArcadeDatabaseConnectionAuto
            // 
            resources.ApplyResources(this.ArcadeDatabaseConnectionAuto, "ArcadeDatabaseConnectionAuto");
            this.ArcadeDatabaseConnectionAuto.Name = "ArcadeDatabaseConnectionAuto";
            this.ArcadeDatabaseConnectionAuto.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // cmdSfogliaGamelistXml
            // 
            resources.ApplyResources(this.cmdSfogliaGamelistXml, "cmdSfogliaGamelistXml");
            this.cmdSfogliaGamelistXml.Image = global::MAME_Shrink.Properties.Resources.folder;
            this.cmdSfogliaGamelistXml.Name = "cmdSfogliaGamelistXml";
            this.cmdSfogliaGamelistXml.UseVisualStyleBackColor = true;
            this.cmdSfogliaGamelistXml.Click += new System.EventHandler(this.CmdSfogliaGamelistXml_Click);
            // 
            // cmdSfogliaMameExe
            // 
            resources.ApplyResources(this.cmdSfogliaMameExe, "cmdSfogliaMameExe");
            this.cmdSfogliaMameExe.Image = global::MAME_Shrink.Properties.Resources.folder;
            this.cmdSfogliaMameExe.Name = "cmdSfogliaMameExe";
            this.cmdSfogliaMameExe.UseVisualStyleBackColor = true;
            this.cmdSfogliaMameExe.Click += new System.EventHandler(this.CmdSfogliaMameExe_Click);
            // 
            // cmdSfogliaRomsPath
            // 
            resources.ApplyResources(this.cmdSfogliaRomsPath, "cmdSfogliaRomsPath");
            this.cmdSfogliaRomsPath.Image = global::MAME_Shrink.Properties.Resources.folder;
            this.cmdSfogliaRomsPath.Name = "cmdSfogliaRomsPath";
            this.cmdSfogliaRomsPath.UseVisualStyleBackColor = true;
            this.cmdSfogliaRomsPath.Click += new System.EventHandler(this.CmdSfogliaRomPath_Click);
            // 
            // cmdSfogliaRemovedFilesFolder
            // 
            resources.ApplyResources(this.cmdSfogliaRemovedFilesFolder, "cmdSfogliaRemovedFilesFolder");
            this.cmdSfogliaRemovedFilesFolder.Image = global::MAME_Shrink.Properties.Resources.folder;
            this.cmdSfogliaRemovedFilesFolder.Name = "cmdSfogliaRemovedFilesFolder";
            this.cmdSfogliaRemovedFilesFolder.UseVisualStyleBackColor = true;
            this.cmdSfogliaRemovedFilesFolder.Click += new System.EventHandler(this.CmdSfogliaRemovedFilesFolder_Click);
            // 
            // OpenRomsetWebPage
            // 
            resources.ApplyResources(this.OpenRomsetWebPage, "OpenRomsetWebPage");
            this.OpenRomsetWebPage.Image = global::MAME_Shrink.Properties.Resources.link;
            this.OpenRomsetWebPage.Name = "OpenRomsetWebPage";
            this.OpenRomsetWebPage.TabStop = true;
            this.OpenRomsetWebPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OpenRomsetWebPage_LinkClicked);
            // 
            // cmdLoadData
            // 
            resources.ApplyResources(this.cmdLoadData, "cmdLoadData");
            this.cmdLoadData.Image = global::MAME_Shrink.Properties.Resources.confirm;
            this.cmdLoadData.Name = "cmdLoadData";
            this.cmdLoadData.UseVisualStyleBackColor = true;
            this.cmdLoadData.Click += new System.EventHandler(this.CmdSaveData_Click);
            // 
            // OptionsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdLoadData);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.Shown += new System.EventHandler(this.OptionsForm_Shown);
            this.tabControl1.ResumeLayout(false);
            this.TabPageGamelist.ResumeLayout(false);
            this.TabPageGamelist.PerformLayout();
            this.TabPageRoms.ResumeLayout(false);
            this.TabPageRoms.PerformLayout();
            this.TabPageMame.ResumeLayout(false);
            this.TabPageMame.PerformLayout();
            this.TabPageClean.ResumeLayout(false);
            this.TabPageClean.PerformLayout();
            this.TabPageConnections.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.RadioButton OptionXmlManual;
    private System.Windows.Forms.RadioButton OptionXmlAuto;
    private System.Windows.Forms.TextBox txtGamelistXml;
    private System.Windows.Forms.RadioButton RomPathsManual;
    private System.Windows.Forms.RadioButton RomPathsAuto;
    private System.Windows.Forms.Button cmdSfogliaRomsPath;
    private System.Windows.Forms.TextBox txtRomsPath;
    private System.Windows.Forms.Button cmdSfogliaGamelistXml;
    private System.Windows.Forms.Button cmdSfogliaMameExe;
    private System.Windows.Forms.Button cmdLoadData;
    private System.Windows.Forms.TextBox txtMameExe;
    private System.Windows.Forms.CheckBox ForceGeneration;
    private System.Windows.Forms.TextBox txtRemovedFilesFolder;
    private System.Windows.Forms.Button cmdSfogliaRemovedFilesFolder;
    private System.Windows.Forms.RadioButton CleanDeleteFiles;
    private System.Windows.Forms.RadioButton CleanMoveToFolder;
    private System.Windows.Forms.RadioButton CleanMoveToRecycleBin;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage TabPageGamelist;
    private System.Windows.Forms.TabPage TabPageRoms;
    private System.Windows.Forms.TabPage TabPageMame;
    private System.Windows.Forms.TabPage TabPageClean;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.RadioButton MameSetTypeNonMerged;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.RadioButton MameSetTypeMerged;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.RadioButton MameSetTypeSplitted;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.RadioButton MameSetTypeAuto;
    private System.Windows.Forms.TabPage TabPageConnections;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.LinkLabel OpenRomsetWebPage;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.RadioButton ArcadeDatabaseConnectionOffline;
    private System.Windows.Forms.RadioButton ArcadeDatabaseConnectionAuto;
}