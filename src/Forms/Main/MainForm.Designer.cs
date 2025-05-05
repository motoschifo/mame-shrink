namespace MAME_Shrink.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.GamesListView = new System.Windows.Forms.ListView();
            this.lblInfo = new System.Windows.Forms.Label();
            this.GridTextFilterTimer = new System.Windows.Forms.Timer(this.components);
            this.Tooltips = new System.Windows.Forms.ToolTip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LabelManueExe = new System.Windows.Forms.Label();
            this.LabelGamelistXml = new System.Windows.Forms.Label();
            this.LabelRomsPath = new System.Windows.Forms.Label();
            this.MenuColumnItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripColumnRomset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripColumnYear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripColumnManufacturer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripColumnCloneOf = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripColumnDriverStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripColumnGenre = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripColumnRelease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripColumnPlayers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripColumnButtons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripColumnDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilters = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuFilterAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFilterType = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterTypeParent = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterTypeClone = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFilterTypeMamecab = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFilterTypeGame = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterTypeBios = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterTypeDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterTypeMechanical = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterAudio = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterAudioUnsupported = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFilterAudioMono = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterAudioStereo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterAudioMultiChannel = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFilterAudioEmulated = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterAudioImperfect = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterAudioUnemulated = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoType = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoTypeRaster = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoTypeVector = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoTypeLCD = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoTypeSVG = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoTypeUnknown = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoScreens = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoScreensNone = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFilterVideoScreensOne = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoScreensOneOrMore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFilterVideoScreensTwo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoScreensTwoOrMore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFilterVideoScreensThree = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoScreensThreeOrMore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFilterVideoScreensFour = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoScreensFourOrMore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFilterVideoScreensFiveOrMore = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuVideoOrientation = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoOrientationHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoOrientationVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFilterVideoOrientation0 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoOrientarion90 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoOrientation180 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoOrientation270 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoGraphic = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoGraphicEmulated = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoGraphicImperfect = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoGraphicUnemulated = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoColor = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoColorEmulated = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoColorImperfect = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterVideoColorUnemulated = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFilterClassifications = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterClassificationsGenre = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterClassificationsCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterClassificationsSerie = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterSample = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterSampleUsed = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterSampleUnused = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterCHD = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterCHDRequired = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterCHDNotRequired = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFilterCHDGood = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterCHDBadDump = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterCHDNoDump = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterSaveState = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterSaveStateSupported = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterSaveStateUnsupported = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterSaveStateUnknown = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterRelease = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFilterDriver = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterDriverWorking = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterDriverImperfect = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterDriverNotWorking = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterDriverUnknown = new System.Windows.Forms.ToolStripMenuItem();
            this.cocktailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterProtection = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterProtectionEmulated = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterProtectionImperfect = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilterProtectionUnemulated = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolbarMenuGrid = new System.Windows.Forms.MenuStrip();
            this.MenuRemoveFromSelectedGames = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToggleSelectedGames = new System.Windows.Forms.ToolStripMenuItem();
            this.GridTextFilter = new System.Windows.Forms.ToolStripTextBox();
            this.MenuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuShowAllGames = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuShowExistingFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuShowSelectedGames = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuShowNotSelectedGames = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectedRomsetName = new System.Windows.Forms.Label();
            this.pnlRomset = new System.Windows.Forms.Panel();
            this.KeyValueRomset = new MAME_Shrink.Components.KeyValueTable();
            this.OpenRomsetWebPage = new System.Windows.Forms.LinkLabel();
            this.ValidateRomset = new System.Windows.Forms.CheckBox();
            this.SnapshotPlaceholder = new System.Windows.Forms.PictureBox();
            this.MenuAddToSelectedGames = new System.Windows.Forms.ToolStripMenuItem();
            this.StartClean = new System.Windows.Forms.Button();
            this.ChangeOptions = new System.Windows.Forms.Button();
            this.Snapshot = new System.Windows.Forms.PictureBox();
            this.LoadGames = new System.Windows.Forms.Button();
            this.CancelCurrentProcess = new System.Windows.Forms.Button();
            this.MenuColumnItems.SuspendLayout();
            this.MenuFilters.SuspendLayout();
            this.ToolbarMenuGrid.SuspendLayout();
            this.pnlRomset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SnapshotPlaceholder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Snapshot)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Eseguibile Mame:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "options");
            this.ImageList.Images.SetKeyName(1, "right");
            this.ImageList.Images.SetKeyName(2, "cancel");
            this.ImageList.Images.SetKeyName(3, "cancel-red");
            this.ImageList.Images.SetKeyName(4, "warning");
            this.ImageList.Images.SetKeyName(5, "waste");
            this.ImageList.Images.SetKeyName(6, "");
            this.ImageList.Images.SetKeyName(7, "true-false");
            // 
            // GamesListView
            // 
            this.GamesListView.CheckBoxes = true;
            this.GamesListView.Enabled = false;
            this.GamesListView.HideSelection = false;
            this.GamesListView.Location = new System.Drawing.Point(12, 164);
            this.GamesListView.Name = "GamesListView";
            this.GamesListView.Size = new System.Drawing.Size(635, 431);
            this.GamesListView.TabIndex = 8;
            this.GamesListView.UseCompatibleStateImageBehavior = false;
            this.GamesListView.VirtualMode = true;
            this.GamesListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.GamesListView_ColumnClick);
            this.GamesListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.GamesListView_DrawColumnHeader);
            this.GamesListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.GamesListView_DrawItem);
            this.GamesListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.GamesListView_RetrieveVirtualItem);
            this.GamesListView.SelectedIndexChanged += new System.EventHandler(this.GamesListView_SelectedIndexChanged);
            this.GamesListView.DoubleClick += new System.EventHandler(this.GamesListView_DoubleClick);
            this.GamesListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GamesListView_KeyDown);
            this.GamesListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GamesListView_MouseClick);
            this.GamesListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GamesListView_MouseDown);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoEllipsis = true;
            this.lblInfo.Location = new System.Drawing.Point(24, 110);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(624, 18);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.UseMnemonic = false;
            // 
            // GridTextFilterTimer
            // 
            this.GridTextFilterTimer.Interval = 500;
            this.GridTextFilterTimer.Tick += new System.EventHandler(this.GridTextFilterTimer_Tick);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 19);
            this.label5.TabIndex = 45;
            this.label5.Text = "Cartella roms:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 19);
            this.label6.TabIndex = 49;
            this.label6.Text = "Lista giochi XML:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelManueExe
            // 
            this.LabelManueExe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelManueExe.Location = new System.Drawing.Point(126, 10);
            this.LabelManueExe.Name = "LabelManueExe";
            this.LabelManueExe.Size = new System.Drawing.Size(522, 19);
            this.LabelManueExe.TabIndex = 0;
            this.LabelManueExe.Text = "LabelManueExe";
            this.LabelManueExe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelGamelistXml
            // 
            this.LabelGamelistXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGamelistXml.Location = new System.Drawing.Point(126, 29);
            this.LabelGamelistXml.Name = "LabelGamelistXml";
            this.LabelGamelistXml.Size = new System.Drawing.Size(522, 19);
            this.LabelGamelistXml.TabIndex = 0;
            this.LabelGamelistXml.Text = "LabelGamelistXml";
            this.LabelGamelistXml.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelRomsPath
            // 
            this.LabelRomsPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelRomsPath.Location = new System.Drawing.Point(126, 48);
            this.LabelRomsPath.Name = "LabelRomsPath";
            this.LabelRomsPath.Size = new System.Drawing.Size(522, 19);
            this.LabelRomsPath.TabIndex = 0;
            this.LabelRomsPath.Text = "LabelRomsPath";
            this.LabelRomsPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MenuColumnItems
            // 
            this.MenuColumnItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripColumnRomset,
            this.toolStripColumnYear,
            this.toolStripColumnManufacturer,
            this.toolStripColumnCloneOf,
            this.toolStripColumnDriverStatus,
            this.toolStripColumnGenre,
            this.toolStripColumnRelease,
            this.toolStripColumnPlayers,
            this.toolStripColumnButtons,
            this.toolStripColumnDisplay});
            this.MenuColumnItems.Name = "menuColumns";
            this.MenuColumnItems.Size = new System.Drawing.Size(132, 224);
            // 
            // toolStripColumnRomset
            // 
            this.toolStripColumnRomset.Checked = true;
            this.toolStripColumnRomset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripColumnRomset.Enabled = false;
            this.toolStripColumnRomset.Name = "toolStripColumnRomset";
            this.toolStripColumnRomset.Size = new System.Drawing.Size(131, 22);
            this.toolStripColumnRomset.Text = "Romset";
            // 
            // toolStripColumnYear
            // 
            this.toolStripColumnYear.Checked = true;
            this.toolStripColumnYear.CheckOnClick = true;
            this.toolStripColumnYear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripColumnYear.Name = "toolStripColumnYear";
            this.toolStripColumnYear.Size = new System.Drawing.Size(131, 22);
            this.toolStripColumnYear.Text = "Anno";
            // 
            // toolStripColumnManufacturer
            // 
            this.toolStripColumnManufacturer.Checked = true;
            this.toolStripColumnManufacturer.CheckOnClick = true;
            this.toolStripColumnManufacturer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripColumnManufacturer.Name = "toolStripColumnManufacturer";
            this.toolStripColumnManufacturer.Size = new System.Drawing.Size(131, 22);
            this.toolStripColumnManufacturer.Text = "Produttore";
            // 
            // toolStripColumnCloneOf
            // 
            this.toolStripColumnCloneOf.Checked = true;
            this.toolStripColumnCloneOf.CheckOnClick = true;
            this.toolStripColumnCloneOf.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripColumnCloneOf.Name = "toolStripColumnCloneOf";
            this.toolStripColumnCloneOf.Size = new System.Drawing.Size(131, 22);
            this.toolStripColumnCloneOf.Text = "Clone";
            // 
            // toolStripColumnDriverStatus
            // 
            this.toolStripColumnDriverStatus.Checked = true;
            this.toolStripColumnDriverStatus.CheckOnClick = true;
            this.toolStripColumnDriverStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripColumnDriverStatus.Name = "toolStripColumnDriverStatus";
            this.toolStripColumnDriverStatus.Size = new System.Drawing.Size(131, 22);
            this.toolStripColumnDriverStatus.Text = "Stato";
            // 
            // toolStripColumnGenre
            // 
            this.toolStripColumnGenre.Checked = true;
            this.toolStripColumnGenre.CheckOnClick = true;
            this.toolStripColumnGenre.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripColumnGenre.Name = "toolStripColumnGenre";
            this.toolStripColumnGenre.Size = new System.Drawing.Size(131, 22);
            this.toolStripColumnGenre.Text = "Genere";
            // 
            // toolStripColumnRelease
            // 
            this.toolStripColumnRelease.Checked = true;
            this.toolStripColumnRelease.CheckOnClick = true;
            this.toolStripColumnRelease.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripColumnRelease.Name = "toolStripColumnRelease";
            this.toolStripColumnRelease.Size = new System.Drawing.Size(131, 22);
            this.toolStripColumnRelease.Text = "Versione";
            // 
            // toolStripColumnPlayers
            // 
            this.toolStripColumnPlayers.Checked = true;
            this.toolStripColumnPlayers.CheckOnClick = true;
            this.toolStripColumnPlayers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripColumnPlayers.Name = "toolStripColumnPlayers";
            this.toolStripColumnPlayers.Size = new System.Drawing.Size(131, 22);
            this.toolStripColumnPlayers.Text = "Giocatori";
            // 
            // toolStripColumnButtons
            // 
            this.toolStripColumnButtons.Checked = true;
            this.toolStripColumnButtons.CheckOnClick = true;
            this.toolStripColumnButtons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripColumnButtons.Name = "toolStripColumnButtons";
            this.toolStripColumnButtons.Size = new System.Drawing.Size(131, 22);
            this.toolStripColumnButtons.Text = "Pulsanti";
            // 
            // toolStripColumnDisplay
            // 
            this.toolStripColumnDisplay.Checked = true;
            this.toolStripColumnDisplay.CheckOnClick = true;
            this.toolStripColumnDisplay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripColumnDisplay.DoubleClickEnabled = true;
            this.toolStripColumnDisplay.Name = "toolStripColumnDisplay";
            this.toolStripColumnDisplay.Size = new System.Drawing.Size(131, 22);
            this.toolStripColumnDisplay.Text = "Schermo";
            // 
            // MenuFilters
            // 
            this.MenuFilters.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFilterAll,
            this.toolStripSeparator6,
            this.MenuFilterType,
            this.MenuFilterAudio,
            this.MenuFilterVideo,
            this.MenuSeparator4,
            this.MenuFilterClassifications,
            this.MenuFilterSample,
            this.MenuFilterCHD,
            this.MenuFilterSaveState,
            this.MenuFilterRelease,
            this.MenuSeparator6,
            this.MenuFilterDriver,
            this.cocktailToolStripMenuItem,
            this.MenuFilterProtection});
            this.MenuFilters.Name = "menuFilters";
            this.MenuFilters.Size = new System.Drawing.Size(149, 286);
            // 
            // MenuFilterAll
            // 
            this.MenuFilterAll.Name = "MenuFilterAll";
            this.MenuFilterAll.Size = new System.Drawing.Size(148, 22);
            this.MenuFilterAll.Text = "Tutti";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(145, 6);
            // 
            // MenuFilterType
            // 
            this.MenuFilterType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFilterTypeParent,
            this.MenuFilterTypeClone,
            this.MenuSeparator1,
            this.MenuFilterTypeMamecab,
            this.toolStripSeparator11,
            this.MenuFilterTypeGame,
            this.MenuFilterTypeBios,
            this.MenuFilterTypeDevice,
            this.MenuFilterTypeMechanical});
            this.MenuFilterType.Name = "MenuFilterType";
            this.MenuFilterType.Size = new System.Drawing.Size(148, 22);
            this.MenuFilterType.Text = "Tipo";
            // 
            // MenuFilterTypeParent
            // 
            this.MenuFilterTypeParent.Name = "MenuFilterTypeParent";
            this.MenuFilterTypeParent.Size = new System.Drawing.Size(181, 22);
            this.MenuFilterTypeParent.Text = "Parent";
            // 
            // MenuFilterTypeClone
            // 
            this.MenuFilterTypeClone.Name = "MenuFilterTypeClone";
            this.MenuFilterTypeClone.Size = new System.Drawing.Size(181, 22);
            this.MenuFilterTypeClone.Text = "Clone";
            // 
            // MenuSeparator1
            // 
            this.MenuSeparator1.Name = "MenuSeparator1";
            this.MenuSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // MenuFilterTypeMamecab
            // 
            this.MenuFilterTypeMamecab.Name = "MenuFilterTypeMamecab";
            this.MenuFilterTypeMamecab.Size = new System.Drawing.Size(181, 22);
            this.MenuFilterTypeMamecab.Text = "MameCab";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(178, 6);
            // 
            // MenuFilterTypeGame
            // 
            this.MenuFilterTypeGame.Name = "MenuFilterTypeGame";
            this.MenuFilterTypeGame.Size = new System.Drawing.Size(181, 22);
            this.MenuFilterTypeGame.Text = "Gioco";
            // 
            // MenuFilterTypeBios
            // 
            this.MenuFilterTypeBios.Name = "MenuFilterTypeBios";
            this.MenuFilterTypeBios.Size = new System.Drawing.Size(181, 22);
            this.MenuFilterTypeBios.Text = "Bios";
            // 
            // MenuFilterTypeDevice
            // 
            this.MenuFilterTypeDevice.Name = "MenuFilterTypeDevice";
            this.MenuFilterTypeDevice.Size = new System.Drawing.Size(181, 22);
            this.MenuFilterTypeDevice.Text = "Dispositivo / Scheda";
            // 
            // MenuFilterTypeMechanical
            // 
            this.MenuFilterTypeMechanical.Name = "MenuFilterTypeMechanical";
            this.MenuFilterTypeMechanical.Size = new System.Drawing.Size(181, 22);
            this.MenuFilterTypeMechanical.Text = "Meccanico";
            // 
            // MenuFilterAudio
            // 
            this.MenuFilterAudio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFilterAudioUnsupported,
            this.MenuSeparator2,
            this.MenuFilterAudioMono,
            this.MenuFilterAudioStereo,
            this.MenuFilterAudioMultiChannel,
            this.MenuSeparator3,
            this.MenuFilterAudioEmulated,
            this.MenuFilterAudioImperfect,
            this.MenuFilterAudioUnemulated});
            this.MenuFilterAudio.Name = "MenuFilterAudio";
            this.MenuFilterAudio.Size = new System.Drawing.Size(148, 22);
            this.MenuFilterAudio.Text = "Audio";
            // 
            // MenuFilterAudioUnsupported
            // 
            this.MenuFilterAudioUnsupported.Name = "MenuFilterAudioUnsupported";
            this.MenuFilterAudioUnsupported.Size = new System.Drawing.Size(233, 22);
            this.MenuFilterAudioUnsupported.Text = "Audio non supportato";
            // 
            // MenuSeparator2
            // 
            this.MenuSeparator2.Name = "MenuSeparator2";
            this.MenuSeparator2.Size = new System.Drawing.Size(230, 6);
            // 
            // MenuFilterAudioMono
            // 
            this.MenuFilterAudioMono.Name = "MenuFilterAudioMono";
            this.MenuFilterAudioMono.Size = new System.Drawing.Size(233, 22);
            this.MenuFilterAudioMono.Text = "Audio monofonico";
            // 
            // MenuFilterAudioStereo
            // 
            this.MenuFilterAudioStereo.Name = "MenuFilterAudioStereo";
            this.MenuFilterAudioStereo.Size = new System.Drawing.Size(233, 22);
            this.MenuFilterAudioStereo.Text = "Audio stereo";
            // 
            // MenuFilterAudioMultiChannel
            // 
            this.MenuFilterAudioMultiChannel.Name = "MenuFilterAudioMultiChannel";
            this.MenuFilterAudioMultiChannel.Size = new System.Drawing.Size(233, 22);
            this.MenuFilterAudioMultiChannel.Text = "Audio multicanale";
            // 
            // MenuSeparator3
            // 
            this.MenuSeparator3.Name = "MenuSeparator3";
            this.MenuSeparator3.Size = new System.Drawing.Size(230, 6);
            // 
            // MenuFilterAudioEmulated
            // 
            this.MenuFilterAudioEmulated.Name = "MenuFilterAudioEmulated";
            this.MenuFilterAudioEmulated.Size = new System.Drawing.Size(233, 22);
            this.MenuFilterAudioEmulated.Text = "Suono emulato correttamente";
            // 
            // MenuFilterAudioImperfect
            // 
            this.MenuFilterAudioImperfect.Name = "MenuFilterAudioImperfect";
            this.MenuFilterAudioImperfect.Size = new System.Drawing.Size(233, 22);
            this.MenuFilterAudioImperfect.Text = "Suono imperfetto";
            // 
            // MenuFilterAudioUnemulated
            // 
            this.MenuFilterAudioUnemulated.Name = "MenuFilterAudioUnemulated";
            this.MenuFilterAudioUnemulated.Size = new System.Drawing.Size(233, 22);
            this.MenuFilterAudioUnemulated.Text = "Suono non emulato";
            // 
            // MenuFilterVideo
            // 
            this.MenuFilterVideo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFilterVideoType,
            this.MenuFilterVideoScreens,
            this.MenuVideoOrientation,
            this.MenuFilterVideoGraphic,
            this.MenuFilterVideoColor});
            this.MenuFilterVideo.Name = "MenuFilterVideo";
            this.MenuFilterVideo.Size = new System.Drawing.Size(148, 22);
            this.MenuFilterVideo.Text = "Video";
            // 
            // MenuFilterVideoType
            // 
            this.MenuFilterVideoType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFilterVideoTypeRaster,
            this.MenuFilterVideoTypeVector,
            this.MenuFilterVideoTypeLCD,
            this.MenuFilterVideoTypeSVG,
            this.MenuFilterVideoTypeUnknown});
            this.MenuFilterVideoType.Name = "MenuFilterVideoType";
            this.MenuFilterVideoType.Size = new System.Drawing.Size(176, 22);
            this.MenuFilterVideoType.Text = "Tipo schermo";
            // 
            // MenuFilterVideoTypeRaster
            // 
            this.MenuFilterVideoTypeRaster.Name = "MenuFilterVideoTypeRaster";
            this.MenuFilterVideoTypeRaster.Size = new System.Drawing.Size(139, 22);
            this.MenuFilterVideoTypeRaster.Text = "Raster";
            // 
            // MenuFilterVideoTypeVector
            // 
            this.MenuFilterVideoTypeVector.Name = "MenuFilterVideoTypeVector";
            this.MenuFilterVideoTypeVector.Size = new System.Drawing.Size(139, 22);
            this.MenuFilterVideoTypeVector.Text = "Vettoriale";
            // 
            // MenuFilterVideoTypeLCD
            // 
            this.MenuFilterVideoTypeLCD.Name = "MenuFilterVideoTypeLCD";
            this.MenuFilterVideoTypeLCD.Size = new System.Drawing.Size(139, 22);
            this.MenuFilterVideoTypeLCD.Text = "LCD";
            // 
            // MenuFilterVideoTypeSVG
            // 
            this.MenuFilterVideoTypeSVG.Name = "MenuFilterVideoTypeSVG";
            this.MenuFilterVideoTypeSVG.Size = new System.Drawing.Size(139, 22);
            this.MenuFilterVideoTypeSVG.Text = "SVG";
            // 
            // MenuFilterVideoTypeUnknown
            // 
            this.MenuFilterVideoTypeUnknown.Name = "MenuFilterVideoTypeUnknown";
            this.MenuFilterVideoTypeUnknown.Size = new System.Drawing.Size(139, 22);
            this.MenuFilterVideoTypeUnknown.Text = "Sconosciuto";
            // 
            // MenuFilterVideoScreens
            // 
            this.MenuFilterVideoScreens.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFilterVideoScreensNone,
            this.toolStripMenuItem5,
            this.MenuFilterVideoScreensOne,
            this.MenuFilterVideoScreensOneOrMore,
            this.toolStripMenuItem6,
            this.MenuFilterVideoScreensTwo,
            this.MenuFilterVideoScreensTwoOrMore,
            this.toolStripMenuItem7,
            this.MenuFilterVideoScreensThree,
            this.MenuFilterVideoScreensThreeOrMore,
            this.toolStripMenuItem8,
            this.MenuFilterVideoScreensFour,
            this.MenuFilterVideoScreensFourOrMore,
            this.toolStripMenuItem9,
            this.MenuFilterVideoScreensFiveOrMore});
            this.MenuFilterVideoScreens.Name = "MenuFilterVideoScreens";
            this.MenuFilterVideoScreens.Size = new System.Drawing.Size(176, 22);
            this.MenuFilterVideoScreens.Text = "Numero di schermi";
            // 
            // MenuFilterVideoScreensNone
            // 
            this.MenuFilterVideoScreensNone.Name = "MenuFilterVideoScreensNone";
            this.MenuFilterVideoScreensNone.Size = new System.Drawing.Size(205, 22);
            this.MenuFilterVideoScreensNone.Text = "Non ha schermi";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(202, 6);
            // 
            // MenuFilterVideoScreensOne
            // 
            this.MenuFilterVideoScreensOne.Name = "MenuFilterVideoScreensOne";
            this.MenuFilterVideoScreensOne.Size = new System.Drawing.Size(205, 22);
            this.MenuFilterVideoScreensOne.Text = "Ha un solo schermo";
            // 
            // MenuFilterVideoScreensOneOrMore
            // 
            this.MenuFilterVideoScreensOneOrMore.Name = "MenuFilterVideoScreensOneOrMore";
            this.MenuFilterVideoScreensOneOrMore.Size = new System.Drawing.Size(205, 22);
            this.MenuFilterVideoScreensOneOrMore.Text = "Ha almeno uno schermo";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(202, 6);
            // 
            // MenuFilterVideoScreensTwo
            // 
            this.MenuFilterVideoScreensTwo.Name = "MenuFilterVideoScreensTwo";
            this.MenuFilterVideoScreensTwo.Size = new System.Drawing.Size(205, 22);
            this.MenuFilterVideoScreensTwo.Text = "Ha 2 schermi";
            // 
            // MenuFilterVideoScreensTwoOrMore
            // 
            this.MenuFilterVideoScreensTwoOrMore.Name = "MenuFilterVideoScreensTwoOrMore";
            this.MenuFilterVideoScreensTwoOrMore.Size = new System.Drawing.Size(205, 22);
            this.MenuFilterVideoScreensTwoOrMore.Text = "Ha 2 o più schermi";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(202, 6);
            // 
            // MenuFilterVideoScreensThree
            // 
            this.MenuFilterVideoScreensThree.Name = "MenuFilterVideoScreensThree";
            this.MenuFilterVideoScreensThree.Size = new System.Drawing.Size(205, 22);
            this.MenuFilterVideoScreensThree.Text = "Ha 3 schermi";
            // 
            // MenuFilterVideoScreensThreeOrMore
            // 
            this.MenuFilterVideoScreensThreeOrMore.Name = "MenuFilterVideoScreensThreeOrMore";
            this.MenuFilterVideoScreensThreeOrMore.Size = new System.Drawing.Size(205, 22);
            this.MenuFilterVideoScreensThreeOrMore.Text = "Ha 3 o più schermi";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(202, 6);
            // 
            // MenuFilterVideoScreensFour
            // 
            this.MenuFilterVideoScreensFour.Name = "MenuFilterVideoScreensFour";
            this.MenuFilterVideoScreensFour.Size = new System.Drawing.Size(205, 22);
            this.MenuFilterVideoScreensFour.Text = "Ha 4 schermi";
            // 
            // MenuFilterVideoScreensFourOrMore
            // 
            this.MenuFilterVideoScreensFourOrMore.Name = "MenuFilterVideoScreensFourOrMore";
            this.MenuFilterVideoScreensFourOrMore.Size = new System.Drawing.Size(205, 22);
            this.MenuFilterVideoScreensFourOrMore.Text = "Ha 4 o più schermi";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(202, 6);
            // 
            // MenuFilterVideoScreensFiveOrMore
            // 
            this.MenuFilterVideoScreensFiveOrMore.Name = "MenuFilterVideoScreensFiveOrMore";
            this.MenuFilterVideoScreensFiveOrMore.Size = new System.Drawing.Size(205, 22);
            this.MenuFilterVideoScreensFiveOrMore.Text = "Ha più di 4 schermi";
            // 
            // MenuVideoOrientation
            // 
            this.MenuVideoOrientation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFilterVideoOrientationHorizontal,
            this.MenuFilterVideoOrientationVertical,
            this.toolStripMenuItem1,
            this.MenuFilterVideoOrientation0,
            this.MenuFilterVideoOrientarion90,
            this.MenuFilterVideoOrientation180,
            this.MenuFilterVideoOrientation270});
            this.MenuVideoOrientation.Name = "MenuVideoOrientation";
            this.MenuVideoOrientation.Size = new System.Drawing.Size(176, 22);
            this.MenuVideoOrientation.Text = "Orientamento";
            // 
            // MenuFilterVideoOrientationHorizontal
            // 
            this.MenuFilterVideoOrientationHorizontal.Name = "MenuFilterVideoOrientationHorizontal";
            this.MenuFilterVideoOrientationHorizontal.Size = new System.Drawing.Size(171, 22);
            this.MenuFilterVideoOrientationHorizontal.Text = "Orizzontale";
            // 
            // MenuFilterVideoOrientationVertical
            // 
            this.MenuFilterVideoOrientationVertical.Name = "MenuFilterVideoOrientationVertical";
            this.MenuFilterVideoOrientationVertical.Size = new System.Drawing.Size(171, 22);
            this.MenuFilterVideoOrientationVertical.Text = "Verticale";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(168, 6);
            // 
            // MenuFilterVideoOrientation0
            // 
            this.MenuFilterVideoOrientation0.Name = "MenuFilterVideoOrientation0";
            this.MenuFilterVideoOrientation0.Size = new System.Drawing.Size(171, 22);
            this.MenuFilterVideoOrientation0.Text = "Nessuna rotazione";
            // 
            // MenuFilterVideoOrientarion90
            // 
            this.MenuFilterVideoOrientarion90.Name = "MenuFilterVideoOrientarion90";
            this.MenuFilterVideoOrientarion90.Size = new System.Drawing.Size(171, 22);
            this.MenuFilterVideoOrientarion90.Text = "Rotazione 90°";
            // 
            // MenuFilterVideoOrientation180
            // 
            this.MenuFilterVideoOrientation180.Name = "MenuFilterVideoOrientation180";
            this.MenuFilterVideoOrientation180.Size = new System.Drawing.Size(171, 22);
            this.MenuFilterVideoOrientation180.Text = "Rotazione 180°";
            // 
            // MenuFilterVideoOrientation270
            // 
            this.MenuFilterVideoOrientation270.Name = "MenuFilterVideoOrientation270";
            this.MenuFilterVideoOrientation270.Size = new System.Drawing.Size(171, 22);
            this.MenuFilterVideoOrientation270.Text = "Rotazione 270°";
            // 
            // MenuFilterVideoGraphic
            // 
            this.MenuFilterVideoGraphic.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFilterVideoGraphicEmulated,
            this.MenuFilterVideoGraphicImperfect,
            this.MenuFilterVideoGraphicUnemulated});
            this.MenuFilterVideoGraphic.Name = "MenuFilterVideoGraphic";
            this.MenuFilterVideoGraphic.Size = new System.Drawing.Size(176, 22);
            this.MenuFilterVideoGraphic.Text = "Emulazione grafica";
            // 
            // MenuFilterVideoGraphicEmulated
            // 
            this.MenuFilterVideoGraphicEmulated.Name = "MenuFilterVideoGraphicEmulated";
            this.MenuFilterVideoGraphicEmulated.Size = new System.Drawing.Size(143, 22);
            this.MenuFilterVideoGraphicEmulated.Text = "Emulata";
            // 
            // MenuFilterVideoGraphicImperfect
            // 
            this.MenuFilterVideoGraphicImperfect.Name = "MenuFilterVideoGraphicImperfect";
            this.MenuFilterVideoGraphicImperfect.Size = new System.Drawing.Size(143, 22);
            this.MenuFilterVideoGraphicImperfect.Text = "Imperfetta";
            // 
            // MenuFilterVideoGraphicUnemulated
            // 
            this.MenuFilterVideoGraphicUnemulated.Name = "MenuFilterVideoGraphicUnemulated";
            this.MenuFilterVideoGraphicUnemulated.Size = new System.Drawing.Size(143, 22);
            this.MenuFilterVideoGraphicUnemulated.Text = "Non emulata";
            // 
            // MenuFilterVideoColor
            // 
            this.MenuFilterVideoColor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFilterVideoColorEmulated,
            this.MenuFilterVideoColorImperfect,
            this.MenuFilterVideoColorUnemulated});
            this.MenuFilterVideoColor.Name = "MenuFilterVideoColor";
            this.MenuFilterVideoColor.Size = new System.Drawing.Size(176, 22);
            this.MenuFilterVideoColor.Text = "Colore";
            // 
            // MenuFilterVideoColorEmulated
            // 
            this.MenuFilterVideoColorEmulated.Name = "MenuFilterVideoColorEmulated";
            this.MenuFilterVideoColorEmulated.Size = new System.Drawing.Size(144, 22);
            this.MenuFilterVideoColorEmulated.Text = "Emulato";
            // 
            // MenuFilterVideoColorImperfect
            // 
            this.MenuFilterVideoColorImperfect.Name = "MenuFilterVideoColorImperfect";
            this.MenuFilterVideoColorImperfect.Size = new System.Drawing.Size(144, 22);
            this.MenuFilterVideoColorImperfect.Text = "Imperfetto";
            // 
            // MenuFilterVideoColorUnemulated
            // 
            this.MenuFilterVideoColorUnemulated.Name = "MenuFilterVideoColorUnemulated";
            this.MenuFilterVideoColorUnemulated.Size = new System.Drawing.Size(144, 22);
            this.MenuFilterVideoColorUnemulated.Text = "Non emulato";
            // 
            // MenuSeparator4
            // 
            this.MenuSeparator4.Name = "MenuSeparator4";
            this.MenuSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // MenuFilterClassifications
            // 
            this.MenuFilterClassifications.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFilterClassificationsGenre,
            this.MenuFilterClassificationsCategories,
            this.MenuFilterClassificationsSerie});
            this.MenuFilterClassifications.Name = "MenuFilterClassifications";
            this.MenuFilterClassifications.Size = new System.Drawing.Size(148, 22);
            this.MenuFilterClassifications.Text = "Classificazioni";
            // 
            // MenuFilterClassificationsGenre
            // 
            this.MenuFilterClassificationsGenre.Enabled = false;
            this.MenuFilterClassificationsGenre.Name = "MenuFilterClassificationsGenre";
            this.MenuFilterClassificationsGenre.Size = new System.Drawing.Size(143, 22);
            this.MenuFilterClassificationsGenre.Text = "Per genere";
            // 
            // MenuFilterClassificationsCategories
            // 
            this.MenuFilterClassificationsCategories.Enabled = false;
            this.MenuFilterClassificationsCategories.Name = "MenuFilterClassificationsCategories";
            this.MenuFilterClassificationsCategories.Size = new System.Drawing.Size(143, 22);
            this.MenuFilterClassificationsCategories.Text = "Per categoria";
            // 
            // MenuFilterClassificationsSerie
            // 
            this.MenuFilterClassificationsSerie.Name = "MenuFilterClassificationsSerie";
            this.MenuFilterClassificationsSerie.Size = new System.Drawing.Size(143, 22);
            this.MenuFilterClassificationsSerie.Text = "Per serie";
            // 
            // MenuFilterSample
            // 
            this.MenuFilterSample.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFilterSampleUsed,
            this.MenuFilterSampleUnused});
            this.MenuFilterSample.Name = "MenuFilterSample";
            this.MenuFilterSample.Size = new System.Drawing.Size(148, 22);
            this.MenuFilterSample.Text = "Sample";
            // 
            // MenuFilterSampleUsed
            // 
            this.MenuFilterSampleUsed.Name = "MenuFilterSampleUsed";
            this.MenuFilterSampleUsed.Size = new System.Drawing.Size(159, 22);
            this.MenuFilterSampleUsed.Text = "Usa sample";
            // 
            // MenuFilterSampleUnused
            // 
            this.MenuFilterSampleUnused.Name = "MenuFilterSampleUnused";
            this.MenuFilterSampleUnused.Size = new System.Drawing.Size(159, 22);
            this.MenuFilterSampleUnused.Text = "Non usa sample";
            // 
            // MenuFilterCHD
            // 
            this.MenuFilterCHD.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFilterCHDRequired,
            this.MenuFilterCHDNotRequired,
            this.MenuSeparator5,
            this.MenuFilterCHDGood,
            this.MenuFilterCHDBadDump,
            this.MenuFilterCHDNoDump});
            this.MenuFilterCHD.Name = "MenuFilterCHD";
            this.MenuFilterCHD.Size = new System.Drawing.Size(148, 22);
            this.MenuFilterCHD.Text = "CHD";
            // 
            // MenuFilterCHDRequired
            // 
            this.MenuFilterCHDRequired.Name = "MenuFilterCHDRequired";
            this.MenuFilterCHDRequired.Size = new System.Drawing.Size(179, 22);
            this.MenuFilterCHDRequired.Text = "Richiede CHD";
            // 
            // MenuFilterCHDNotRequired
            // 
            this.MenuFilterCHDNotRequired.Name = "MenuFilterCHDNotRequired";
            this.MenuFilterCHDNotRequired.Size = new System.Drawing.Size(179, 22);
            this.MenuFilterCHDNotRequired.Text = "Non richiede CHD";
            // 
            // MenuSeparator5
            // 
            this.MenuSeparator5.Name = "MenuSeparator5";
            this.MenuSeparator5.Size = new System.Drawing.Size(176, 6);
            // 
            // MenuFilterCHDGood
            // 
            this.MenuFilterCHDGood.Name = "MenuFilterCHDGood";
            this.MenuFilterCHDGood.Size = new System.Drawing.Size(179, 22);
            this.MenuFilterCHDGood.Text = "Usa CHD good";
            // 
            // MenuFilterCHDBadDump
            // 
            this.MenuFilterCHDBadDump.Name = "MenuFilterCHDBadDump";
            this.MenuFilterCHDBadDump.Size = new System.Drawing.Size(179, 22);
            this.MenuFilterCHDBadDump.Text = "Usa CHD bad dump";
            // 
            // MenuFilterCHDNoDump
            // 
            this.MenuFilterCHDNoDump.Name = "MenuFilterCHDNoDump";
            this.MenuFilterCHDNoDump.Size = new System.Drawing.Size(179, 22);
            this.MenuFilterCHDNoDump.Text = "Usa CHD no dump";
            // 
            // MenuFilterSaveState
            // 
            this.MenuFilterSaveState.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFilterSaveStateSupported,
            this.MenuFilterSaveStateUnsupported,
            this.MenuFilterSaveStateUnknown});
            this.MenuFilterSaveState.Name = "MenuFilterSaveState";
            this.MenuFilterSaveState.Size = new System.Drawing.Size(148, 22);
            this.MenuFilterSaveState.Text = "Salvataggio";
            // 
            // MenuFilterSaveStateSupported
            // 
            this.MenuFilterSaveStateSupported.Name = "MenuFilterSaveStateSupported";
            this.MenuFilterSaveStateSupported.Size = new System.Drawing.Size(158, 22);
            this.MenuFilterSaveStateSupported.Text = "Supportato";
            // 
            // MenuFilterSaveStateUnsupported
            // 
            this.MenuFilterSaveStateUnsupported.Name = "MenuFilterSaveStateUnsupported";
            this.MenuFilterSaveStateUnsupported.Size = new System.Drawing.Size(158, 22);
            this.MenuFilterSaveStateUnsupported.Text = "Non supportato";
            // 
            // MenuFilterSaveStateUnknown
            // 
            this.MenuFilterSaveStateUnknown.Name = "MenuFilterSaveStateUnknown";
            this.MenuFilterSaveStateUnknown.Size = new System.Drawing.Size(158, 22);
            this.MenuFilterSaveStateUnknown.Text = "Sconosciuto";
            // 
            // MenuFilterRelease
            // 
            this.MenuFilterRelease.Enabled = false;
            this.MenuFilterRelease.Name = "MenuFilterRelease";
            this.MenuFilterRelease.Size = new System.Drawing.Size(148, 22);
            this.MenuFilterRelease.Text = "Versione";
            // 
            // MenuSeparator6
            // 
            this.MenuSeparator6.Name = "MenuSeparator6";
            this.MenuSeparator6.Size = new System.Drawing.Size(145, 6);
            // 
            // MenuFilterDriver
            // 
            this.MenuFilterDriver.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFilterDriverWorking,
            this.MenuFilterDriverImperfect,
            this.MenuFilterDriverNotWorking,
            this.MenuFilterDriverUnknown});
            this.MenuFilterDriver.Name = "MenuFilterDriver";
            this.MenuFilterDriver.Size = new System.Drawing.Size(148, 22);
            this.MenuFilterDriver.Text = "Driver";
            // 
            // MenuFilterDriverWorking
            // 
            this.MenuFilterDriverWorking.Name = "MenuFilterDriverWorking";
            this.MenuFilterDriverWorking.Size = new System.Drawing.Size(191, 22);
            this.MenuFilterDriverWorking.Text = "Stato funzionante";
            // 
            // MenuFilterDriverImperfect
            // 
            this.MenuFilterDriverImperfect.Name = "MenuFilterDriverImperfect";
            this.MenuFilterDriverImperfect.Size = new System.Drawing.Size(191, 22);
            this.MenuFilterDriverImperfect.Text = "Stato imperfetto";
            // 
            // MenuFilterDriverNotWorking
            // 
            this.MenuFilterDriverNotWorking.Name = "MenuFilterDriverNotWorking";
            this.MenuFilterDriverNotWorking.Size = new System.Drawing.Size(191, 22);
            this.MenuFilterDriverNotWorking.Text = "Stato non funzionante";
            // 
            // MenuFilterDriverUnknown
            // 
            this.MenuFilterDriverUnknown.Name = "MenuFilterDriverUnknown";
            this.MenuFilterDriverUnknown.Size = new System.Drawing.Size(191, 22);
            this.MenuFilterDriverUnknown.Text = "Stato sconosciuto";
            // 
            // cocktailToolStripMenuItem
            // 
            this.cocktailToolStripMenuItem.Enabled = false;
            this.cocktailToolStripMenuItem.Name = "cocktailToolStripMenuItem";
            this.cocktailToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.cocktailToolStripMenuItem.Text = "Cocktail";
            // 
            // MenuFilterProtection
            // 
            this.MenuFilterProtection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFilterProtectionEmulated,
            this.MenuFilterProtectionImperfect,
            this.MenuFilterProtectionUnemulated});
            this.MenuFilterProtection.Name = "MenuFilterProtection";
            this.MenuFilterProtection.Size = new System.Drawing.Size(148, 22);
            this.MenuFilterProtection.Text = "Protezione";
            // 
            // MenuFilterProtectionEmulated
            // 
            this.MenuFilterProtectionEmulated.Name = "MenuFilterProtectionEmulated";
            this.MenuFilterProtectionEmulated.Size = new System.Drawing.Size(143, 22);
            this.MenuFilterProtectionEmulated.Text = "Emulata";
            // 
            // MenuFilterProtectionImperfect
            // 
            this.MenuFilterProtectionImperfect.Name = "MenuFilterProtectionImperfect";
            this.MenuFilterProtectionImperfect.Size = new System.Drawing.Size(143, 22);
            this.MenuFilterProtectionImperfect.Text = "Imperfetta";
            // 
            // MenuFilterProtectionUnemulated
            // 
            this.MenuFilterProtectionUnemulated.Name = "MenuFilterProtectionUnemulated";
            this.MenuFilterProtectionUnemulated.Size = new System.Drawing.Size(143, 22);
            this.MenuFilterProtectionUnemulated.Text = "Non emulata";
            // 
            // ToolbarMenuGrid
            // 
            this.ToolbarMenuGrid.AutoSize = false;
            this.ToolbarMenuGrid.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolbarMenuGrid.Enabled = false;
            this.ToolbarMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAddToSelectedGames,
            this.MenuRemoveFromSelectedGames,
            this.MenuToggleSelectedGames,
            this.GridTextFilter,
            this.MenuShow,
            this.MenuColumns});
            this.ToolbarMenuGrid.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ToolbarMenuGrid.Location = new System.Drawing.Point(13, 134);
            this.ToolbarMenuGrid.Name = "ToolbarMenuGrid";
            this.ToolbarMenuGrid.Size = new System.Drawing.Size(635, 27);
            this.ToolbarMenuGrid.TabIndex = 58;
            this.ToolbarMenuGrid.Text = "menuStrip1";
            // 
            // MenuRemoveFromSelectedGames
            // 
            this.MenuRemoveFromSelectedGames.Image = global::MAME_Shrink.Properties.Resources.square;
            this.MenuRemoveFromSelectedGames.Name = "MenuRemoveFromSelectedGames";
            this.MenuRemoveFromSelectedGames.Size = new System.Drawing.Size(97, 23);
            this.MenuRemoveFromSelectedGames.Text = "Deseleziona";
            this.MenuRemoveFromSelectedGames.ToolTipText = "Rimuovi dalla selezione";
            this.MenuRemoveFromSelectedGames.Click += new System.EventHandler(this.MenuRemoveFromSelectedGames_Click);
            // 
            // MenuToggleSelectedGames
            // 
            this.MenuToggleSelectedGames.Image = global::MAME_Shrink.Properties.Resources.true_false;
            this.MenuToggleSelectedGames.Name = "MenuToggleSelectedGames";
            this.MenuToggleSelectedGames.Size = new System.Drawing.Size(68, 23);
            this.MenuToggleSelectedGames.Text = "Inverti";
            this.MenuToggleSelectedGames.ToolTipText = "Inverti la selezione";
            this.MenuToggleSelectedGames.Click += new System.EventHandler(this.MenuToggleSelectedGames_Click);
            // 
            // GridTextFilter
            // 
            this.GridTextFilter.AutoSize = false;
            this.GridTextFilter.MaxLength = 100;
            this.GridTextFilter.Name = "GridTextFilter";
            this.GridTextFilter.Size = new System.Drawing.Size(100, 23);
            this.GridTextFilter.ToolTipText = "Filtro griglia";
            this.GridTextFilter.TextChanged += new System.EventHandler(this.GridTextFilter_TextChanged);
            // 
            // MenuShow
            // 
            this.MenuShow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuShowAllGames,
            this.MenuShowExistingFiles,
            this.MenuShowSelectedGames,
            this.MenuShowNotSelectedGames});
            this.MenuShow.Image = global::MAME_Shrink.Properties.Resources.folder;
            this.MenuShow.Name = "MenuShow";
            this.MenuShow.Size = new System.Drawing.Size(72, 23);
            this.MenuShow.Text = "Mostra";
            // 
            // MenuShowAllGames
            // 
            this.MenuShowAllGames.Name = "MenuShowAllGames";
            this.MenuShowAllGames.Size = new System.Drawing.Size(202, 22);
            this.MenuShowAllGames.Tag = "AllGames";
            this.MenuShowAllGames.Text = "Tutti i giochi";
            this.MenuShowAllGames.Click += new System.EventHandler(this.MenuShowType_Click);
            // 
            // MenuShowExistingFiles
            // 
            this.MenuShowExistingFiles.Checked = true;
            this.MenuShowExistingFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuShowExistingFiles.Name = "MenuShowExistingFiles";
            this.MenuShowExistingFiles.Size = new System.Drawing.Size(202, 22);
            this.MenuShowExistingFiles.Tag = "ExistingFiles";
            this.MenuShowExistingFiles.Text = "Solo se presenti su disco";
            this.MenuShowExistingFiles.Click += new System.EventHandler(this.MenuShowType_Click);
            // 
            // MenuShowSelectedGames
            // 
            this.MenuShowSelectedGames.Name = "MenuShowSelectedGames";
            this.MenuShowSelectedGames.Size = new System.Drawing.Size(202, 22);
            this.MenuShowSelectedGames.Tag = "Selected";
            this.MenuShowSelectedGames.Text = "Solo selezionati";
            this.MenuShowSelectedGames.Click += new System.EventHandler(this.MenuShowType_Click);
            // 
            // MenuShowNotSelectedGames
            // 
            this.MenuShowNotSelectedGames.Name = "MenuShowNotSelectedGames";
            this.MenuShowNotSelectedGames.Size = new System.Drawing.Size(202, 22);
            this.MenuShowNotSelectedGames.Tag = "NotSelected";
            this.MenuShowNotSelectedGames.Text = "Solo non selezionati";
            this.MenuShowNotSelectedGames.Click += new System.EventHandler(this.MenuShowType_Click);
            // 
            // MenuColumns
            // 
            this.MenuColumns.Image = global::MAME_Shrink.Properties.Resources.columns;
            this.MenuColumns.Name = "MenuColumns";
            this.MenuColumns.Size = new System.Drawing.Size(80, 23);
            this.MenuColumns.Text = "Colonne";
            this.MenuColumns.Click += new System.EventHandler(this.MenuColumns_Click);
            // 
            // SelectedRomsetName
            // 
            this.SelectedRomsetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedRomsetName.Location = new System.Drawing.Point(654, 140);
            this.SelectedRomsetName.Name = "SelectedRomsetName";
            this.SelectedRomsetName.Size = new System.Drawing.Size(164, 19);
            this.SelectedRomsetName.TabIndex = 59;
            this.SelectedRomsetName.Text = "Romset";
            this.SelectedRomsetName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.SelectedRomsetName.Visible = false;
            // 
            // pnlRomset
            // 
            this.pnlRomset.Controls.Add(this.KeyValueRomset);
            this.pnlRomset.Location = new System.Drawing.Point(653, 359);
            this.pnlRomset.Name = "pnlRomset";
            this.pnlRomset.Size = new System.Drawing.Size(259, 236);
            this.pnlRomset.TabIndex = 61;
            this.pnlRomset.Visible = false;
            // 
            // KeyValueRomset
            // 
            this.KeyValueRomset.AutoSize = true;
            this.KeyValueRomset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.KeyValueRomset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeyValueRomset.Location = new System.Drawing.Point(0, 0);
            this.KeyValueRomset.Name = "KeyValueRomset";
            this.KeyValueRomset.Size = new System.Drawing.Size(259, 236);
            this.KeyValueRomset.TabIndex = 63;
            // 
            // OpenRomsetWebPage
            // 
            this.OpenRomsetWebPage.Location = new System.Drawing.Point(826, 139);
            this.OpenRomsetWebPage.Name = "OpenRomsetWebPage";
            this.OpenRomsetWebPage.Size = new System.Drawing.Size(78, 20);
            this.OpenRomsetWebPage.TabIndex = 61;
            this.OpenRomsetWebPage.TabStop = true;
            this.OpenRomsetWebPage.Text = "Mostra sul sito";
            this.OpenRomsetWebPage.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.OpenRomsetWebPage.Visible = false;
            this.OpenRomsetWebPage.Click += new System.EventHandler(this.OpenRomsetWebPage_Click);
            // 
            // ValidateRomset
            // 
            this.ValidateRomset.Checked = true;
            this.ValidateRomset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ValidateRomset.Location = new System.Drawing.Point(410, 76);
            this.ValidateRomset.Name = "ValidateRomset";
            this.ValidateRomset.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ValidateRomset.Size = new System.Drawing.Size(134, 24);
            this.ValidateRomset.TabIndex = 63;
            this.ValidateRomset.Text = "Verifica dipendenze";
            this.ValidateRomset.UseVisualStyleBackColor = true;
            this.ValidateRomset.Visible = false;
            // 
            // SnapshotPlaceholder
            // 
            this.SnapshotPlaceholder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SnapshotPlaceholder.Image = global::MAME_Shrink.Properties.Resources.ingame_placeholder;
            this.SnapshotPlaceholder.Location = new System.Drawing.Point(715, 10);
            this.SnapshotPlaceholder.Name = "SnapshotPlaceholder";
            this.SnapshotPlaceholder.Size = new System.Drawing.Size(49, 38);
            this.SnapshotPlaceholder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SnapshotPlaceholder.TabIndex = 60;
            this.SnapshotPlaceholder.TabStop = false;
            this.SnapshotPlaceholder.Visible = false;
            // 
            // MenuAddToSelectedGames
            // 
            this.MenuAddToSelectedGames.Image = global::MAME_Shrink.Properties.Resources.check;
            this.MenuAddToSelectedGames.Name = "MenuAddToSelectedGames";
            this.MenuAddToSelectedGames.Size = new System.Drawing.Size(84, 23);
            this.MenuAddToSelectedGames.Text = "Seleziona";
            this.MenuAddToSelectedGames.ToolTipText = "Aggiungi alla selezione";
            this.MenuAddToSelectedGames.Click += new System.EventHandler(this.MenuAddToSelectedGames_Click);
            // 
            // StartClean
            // 
            this.StartClean.ImageKey = "waste";
            this.StartClean.ImageList = this.ImageList;
            this.StartClean.Location = new System.Drawing.Point(554, 71);
            this.StartClean.Name = "StartClean";
            this.StartClean.Size = new System.Drawing.Size(94, 32);
            this.StartClean.TabIndex = 51;
            this.StartClean.Text = "Pulisci";
            this.StartClean.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.StartClean.Visible = false;
            this.StartClean.Click += new System.EventHandler(this.StartClean_Click);
            // 
            // ChangeOptions
            // 
            this.ChangeOptions.ImageKey = "options";
            this.ChangeOptions.ImageList = this.ImageList;
            this.ChangeOptions.Location = new System.Drawing.Point(125, 71);
            this.ChangeOptions.Name = "ChangeOptions";
            this.ChangeOptions.Size = new System.Drawing.Size(129, 32);
            this.ChangeOptions.TabIndex = 50;
            this.ChangeOptions.Text = "Opzioni e percorsi";
            this.ChangeOptions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ChangeOptions.Click += new System.EventHandler(this.ChangeOptions_Click);
            // 
            // Snapshot
            // 
            this.Snapshot.Image = global::MAME_Shrink.Properties.Resources.ingame_placeholder;
            this.Snapshot.Location = new System.Drawing.Point(653, 164);
            this.Snapshot.Name = "Snapshot";
            this.Snapshot.Size = new System.Drawing.Size(259, 189);
            this.Snapshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Snapshot.TabIndex = 5;
            this.Snapshot.TabStop = false;
            // 
            // LoadGames
            // 
            this.LoadGames.ImageKey = "right";
            this.LoadGames.ImageList = this.ImageList;
            this.LoadGames.Location = new System.Drawing.Point(260, 71);
            this.LoadGames.Name = "LoadGames";
            this.LoadGames.Size = new System.Drawing.Size(121, 32);
            this.LoadGames.TabIndex = 4;
            this.LoadGames.Text = "Carica lista";
            this.LoadGames.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.LoadGames.Click += new System.EventHandler(this.LoadGames_Click);
            // 
            // CancelCurrentProcess
            // 
            this.CancelCurrentProcess.ImageKey = "cancel-red";
            this.CancelCurrentProcess.ImageList = this.ImageList;
            this.CancelCurrentProcess.Location = new System.Drawing.Point(260, 71);
            this.CancelCurrentProcess.Name = "CancelCurrentProcess";
            this.CancelCurrentProcess.Size = new System.Drawing.Size(121, 32);
            this.CancelCurrentProcess.TabIndex = 51;
            this.CancelCurrentProcess.Text = "Interrompi";
            this.CancelCurrentProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelCurrentProcess.Visible = false;
            this.CancelCurrentProcess.Click += new System.EventHandler(this.CancelCurrentProcess_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 607);
            this.Controls.Add(this.ValidateRomset);
            this.Controls.Add(this.SelectedRomsetName);
            this.Controls.Add(this.OpenRomsetWebPage);
            this.Controls.Add(this.pnlRomset);
            this.Controls.Add(this.SnapshotPlaceholder);
            this.Controls.Add(this.ToolbarMenuGrid);
            this.Controls.Add(this.StartClean);
            this.Controls.Add(this.ChangeOptions);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.Snapshot);
            this.Controls.Add(this.LabelRomsPath);
            this.Controls.Add(this.LabelGamelistXml);
            this.Controls.Add(this.LabelManueExe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GamesListView);
            this.Controls.Add(this.LoadGames);
            this.Controls.Add(this.CancelCurrentProcess);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ToolbarMenuGrid;
            this.MinimumSize = new System.Drawing.Size(630, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MAME Shrink";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.MenuColumnItems.ResumeLayout(false);
            this.MenuFilters.ResumeLayout(false);
            this.ToolbarMenuGrid.ResumeLayout(false);
            this.ToolbarMenuGrid.PerformLayout();
            this.pnlRomset.ResumeLayout(false);
            this.pnlRomset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SnapshotPlaceholder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Snapshot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoadGames;
        private System.Windows.Forms.ListView GamesListView;
        private System.Windows.Forms.PictureBox Snapshot;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Timer GridTextFilterTimer;
        private System.Windows.Forms.ToolTip Tooltips;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LabelManueExe;
        private System.Windows.Forms.Label LabelGamelistXml;
        private System.Windows.Forms.Label LabelRomsPath;
        private System.Windows.Forms.Button ChangeOptions;
        private System.Windows.Forms.Button CancelCurrentProcess;
        private System.Windows.Forms.ContextMenuStrip MenuColumnItems;
        private System.Windows.Forms.ToolStripMenuItem toolStripColumnYear;
        private System.Windows.Forms.ToolStripMenuItem toolStripColumnRomset;
        private System.Windows.Forms.ToolStripMenuItem toolStripColumnManufacturer;
        private System.Windows.Forms.ToolStripMenuItem toolStripColumnCloneOf;
        private System.Windows.Forms.ToolStripMenuItem toolStripColumnDriverStatus;
        private System.Windows.Forms.ToolStripMenuItem toolStripColumnGenre;
        private System.Windows.Forms.ToolStripMenuItem toolStripColumnRelease;
        private System.Windows.Forms.ToolStripMenuItem toolStripColumnPlayers;
        private System.Windows.Forms.ToolStripMenuItem toolStripColumnButtons;
        private System.Windows.Forms.ToolStripMenuItem toolStripColumnDisplay;
        private System.Windows.Forms.ContextMenuStrip MenuFilters;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterAll;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterType;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterTypeParent;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterTypeClone;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterDriver;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterDriverWorking;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterDriverNotWorking;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterDriverImperfect;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterSample;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterSampleUsed;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterSampleUnused;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterCHD;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterCHDRequired;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterCHDBadDump;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterCHDNotRequired;
        private System.Windows.Forms.ToolStripSeparator MenuSeparator5;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterCHDNoDump;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterCHDGood;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterAudio;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterAudioMono;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterAudioStereo;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterAudioMultiChannel;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterAudioUnsupported;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterSaveState;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterSaveStateSupported;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterSaveStateUnsupported;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterSaveStateUnknown;
        private System.Windows.Forms.ToolStripSeparator MenuSeparator6;
        private System.Windows.Forms.ToolStripMenuItem cocktailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterProtection;
        private System.Windows.Forms.ToolStripSeparator MenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterTypeGame;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterTypeBios;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterTypeDevice;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterTypeMechanical;
        private System.Windows.Forms.MenuStrip ToolbarMenuGrid;
        private System.Windows.Forms.ToolStripMenuItem MenuShow;
        private System.Windows.Forms.ToolStripMenuItem MenuShowAllGames;
        private System.Windows.Forms.ToolStripMenuItem MenuShowExistingFiles;
        private System.Windows.Forms.ToolStripMenuItem MenuShowSelectedGames;
        private System.Windows.Forms.ToolStripMenuItem MenuShowNotSelectedGames;
        private System.Windows.Forms.ToolStripMenuItem MenuAddToSelectedGames;
        private System.Windows.Forms.ToolStripMenuItem MenuRemoveFromSelectedGames;
        private System.Windows.Forms.ToolStripMenuItem MenuToggleSelectedGames;
        private System.Windows.Forms.ToolStripTextBox GridTextFilter;
        private System.Windows.Forms.ToolStripMenuItem MenuColumns;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterTypeMamecab;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.Button StartClean;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterProtectionEmulated;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterProtectionImperfect;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterProtectionUnemulated;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterClassifications;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterClassificationsGenre;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterClassificationsCategories;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideo;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoType;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoTypeRaster;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoTypeVector;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoTypeLCD;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoTypeSVG;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoTypeUnknown;
        private System.Windows.Forms.ToolStripSeparator MenuSeparator4;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterRelease;
        private System.Windows.Forms.ToolStripSeparator MenuSeparator3;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterAudioEmulated;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterAudioImperfect;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterAudioUnemulated;
        private System.Windows.Forms.ToolStripSeparator MenuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoScreens;
        private System.Windows.Forms.ToolStripMenuItem MenuVideoOrientation;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoGraphic;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterDriverUnknown;
        private System.Windows.Forms.Label SelectedRomsetName;
        private System.Windows.Forms.PictureBox SnapshotPlaceholder;
        private System.Windows.Forms.Panel pnlRomset;
        private System.Windows.Forms.LinkLabel OpenRomsetWebPage;
        private Components.KeyValueTable KeyValueRomset;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoScreensNone;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoScreensOne;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoScreensOneOrMore;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoScreensTwo;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoScreensTwoOrMore;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoScreensThree;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoScreensThreeOrMore;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoScreensFour;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoScreensFourOrMore;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoScreensFiveOrMore;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoOrientationHorizontal;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoOrientationVertical;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoOrientation0;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoOrientarion90;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoOrientation180;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoOrientation270;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoGraphicEmulated;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoGraphicImperfect;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoGraphicUnemulated;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterClassificationsSerie;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoColor;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoColorEmulated;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoColorImperfect;
        private System.Windows.Forms.ToolStripMenuItem MenuFilterVideoColorUnemulated;
        private System.Windows.Forms.CheckBox ValidateRomset;
    }
}

