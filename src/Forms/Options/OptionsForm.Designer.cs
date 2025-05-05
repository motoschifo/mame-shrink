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
            this.cmdSfogliaGamelistXml = new System.Windows.Forms.Button();
            this.cmdSfogliaMameExe = new System.Windows.Forms.Button();
            this.TabPageRoms = new System.Windows.Forms.TabPage();
            this.cmdSfogliaRomsPath = new System.Windows.Forms.Button();
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
            this.cmdSfogliaRemovedFilesFolder = new System.Windows.Forms.Button();
            this.TabPageConnections = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ArcadeDatabaseConnectionOffline = new System.Windows.Forms.RadioButton();
            this.ArcadeDatabaseConnectionAuto = new System.Windows.Forms.RadioButton();
            this.OpenRomsetWebPage = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
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
            this.ForceGeneration.Location = new System.Drawing.Point(59, 81);
            this.ForceGeneration.Name = "ForceGeneration";
            this.ForceGeneration.Size = new System.Drawing.Size(336, 20);
            this.ForceGeneration.TabIndex = 3;
            this.ForceGeneration.Text = "Forza sempre la generazione del file XML (metodo più lento)";
            this.ForceGeneration.UseVisualStyleBackColor = true;
            // 
            // OptionXmlManual
            // 
            this.OptionXmlManual.AutoSize = true;
            this.OptionXmlManual.Location = new System.Drawing.Point(23, 124);
            this.OptionXmlManual.Name = "OptionXmlManual";
            this.OptionXmlManual.Size = new System.Drawing.Size(168, 17);
            this.OptionXmlManual.TabIndex = 4;
            this.OptionXmlManual.Text = "Seleziona un file manualmente";
            this.OptionXmlManual.UseVisualStyleBackColor = true;
            this.OptionXmlManual.CheckedChanged += new System.EventHandler(this.OptionXml_CheckedChanged);
            // 
            // OptionXmlAuto
            // 
            this.OptionXmlAuto.AutoSize = true;
            this.OptionXmlAuto.Checked = true;
            this.OptionXmlAuto.Location = new System.Drawing.Point(23, 29);
            this.OptionXmlAuto.Name = "OptionXmlAuto";
            this.OptionXmlAuto.Size = new System.Drawing.Size(177, 17);
            this.OptionXmlAuto.TabIndex = 0;
            this.OptionXmlAuto.TabStop = true;
            this.OptionXmlAuto.Text = "Genera dall\'eseguibile del Mame";
            this.OptionXmlAuto.UseVisualStyleBackColor = true;
            this.OptionXmlAuto.CheckedChanged += new System.EventHandler(this.OptionXml_CheckedChanged);
            // 
            // txtGamelistXml
            // 
            this.txtGamelistXml.Enabled = false;
            this.txtGamelistXml.Location = new System.Drawing.Point(43, 147);
            this.txtGamelistXml.Name = "txtGamelistXml";
            this.txtGamelistXml.Size = new System.Drawing.Size(352, 20);
            this.txtGamelistXml.TabIndex = 5;
            // 
            // txtMameExe
            // 
            this.txtMameExe.Location = new System.Drawing.Point(43, 52);
            this.txtMameExe.Name = "txtMameExe";
            this.txtMameExe.Size = new System.Drawing.Size(352, 20);
            this.txtMameExe.TabIndex = 1;
            // 
            // RomPathsManual
            // 
            this.RomPathsManual.AutoSize = true;
            this.RomPathsManual.Location = new System.Drawing.Point(23, 56);
            this.RomPathsManual.Name = "RomPathsManual";
            this.RomPathsManual.Size = new System.Drawing.Size(128, 17);
            this.RomPathsManual.TabIndex = 1;
            this.RomPathsManual.Text = "Imposta manualmente";
            this.RomPathsManual.UseVisualStyleBackColor = true;
            // 
            // RomPathsAuto
            // 
            this.RomPathsAuto.AutoSize = true;
            this.RomPathsAuto.Checked = true;
            this.RomPathsAuto.Location = new System.Drawing.Point(23, 29);
            this.RomPathsAuto.Name = "RomPathsAuto";
            this.RomPathsAuto.Size = new System.Drawing.Size(121, 17);
            this.RomPathsAuto.TabIndex = 0;
            this.RomPathsAuto.TabStop = true;
            this.RomPathsAuto.Text = "Rileva in automatico";
            this.RomPathsAuto.UseVisualStyleBackColor = true;
            this.RomPathsAuto.CheckedChanged += new System.EventHandler(this.RomPathsAuto_CheckedChanged);
            // 
            // txtRomsPath
            // 
            this.txtRomsPath.Enabled = false;
            this.txtRomsPath.Location = new System.Drawing.Point(40, 79);
            this.txtRomsPath.Name = "txtRomsPath";
            this.txtRomsPath.Size = new System.Drawing.Size(352, 20);
            this.txtRomsPath.TabIndex = 2;
            // 
            // CleanDeleteFiles
            // 
            this.CleanDeleteFiles.AutoSize = true;
            this.CleanDeleteFiles.Location = new System.Drawing.Point(23, 100);
            this.CleanDeleteFiles.Name = "CleanDeleteFiles";
            this.CleanDeleteFiles.Size = new System.Drawing.Size(151, 17);
            this.CleanDeleteFiles.TabIndex = 4;
            this.CleanDeleteFiles.Text = "Cancella i file (sconsigliato)";
            this.CleanDeleteFiles.UseVisualStyleBackColor = true;
            // 
            // CleanMoveToFolder
            // 
            this.CleanMoveToFolder.AutoSize = true;
            this.CleanMoveToFolder.Checked = true;
            this.CleanMoveToFolder.Location = new System.Drawing.Point(23, 29);
            this.CleanMoveToFolder.Name = "CleanMoveToFolder";
            this.CleanMoveToFolder.Size = new System.Drawing.Size(148, 17);
            this.CleanMoveToFolder.TabIndex = 0;
            this.CleanMoveToFolder.TabStop = true;
            this.CleanMoveToFolder.Text = "Sposta i file in una cartella";
            this.CleanMoveToFolder.UseVisualStyleBackColor = true;
            this.CleanMoveToFolder.CheckedChanged += new System.EventHandler(this.CleanMoveToFolder_CheckedChanged);
            // 
            // CleanMoveToRecycleBin
            // 
            this.CleanMoveToRecycleBin.AutoSize = true;
            this.CleanMoveToRecycleBin.Location = new System.Drawing.Point(23, 76);
            this.CleanMoveToRecycleBin.Name = "CleanMoveToRecycleBin";
            this.CleanMoveToRecycleBin.Size = new System.Drawing.Size(193, 17);
            this.CleanMoveToRecycleBin.TabIndex = 3;
            this.CleanMoveToRecycleBin.Text = "Sposta i file nel cestino, se possibile";
            this.CleanMoveToRecycleBin.UseVisualStyleBackColor = true;
            // 
            // txtRemovedFilesFolder
            // 
            this.txtRemovedFilesFolder.Location = new System.Drawing.Point(42, 51);
            this.txtRemovedFilesFolder.Name = "txtRemovedFilesFolder";
            this.txtRemovedFilesFolder.Size = new System.Drawing.Size(352, 20);
            this.txtRemovedFilesFolder.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabPageGamelist);
            this.tabControl1.Controls.Add(this.TabPageRoms);
            this.tabControl1.Controls.Add(this.TabPageMame);
            this.tabControl1.Controls.Add(this.TabPageClean);
            this.tabControl1.Controls.Add(this.TabPageConnections);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(462, 333);
            this.tabControl1.TabIndex = 4;
            // 
            // TabPageGamelist
            // 
            this.TabPageGamelist.Controls.Add(this.OptionXmlManual);
            this.TabPageGamelist.Controls.Add(this.txtGamelistXml);
            this.TabPageGamelist.Controls.Add(this.ForceGeneration);
            this.TabPageGamelist.Controls.Add(this.cmdSfogliaGamelistXml);
            this.TabPageGamelist.Controls.Add(this.txtMameExe);
            this.TabPageGamelist.Controls.Add(this.cmdSfogliaMameExe);
            this.TabPageGamelist.Controls.Add(this.OptionXmlAuto);
            this.TabPageGamelist.Location = new System.Drawing.Point(4, 22);
            this.TabPageGamelist.Name = "TabPageGamelist";
            this.TabPageGamelist.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageGamelist.Size = new System.Drawing.Size(454, 307);
            this.TabPageGamelist.TabIndex = 0;
            this.TabPageGamelist.Text = "Formato dei file";
            this.TabPageGamelist.UseVisualStyleBackColor = true;
            // 
            // cmdSfogliaGamelistXml
            // 
            this.cmdSfogliaGamelistXml.Enabled = false;
            this.cmdSfogliaGamelistXml.Image = global::MAME_Shrink.Properties.Resources.folder;
            this.cmdSfogliaGamelistXml.Location = new System.Drawing.Point(400, 143);
            this.cmdSfogliaGamelistXml.Name = "cmdSfogliaGamelistXml";
            this.cmdSfogliaGamelistXml.Size = new System.Drawing.Size(32, 26);
            this.cmdSfogliaGamelistXml.TabIndex = 6;
            this.cmdSfogliaGamelistXml.UseVisualStyleBackColor = true;
            this.cmdSfogliaGamelistXml.Click += new System.EventHandler(this.CmdSfogliaGamelistXml_Click);
            // 
            // cmdSfogliaMameExe
            // 
            this.cmdSfogliaMameExe.Image = global::MAME_Shrink.Properties.Resources.folder;
            this.cmdSfogliaMameExe.Location = new System.Drawing.Point(400, 48);
            this.cmdSfogliaMameExe.Name = "cmdSfogliaMameExe";
            this.cmdSfogliaMameExe.Size = new System.Drawing.Size(32, 26);
            this.cmdSfogliaMameExe.TabIndex = 2;
            this.cmdSfogliaMameExe.UseVisualStyleBackColor = true;
            this.cmdSfogliaMameExe.Click += new System.EventHandler(this.CmdSfogliaMameExe_Click);
            // 
            // TabPageRoms
            // 
            this.TabPageRoms.Controls.Add(this.RomPathsManual);
            this.TabPageRoms.Controls.Add(this.RomPathsAuto);
            this.TabPageRoms.Controls.Add(this.txtRomsPath);
            this.TabPageRoms.Controls.Add(this.cmdSfogliaRomsPath);
            this.TabPageRoms.Location = new System.Drawing.Point(4, 22);
            this.TabPageRoms.Name = "TabPageRoms";
            this.TabPageRoms.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageRoms.Size = new System.Drawing.Size(454, 307);
            this.TabPageRoms.TabIndex = 1;
            this.TabPageRoms.Text = "Cartelle roms";
            this.TabPageRoms.UseVisualStyleBackColor = true;
            // 
            // cmdSfogliaRomsPath
            // 
            this.cmdSfogliaRomsPath.Enabled = false;
            this.cmdSfogliaRomsPath.Image = global::MAME_Shrink.Properties.Resources.folder;
            this.cmdSfogliaRomsPath.Location = new System.Drawing.Point(398, 75);
            this.cmdSfogliaRomsPath.Name = "cmdSfogliaRomsPath";
            this.cmdSfogliaRomsPath.Size = new System.Drawing.Size(32, 26);
            this.cmdSfogliaRomsPath.TabIndex = 3;
            this.cmdSfogliaRomsPath.UseVisualStyleBackColor = true;
            this.cmdSfogliaRomsPath.Click += new System.EventHandler(this.CmdSfogliaRomPath_Click);
            // 
            // TabPageMame
            // 
            this.TabPageMame.Controls.Add(this.label5);
            this.TabPageMame.Controls.Add(this.MameSetTypeAuto);
            this.TabPageMame.Controls.Add(this.label4);
            this.TabPageMame.Controls.Add(this.label3);
            this.TabPageMame.Controls.Add(this.MameSetTypeNonMerged);
            this.TabPageMame.Controls.Add(this.label2);
            this.TabPageMame.Controls.Add(this.MameSetTypeMerged);
            this.TabPageMame.Controls.Add(this.label1);
            this.TabPageMame.Controls.Add(this.MameSetTypeSplitted);
            this.TabPageMame.Location = new System.Drawing.Point(4, 22);
            this.TabPageMame.Name = "TabPageMame";
            this.TabPageMame.Size = new System.Drawing.Size(454, 307);
            this.TabPageMame.TabIndex = 2;
            this.TabPageMame.Text = "Set Mame";
            this.TabPageMame.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(41, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(381, 36);
            this.label5.TabIndex = 1;
            this.label5.Text = "Il file XML generato dal Mame decide i legami tra i set, quindi potrebbero esserc" +
    "i uno o due file per parent e clone";
            // 
            // MameSetTypeAuto
            // 
            this.MameSetTypeAuto.AutoSize = true;
            this.MameSetTypeAuto.Checked = true;
            this.MameSetTypeAuto.Location = new System.Drawing.Point(23, 29);
            this.MameSetTypeAuto.Name = "MameSetTypeAuto";
            this.MameSetTypeAuto.Size = new System.Drawing.Size(78, 17);
            this.MameSetTypeAuto.TabIndex = 0;
            this.MameSetTypeAuto.TabStop = true;
            this.MameSetTypeAuto.Text = "Automatico";
            this.MameSetTypeAuto.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(23, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(399, 48);
            this.label4.TabIndex = 8;
            this.label4.Text = "Questa scelta influenza il modo in cui i giochi vengono selezionati, prestare la " +
    "massima attenzione per evitare di fare danni";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(41, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(381, 35);
            this.label3.TabIndex = 7;
            this.label3.Text = "I set parent e cloni non condividono file, quindi ogni set è indipendente. Ci son" +
    "o due file zip";
            // 
            // MameSetTypeNonMerged
            // 
            this.MameSetTypeNonMerged.AutoSize = true;
            this.MameSetTypeNonMerged.Location = new System.Drawing.Point(23, 189);
            this.MameSetTypeNonMerged.Name = "MameSetTypeNonMerged";
            this.MameSetTypeNonMerged.Size = new System.Drawing.Size(83, 17);
            this.MameSetTypeNonMerged.TabIndex = 6;
            this.MameSetTypeNonMerged.Text = "Non-merged";
            this.MameSetTypeNonMerged.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(41, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(381, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "I due set clone e parent sono nello stesso file zip";
            // 
            // MameSetTypeMerged
            // 
            this.MameSetTypeMerged.AutoSize = true;
            this.MameSetTypeMerged.Location = new System.Drawing.Point(23, 144);
            this.MameSetTypeMerged.Name = "MameSetTypeMerged";
            this.MameSetTypeMerged.Size = new System.Drawing.Size(61, 17);
            this.MameSetTypeMerged.TabIndex = 4;
            this.MameSetTypeMerged.Text = "Merged";
            this.MameSetTypeMerged.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(41, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Il set clone contiene solo la parte che differisce rispetto al set parent, ci son" +
    "o due file zip ed uno è generalmente molto più piccolo";
            // 
            // MameSetTypeSplitted
            // 
            this.MameSetTypeSplitted.AutoSize = true;
            this.MameSetTypeSplitted.Location = new System.Drawing.Point(23, 88);
            this.MameSetTypeSplitted.Name = "MameSetTypeSplitted";
            this.MameSetTypeSplitted.Size = new System.Drawing.Size(57, 17);
            this.MameSetTypeSplitted.TabIndex = 2;
            this.MameSetTypeSplitted.Text = "Splited";
            this.MameSetTypeSplitted.UseVisualStyleBackColor = true;
            // 
            // TabPageClean
            // 
            this.TabPageClean.Controls.Add(this.CleanDeleteFiles);
            this.TabPageClean.Controls.Add(this.txtRemovedFilesFolder);
            this.TabPageClean.Controls.Add(this.CleanMoveToFolder);
            this.TabPageClean.Controls.Add(this.CleanMoveToRecycleBin);
            this.TabPageClean.Controls.Add(this.cmdSfogliaRemovedFilesFolder);
            this.TabPageClean.Location = new System.Drawing.Point(4, 22);
            this.TabPageClean.Name = "TabPageClean";
            this.TabPageClean.Size = new System.Drawing.Size(454, 307);
            this.TabPageClean.TabIndex = 3;
            this.TabPageClean.Text = "Pulizia";
            this.TabPageClean.UseVisualStyleBackColor = true;
            // 
            // cmdSfogliaRemovedFilesFolder
            // 
            this.cmdSfogliaRemovedFilesFolder.Image = global::MAME_Shrink.Properties.Resources.folder;
            this.cmdSfogliaRemovedFilesFolder.Location = new System.Drawing.Point(397, 47);
            this.cmdSfogliaRemovedFilesFolder.Name = "cmdSfogliaRemovedFilesFolder";
            this.cmdSfogliaRemovedFilesFolder.Size = new System.Drawing.Size(32, 26);
            this.cmdSfogliaRemovedFilesFolder.TabIndex = 2;
            this.cmdSfogliaRemovedFilesFolder.UseVisualStyleBackColor = true;
            this.cmdSfogliaRemovedFilesFolder.Click += new System.EventHandler(this.CmdSfogliaRemovedFilesFolder_Click);
            // 
            // TabPageConnections
            // 
            this.TabPageConnections.Controls.Add(this.panel1);
            this.TabPageConnections.Controls.Add(this.OpenRomsetWebPage);
            this.TabPageConnections.Controls.Add(this.label6);
            this.TabPageConnections.Location = new System.Drawing.Point(4, 22);
            this.TabPageConnections.Name = "TabPageConnections";
            this.TabPageConnections.Size = new System.Drawing.Size(454, 307);
            this.TabPageConnections.TabIndex = 4;
            this.TabPageConnections.Text = "Connessioni";
            this.TabPageConnections.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ArcadeDatabaseConnectionOffline);
            this.panel1.Controls.Add(this.ArcadeDatabaseConnectionAuto);
            this.panel1.Location = new System.Drawing.Point(23, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 57);
            this.panel1.TabIndex = 63;
            // 
            // ArcadeDatabaseConnectionOffline
            // 
            this.ArcadeDatabaseConnectionOffline.AutoSize = true;
            this.ArcadeDatabaseConnectionOffline.Checked = true;
            this.ArcadeDatabaseConnectionOffline.Location = new System.Drawing.Point(3, 3);
            this.ArcadeDatabaseConnectionOffline.Name = "ArcadeDatabaseConnectionOffline";
            this.ArcadeDatabaseConnectionOffline.Size = new System.Drawing.Size(235, 17);
            this.ArcadeDatabaseConnectionOffline.TabIndex = 1;
            this.ArcadeDatabaseConnectionOffline.TabStop = true;
            this.ArcadeDatabaseConnectionOffline.Text = "La connessione ad internet non è disponibile";
            this.ArcadeDatabaseConnectionOffline.UseVisualStyleBackColor = true;
            // 
            // ArcadeDatabaseConnectionAuto
            // 
            this.ArcadeDatabaseConnectionAuto.AutoSize = true;
            this.ArcadeDatabaseConnectionAuto.Location = new System.Drawing.Point(3, 26);
            this.ArcadeDatabaseConnectionAuto.Name = "ArcadeDatabaseConnectionAuto";
            this.ArcadeDatabaseConnectionAuto.Size = new System.Drawing.Size(193, 17);
            this.ArcadeDatabaseConnectionAuto.TabIndex = 2;
            this.ArcadeDatabaseConnectionAuto.Text = "Utilizza la connessione, se presente";
            this.ArcadeDatabaseConnectionAuto.UseVisualStyleBackColor = true;
            // 
            // OpenRomsetWebPage
            // 
            this.OpenRomsetWebPage.Image = global::MAME_Shrink.Properties.Resources.link;
            this.OpenRomsetWebPage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OpenRomsetWebPage.Location = new System.Drawing.Point(262, 28);
            this.OpenRomsetWebPage.Name = "OpenRomsetWebPage";
            this.OpenRomsetWebPage.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.OpenRomsetWebPage.Size = new System.Drawing.Size(174, 18);
            this.OpenRomsetWebPage.TabIndex = 62;
            this.OpenRomsetWebPage.TabStop = true;
            this.OpenRomsetWebPage.Text = "adb.arcadedatabase.net";
            this.OpenRomsetWebPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OpenRomsetWebPage.Visible = false;
            this.OpenRomsetWebPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OpenRomsetWebPage_LinkClicked);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 18);
            this.label6.TabIndex = 3;
            this.label6.Text = "Sito Arcade Database";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdLoadData
            // 
            this.cmdLoadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLoadData.Image = global::MAME_Shrink.Properties.Resources.confirm;
            this.cmdLoadData.Location = new System.Drawing.Point(185, 351);
            this.cmdLoadData.Name = "cmdLoadData";
            this.cmdLoadData.Size = new System.Drawing.Size(111, 35);
            this.cmdLoadData.TabIndex = 3;
            this.cmdLoadData.Text = "Salva";
            this.cmdLoadData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdLoadData.UseVisualStyleBackColor = true;
            this.cmdLoadData.Click += new System.EventHandler(this.CmdSaveData_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 395);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdLoadData);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opzioni e percorsi";
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