using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.ObjectModel;

namespace mem1;

public static class MemeService
{
    public static ObservableCollection<string> SavedMemes { get; } = new ObservableCollection<string>();
}