using System.IO;

namespace mem1;

public partial class CreatedMemesPage : ContentPage
{
    private UserMeme selectedMeme;

    public CreatedMemesPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CreatedMemesCollectionView.ItemsSource = CustomMemeStorage.CreatedMemes;
    }

    // Открытие окна просмотра мема
    private void OnMemeTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is UserMeme meme)
        {
            selectedMeme = meme;
            PopupImage.Source = meme.TemplatePath;
            PopupLabel.Text = meme.MemeText;
            PopupViewer.IsVisible = true; // Показываем оверлей
        }
    }

    private void OnClosePopupClicked(object sender, EventArgs e)
    {
        PopupViewer.IsVisible = false; // Прячем оверлей
    }

    // 100% рабочий и безопасный способ копирования ассета в буфер обмена Windows
    private async void OnCopyPopupMemeClicked(object sender, EventArgs e)
    {
        if (selectedMeme == null) return;

#if WINDOWS
        try
        {
            // Читаем файл встроенными средствами MAUI, которые работают везде
            byte[] bytes;
            using (var stream = await FileSystem.OpenAppPackageFileAsync(selectedMeme.TemplatePath))
            {
                using var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                bytes = memoryStream.ToArray();
            }

            if (bytes == null || bytes.Length == 0)
            {
                throw new Exception("Файл пуст или не смог прочитаться.");
            }

            // Создаем поток Windows для буфера обмена
            var winStream = new Windows.Storage.Streams.InMemoryRandomAccessStream();
            using (var dataWriter = new Windows.Storage.Streams.DataWriter(winStream))
            {
                dataWriter.WriteBytes(bytes);
                await dataWriter.StoreAsync();
                await dataWriter.FlushAsync();
            }

            // Формируем пакет данных для передачи в ОС Windows
            var dataPackage = new Windows.ApplicationModel.DataTransfer.DataPackage();
            dataPackage.SetBitmap(Windows.Storage.Streams.RandomAccessStreamReference.CreateFromStream(winStream));
            
            // Если в редакторе был написан текст, закидываем его вместе с картинкой
            if (selectedMeme.HasText)
            {
                dataPackage.SetText(selectedMeme.MemeText);
            }

            // Отправляем в системный буфер обмена
            Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dataPackage);
            
            await DisplayAlert("Успешно!", "Мем скопирован в буфер! Можешь вставлять его через Ctrl+V.", "ОК");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ошибка Windows", $"Не удалось скопировать мем: {ex.Message}", "ОК");
        }
#else
        // Код для Android/iOS мобилок (копирует текст)
        if (selectedMeme.HasText)
        {
            await Clipboard.Default.SetTextAsync(selectedMeme.MemeText);
            await DisplayAlert("Скопировано", "Текст мема скопирован в буфер обмена смартфона!", "ОК");
        }
        else
        {
            await DisplayAlert("Инфо", "У этого мема нет текста для копирования", "ОК");
        }
#endif
    }
}