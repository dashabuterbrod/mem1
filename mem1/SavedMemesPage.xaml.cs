namespace mem1;

public partial class SavedMemesPage : ContentPage
{
    public SavedMemesPage()
    {
        InitializeComponent();
    }

    // Метод срабатывает каждый раз, когда пользователь открывает эту вкладку
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Подтягиваем актуальный список мемов из хранилища
        MemesCollectionView.ItemsSource = MemeStorage.SavedMemes;
    }
}