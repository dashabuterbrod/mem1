using System.Collections.ObjectModel;

namespace mem1;

public static class MemeStorage
{
    // ObservableCollection автоматически обновл€ет интерфейс (список на экране), 
    // когда в него добавл€ютс€ элементы
    public static ObservableCollection<string> SavedMemes { get; set; } = new ObservableCollection<string>();
}