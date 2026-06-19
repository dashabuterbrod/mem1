using System.Collections.ObjectModel;

namespace mem1;

public class UserMeme
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string TemplatePath { get; set; }
    public string MemeText { get; set; }
    public bool HasText => !string.IsNullOrWhiteSpace(MemeText);
}

public static class CustomMemeStorage
{
    public static ObservableCollection<UserMeme> CreatedMemes { get; set; } = new ObservableCollection<UserMeme>();
}