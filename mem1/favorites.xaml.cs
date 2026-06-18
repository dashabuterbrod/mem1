using System.Collections.ObjectModel;

namespace mem1;

public partial class Favorites : ContentPage
{
    public Favorites()
    {
        InitializeComponent();
        FavoritesCollectionView.ItemsSource = MemeService.SavedMemes;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}