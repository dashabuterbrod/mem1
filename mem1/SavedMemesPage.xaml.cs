namespace mem1;

public partial class SavedMemesPage : ContentPage
{
    public SavedMemesPage()
    {
        InitializeComponent();
        MemesCollectionView.ItemsSource = MemeService.SavedMemes;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        MemesCollectionView.ItemsSource = MemeStorage.SavedMemes;
    }
}