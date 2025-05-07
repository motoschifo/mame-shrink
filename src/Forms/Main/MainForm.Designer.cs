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
            this.ToolbarMenuGrid = new System.Windows.Forms.MenuStrip();
            this.GridTextFilter = new System.Windows.Forms.ToolStripTextBox();
            this.SelectedRomsetName = new System.Windows.Forms.Label();
            this.pnlRomset = new System.Windows.Forms.Panel();
            this.OpenRomsetWebPage = new System.Windows.Forms.LinkLabel();
            this.ValidateRomset = new System.Windows.Forms.CheckBox();
            this.SnapshotPlaceholder = new System.Windows.Forms.PictureBox();
            this.MenuAddToSelectedGames = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRemoveFromSelectedGames = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToggleSelectedGames = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuShowAllGames = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuShowExistingFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuShowSelectedGames = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuShowNotSelectedGames = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.StartClean = new System.Windows.Forms.Button();
            this.ChangeOptions = new System.Windows.Forms.Button();
            this.Snapshot = new System.Windows.Forms.PictureBox();
            this.LoadGames = new System.Windows.Forms.Button();
            this.CancelCurrentProcess = new System.Windows.Forms.Button();
            this.KeyValueRomset = new MAME_Shrink.Components.KeyValueTable();
            this.MenuColumnItems.SuspendLayout();
            this.ToolbarMenuGrid.SuspendLayout();
            this.pnlRomset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SnapshotPlaceholder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Snapshot)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            resources.ApplyResources(this.GamesListView, "GamesListView");
            this.GamesListView.CheckBoxes = true;
            this.GamesListView.HideSelection = false;
            this.GamesListView.Name = "GamesListView";
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
            resources.ApplyResources(this.lblInfo, "lblInfo");
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.UseMnemonic = false;
            // 
            // GridTextFilterTimer
            // 
            this.GridTextFilterTimer.Interval = 500;
            this.GridTextFilterTimer.Tick += new System.EventHandler(this.GridTextFilterTimer_Tick);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // LabelManueExe
            // 
            resources.ApplyResources(this.LabelManueExe, "LabelManueExe");
            this.LabelManueExe.Name = "LabelManueExe";
            // 
            // LabelGamelistXml
            // 
            resources.ApplyResources(this.LabelGamelistXml, "LabelGamelistXml");
            this.LabelGamelistXml.Name = "LabelGamelistXml";
            // 
            // LabelRomsPath
            // 
            resources.ApplyResources(this.LabelRomsPath, "LabelRomsPath");
            this.LabelRomsPath.Name = "LabelRomsPath";
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
            resources.ApplyResources(this.MenuColumnItems, "MenuColumnItems");
            // 
            // toolStripColumnRomset
            // 
            this.toolStripColumnRomset.Checked = true;
            this.toolStripColumnRomset.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.toolStripColumnRomset, "toolStripColumnRomset");
            this.toolStripColumnRomset.Name = "toolStripColumnRomset";
            // 
            // toolStripColumnYear
            // 
            this.toolStripColumnYear.Checked = true;
            this.toolStripColumnYear.CheckOnClick = true;
            this.toolStripColumnYear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripColumnYear.Name = "toolStripColumnYear";
            resources.ApplyResources(this.toolStripColumnYear, "toolStripColumnYear");
            // 
            // toolStripColumnManufacturer
            // 
            this.toolStripColumnManufacturer.Checked = true;
            this.toolStripColumnManufacturer.CheckOnClick = true;
            this.toolStripColumnManufacturer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripColumnManufacturer.Name = "toolStripColumnManufacturer";
            resources.ApplyResources(this.toolStripColumnManufacturer, "toolStripColumnManufacturer");
            // 
            // toolStripColumnCloneOf
            // 
            this.toolStripColumnCloneOf.Checked = true;
            this.toolStripColumnCloneOf.CheckOnClick = true;
            this.toolStripColumnCloneOf.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripColumnCloneOf.Name = "toolStripColumnCloneOf";
            resources.ApplyResources(this.toolStripColumnCloneOf, "toolStripColumnCloneOf");
            // 
            // toolStripColumnDriverStatus
            // 
            this.toolStripColumnDriverStatus.Checked = true;
            this.toolStripColumnDriverStatus.CheckOnClick = true;
            this.toolStripColumnDriverStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripColumnDriverStatus.Name = "toolStripColumnDriverStatus";
            resources.ApplyResources(this.toolStripColumnDriverStatus, "toolStripColumnDriverStatus");
            // 
            // toolStripColumnGenre
            // 
            this.toolStripColumnGenre.Checked = true;
            this.toolStripColumnGenre.CheckOnClick = true;
            this.toolStripColumnGenre.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripColumnGenre.Name = "toolStripColumnGenre";
            resources.ApplyResources(this.toolStripColumnGenre, "toolStripColumnGenre");
            // 
            // toolStripColumnRelease
            // 
            this.toolStripColumnRelease.Checked = true;
            this.toolStripColumnRelease.CheckOnClick = true;
            this.toolStripColumnRelease.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripColumnRelease.Name = "toolStripColumnRelease";
            resources.ApplyResources(this.toolStripColumnRelease, "toolStripColumnRelease");
            // 
            // toolStripColumnPlayers
            // 
            this.toolStripColumnPlayers.Checked = true;
            this.toolStripColumnPlayers.CheckOnClick = true;
            this.toolStripColumnPlayers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripColumnPlayers.Name = "toolStripColumnPlayers";
            resources.ApplyResources(this.toolStripColumnPlayers, "toolStripColumnPlayers");
            // 
            // toolStripColumnButtons
            // 
            this.toolStripColumnButtons.Checked = true;
            this.toolStripColumnButtons.CheckOnClick = true;
            this.toolStripColumnButtons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripColumnButtons.Name = "toolStripColumnButtons";
            resources.ApplyResources(this.toolStripColumnButtons, "toolStripColumnButtons");
            // 
            // toolStripColumnDisplay
            // 
            this.toolStripColumnDisplay.Checked = true;
            this.toolStripColumnDisplay.CheckOnClick = true;
            this.toolStripColumnDisplay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripColumnDisplay.DoubleClickEnabled = true;
            this.toolStripColumnDisplay.Name = "toolStripColumnDisplay";
            resources.ApplyResources(this.toolStripColumnDisplay, "toolStripColumnDisplay");
            // 
            // MenuFilters
            // 
            this.MenuFilters.Name = "menuFilters";
            resources.ApplyResources(this.MenuFilters, "MenuFilters");
            // 
            // ToolbarMenuGrid
            // 
            resources.ApplyResources(this.ToolbarMenuGrid, "ToolbarMenuGrid");
            this.ToolbarMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAddToSelectedGames,
            this.MenuRemoveFromSelectedGames,
            this.MenuToggleSelectedGames,
            this.GridTextFilter,
            this.MenuShow,
            this.MenuColumns});
            this.ToolbarMenuGrid.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ToolbarMenuGrid.Name = "ToolbarMenuGrid";
            // 
            // GridTextFilter
            // 
            resources.ApplyResources(this.GridTextFilter, "GridTextFilter");
            this.GridTextFilter.Name = "GridTextFilter";
            this.GridTextFilter.TextChanged += new System.EventHandler(this.GridTextFilter_TextChanged);
            // 
            // SelectedRomsetName
            // 
            resources.ApplyResources(this.SelectedRomsetName, "SelectedRomsetName");
            this.SelectedRomsetName.Name = "SelectedRomsetName";
            // 
            // pnlRomset
            // 
            resources.ApplyResources(this.pnlRomset, "pnlRomset");
            this.pnlRomset.Controls.Add(this.KeyValueRomset);
            this.pnlRomset.Name = "pnlRomset";
            // 
            // OpenRomsetWebPage
            // 
            resources.ApplyResources(this.OpenRomsetWebPage, "OpenRomsetWebPage");
            this.OpenRomsetWebPage.Name = "OpenRomsetWebPage";
            this.OpenRomsetWebPage.TabStop = true;
            this.OpenRomsetWebPage.Click += new System.EventHandler(this.OpenRomsetWebPage_Click);
            // 
            // ValidateRomset
            // 
            this.ValidateRomset.Checked = true;
            this.ValidateRomset.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.ValidateRomset, "ValidateRomset");
            this.ValidateRomset.Name = "ValidateRomset";
            this.ValidateRomset.UseVisualStyleBackColor = true;
            // 
            // SnapshotPlaceholder
            // 
            this.SnapshotPlaceholder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SnapshotPlaceholder.Image = global::MAME_Shrink.Properties.Resources.ingame_placeholder;
            resources.ApplyResources(this.SnapshotPlaceholder, "SnapshotPlaceholder");
            this.SnapshotPlaceholder.Name = "SnapshotPlaceholder";
            this.SnapshotPlaceholder.TabStop = false;
            // 
            // MenuAddToSelectedGames
            // 
            this.MenuAddToSelectedGames.Image = global::MAME_Shrink.Properties.Resources.check;
            this.MenuAddToSelectedGames.Name = "MenuAddToSelectedGames";
            resources.ApplyResources(this.MenuAddToSelectedGames, "MenuAddToSelectedGames");
            this.MenuAddToSelectedGames.Click += new System.EventHandler(this.MenuAddToSelectedGames_Click);
            // 
            // MenuRemoveFromSelectedGames
            // 
            this.MenuRemoveFromSelectedGames.Image = global::MAME_Shrink.Properties.Resources.square;
            this.MenuRemoveFromSelectedGames.Name = "MenuRemoveFromSelectedGames";
            resources.ApplyResources(this.MenuRemoveFromSelectedGames, "MenuRemoveFromSelectedGames");
            this.MenuRemoveFromSelectedGames.Click += new System.EventHandler(this.MenuRemoveFromSelectedGames_Click);
            // 
            // MenuToggleSelectedGames
            // 
            this.MenuToggleSelectedGames.Image = global::MAME_Shrink.Properties.Resources.true_false;
            this.MenuToggleSelectedGames.Name = "MenuToggleSelectedGames";
            resources.ApplyResources(this.MenuToggleSelectedGames, "MenuToggleSelectedGames");
            this.MenuToggleSelectedGames.Click += new System.EventHandler(this.MenuToggleSelectedGames_Click);
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
            resources.ApplyResources(this.MenuShow, "MenuShow");
            // 
            // MenuShowAllGames
            // 
            this.MenuShowAllGames.Name = "MenuShowAllGames";
            resources.ApplyResources(this.MenuShowAllGames, "MenuShowAllGames");
            this.MenuShowAllGames.Tag = "AllGames";
            this.MenuShowAllGames.Click += new System.EventHandler(this.MenuShowType_Click);
            // 
            // MenuShowExistingFiles
            // 
            this.MenuShowExistingFiles.Checked = true;
            this.MenuShowExistingFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuShowExistingFiles.Name = "MenuShowExistingFiles";
            resources.ApplyResources(this.MenuShowExistingFiles, "MenuShowExistingFiles");
            this.MenuShowExistingFiles.Tag = "ExistingFiles";
            this.MenuShowExistingFiles.Click += new System.EventHandler(this.MenuShowType_Click);
            // 
            // MenuShowSelectedGames
            // 
            this.MenuShowSelectedGames.Name = "MenuShowSelectedGames";
            resources.ApplyResources(this.MenuShowSelectedGames, "MenuShowSelectedGames");
            this.MenuShowSelectedGames.Tag = "Selected";
            this.MenuShowSelectedGames.Click += new System.EventHandler(this.MenuShowType_Click);
            // 
            // MenuShowNotSelectedGames
            // 
            this.MenuShowNotSelectedGames.Name = "MenuShowNotSelectedGames";
            resources.ApplyResources(this.MenuShowNotSelectedGames, "MenuShowNotSelectedGames");
            this.MenuShowNotSelectedGames.Tag = "NotSelected";
            this.MenuShowNotSelectedGames.Click += new System.EventHandler(this.MenuShowType_Click);
            // 
            // MenuColumns
            // 
            this.MenuColumns.Image = global::MAME_Shrink.Properties.Resources.columns;
            this.MenuColumns.Name = "MenuColumns";
            resources.ApplyResources(this.MenuColumns, "MenuColumns");
            this.MenuColumns.Click += new System.EventHandler(this.MenuColumns_Click);
            // 
            // StartClean
            // 
            resources.ApplyResources(this.StartClean, "StartClean");
            this.StartClean.ImageList = this.ImageList;
            this.StartClean.Name = "StartClean";
            this.StartClean.Click += new System.EventHandler(this.StartClean_Click);
            // 
            // ChangeOptions
            // 
            resources.ApplyResources(this.ChangeOptions, "ChangeOptions");
            this.ChangeOptions.ImageList = this.ImageList;
            this.ChangeOptions.Name = "ChangeOptions";
            this.ChangeOptions.Click += new System.EventHandler(this.ChangeOptions_Click);
            // 
            // Snapshot
            // 
            resources.ApplyResources(this.Snapshot, "Snapshot");
            this.Snapshot.Image = global::MAME_Shrink.Properties.Resources.ingame_placeholder;
            this.Snapshot.Name = "Snapshot";
            this.Snapshot.TabStop = false;
            // 
            // LoadGames
            // 
            resources.ApplyResources(this.LoadGames, "LoadGames");
            this.LoadGames.ImageList = this.ImageList;
            this.LoadGames.Name = "LoadGames";
            this.LoadGames.Click += new System.EventHandler(this.LoadGames_Click);
            // 
            // CancelCurrentProcess
            // 
            resources.ApplyResources(this.CancelCurrentProcess, "CancelCurrentProcess");
            this.CancelCurrentProcess.ImageList = this.ImageList;
            this.CancelCurrentProcess.Name = "CancelCurrentProcess";
            this.CancelCurrentProcess.Click += new System.EventHandler(this.CancelCurrentProcess_Click);
            // 
            // KeyValueRomset
            // 
            resources.ApplyResources(this.KeyValueRomset, "KeyValueRomset");
            this.KeyValueRomset.Name = "KeyValueRomset";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.MainMenuStrip = this.ToolbarMenuGrid;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.MenuColumnItems.ResumeLayout(false);
            this.ToolbarMenuGrid.ResumeLayout(false);
            this.ToolbarMenuGrid.PerformLayout();
            this.pnlRomset.ResumeLayout(false);
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
        private System.Windows.Forms.Button StartClean;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.Label SelectedRomsetName;
        private System.Windows.Forms.PictureBox SnapshotPlaceholder;
        private System.Windows.Forms.Panel pnlRomset;
        private System.Windows.Forms.LinkLabel OpenRomsetWebPage;
        private System.Windows.Forms.CheckBox ValidateRomset;
        private Components.KeyValueTable KeyValueRomset;
    }
}

