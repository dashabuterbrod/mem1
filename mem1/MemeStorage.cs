using System.Collections.ObjectModel;
using System.Collections.ObjectModel;
using System.Collections.ObjectModel;


namespace mem1;

public static class MemeStorage
{
    public static ObservableCollection<string> SavedMemes { get; set; } = new ObservableCollection<string>();
}