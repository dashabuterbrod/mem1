namespace mem1;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        // Обновляем только счетчик, текст кнопки не трогаем
        CountLabel.Text = $"Сгенерировано мемов: {count}";
    }
}