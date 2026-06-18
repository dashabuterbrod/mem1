namespace mem1;

public partial class SavedMemesPage : ContentPage
{
    public SavedMemesPage()
    {
        InitializeComponent();
        MemesCollectionView.ItemsSource = MemeService.SavedMemes;
    }
}