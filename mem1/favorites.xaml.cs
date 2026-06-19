namespace mem1;

public partial class Favorites : ContentPage
{
    public Favorites()
    {
        InitializeComponent();
        // Это обращение сработает ТОЛЬКО если x:Name в XAML совпадает с этим именем
        FavoritesCollectionView.ItemsSource = MemeService.SavedMemes;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}