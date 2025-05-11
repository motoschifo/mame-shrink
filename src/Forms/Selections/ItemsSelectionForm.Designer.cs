namespace MAME_Shrink.Forms.Selections;

partial class ItemsSelectionForm
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
            this.ConfirmSelection = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ValueList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // ConfirmSelection
            // 
            this.ConfirmSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ConfirmSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ConfirmSelection.Image = global::MAME_Shrink.Properties.Resources.confirm;
            this.ConfirmSelection.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConfirmSelection.Location = new System.Drawing.Point(103, 351);
            this.ConfirmSelection.Name = "ConfirmSelection";
            this.ConfirmSelection.Size = new System.Drawing.Size(111, 35);
            this.ConfirmSelection.TabIndex = 4;
            this.ConfirmSelection.Text = "Conferma";
            this.ConfirmSelection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ConfirmSelection.UseVisualStyleBackColor = true;
            this.ConfirmSelection.Click += new System.EventHandler(this.ConfirmSelection_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "Please select one or more items from the list below";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ValueList
            // 
            this.ValueList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueList.CheckOnClick = true;
            this.ValueList.FormattingEnabled = true;
            this.ValueList.Location = new System.Drawing.Point(15, 39);
            this.ValueList.Name = "ValueList";
            this.ValueList.Size = new System.Drawing.Size(290, 304);
            this.ValueList.TabIndex = 6;
            // 
            // ItemsSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 395);
            this.Controls.Add(this.ValueList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConfirmSelection);
            this.MinimizeBox = false;
            this.Name = "ItemsSelectionForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Items selection";
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button ConfirmSelection;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckedListBox ValueList;
}