#nullable enable
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MAME_Shrink.Resources;
using MAME_Shrink.Utilities;

namespace MAME_Shrink.Forms.Selections;
public partial class ItemsSelectionForm : Form
{
    private readonly List<SelectionListItem> _items = [];
    private List<string> _selectedCodes = [];

    public ItemsSelectionForm()
    {
        InitializeComponent();
    }

    public ItemsSelectionForm(List<SelectionListItem> values)
    {
        InitializeComponent();
        _items = values;
        foreach (var item in _items)
        {
            ValueList.Items.Add(item, item.IsSelected);
        }
    }

    public List<string> GetSelectedCodes() => _selectedCodes;

    private void ConfirmSelection_Click(object sender, System.EventArgs e)
    {
        _selectedCodes = [.. ValueList
            .CheckedItems
            .Cast<SelectionListItem>()
            .Select(i => i.Code ?? string.Empty)];
        if (_selectedCodes.Count == 0)
        {
            Dialogs.ShowErrorDialog(Strings.NoGameSelected);
            return;
        }
        DialogResult = DialogResult.OK;
    }
}
