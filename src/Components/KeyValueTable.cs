#nullable enable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MAME_Shrink.Components;

public partial class KeyValueTable : UserControl
{
    private readonly TableLayoutPanel _table;
    private readonly FlowLayoutPanel _flowControl;

    public KeyValueTable()
    {
        _flowControl = new FlowLayoutPanel
        {
            AutoScroll = true,
            FlowDirection = FlowDirection.TopDown,
            Location = new Point(0, 0),
            Name = "flowRomset",
            Size = new Size(258, 231),
            TabIndex = 62,
            WrapContents = false,
            Dock = DockStyle.Fill
        };
        _flowControl.HorizontalScroll.Visible = false;
        _flowControl.HorizontalScroll.Enabled = false;

        _table = new TableLayoutPanel
        {
            ColumnCount = 2,
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink,
            Dock = DockStyle.Top,
            CellBorderStyle = TableLayoutPanelCellBorderStyle.None
        };

        _table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        _table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        _flowControl.Controls.Add(_table);
        Controls.Add(_flowControl);
        Resize += new EventHandler(UserControl_Resize);
    }

    public void SetData(Dictionary<string, string?> data)
    {
        _table.Controls.Clear();

        foreach (var kvp in data)
        {
            var caption = new Label
            {
                Text = kvp.Key,
                AutoSize = false,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                TextAlign = ContentAlignment.TopRight,
                Padding = new Padding(0),
                Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold),
                Margin = new Padding(0),
                Width = 80
            };

            var value = new Label
            {
                Text = string.IsNullOrWhiteSpace(kvp.Value) ? "-" : kvp.Value,
                AutoSize = true,
                MaximumSize = new Size(ClientSize.Width, 0),
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
                TextAlign = ContentAlignment.TopLeft,
                Margin = new Padding(0)
            };

            _table.Controls.Add(caption);
            _table.Controls.Add(value);
        }

        PerformLayout();
    }

    private void UserControl_Resize(object sender, EventArgs e)
    {
        if (_flowControl.Controls.Count > 0 && _flowControl.Controls[0] is TableLayoutPanel tbl)
        {
            tbl.Width = _flowControl.ClientSize.Width - 20;
        }
    }

}

