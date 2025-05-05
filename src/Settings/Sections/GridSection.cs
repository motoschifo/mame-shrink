#nullable enable
using System.Collections.Generic;

namespace MAME_Shrink.Settings;

public partial class UserPreferences
{
    public class GridSection
    {
        public List<GridColumnDefinition> Columns { get; set; } = [];
    }
}
