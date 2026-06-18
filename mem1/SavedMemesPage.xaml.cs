namespace mem1;

public partial class SavedMemesPage : ContentPage
{
    public SavedMemesPage()
    {
        InitializeComponent();
<<<<<<< HEAD
        MemesCollectionView.ItemsSource = MemeService.SavedMemes;
=======
    }

    // Метод срабатывает каждый раз, когда пользователь открывает эту вкладку
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Подтягиваем актуальный список мемов из хранилища
        MemesCollectionView.ItemsSource = MemeStorage.SavedMemes;
>>>>>>> d5b2062ea394e8ad12c2c47b54dca36a030fefae
    }
}