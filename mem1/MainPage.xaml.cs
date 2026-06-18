using System.IO;

namespace mem1;

public partial class MainPage : ContentPage
{
    int count = 0;
    Random random = new Random();

    // Переменная для хранения текущей картинки
    string currentMeme = "memea.gif";

    List<string> memeList = new List<string>
    {
        "one.gif", "two.webp", "three.gif", "foy.webp", "five.webp",
        "six.gif", "seven.webp", "eight.gif", "nine.webp", "ten.webp",
        "eleven.gif", "twenteen.webp", "thirteen.webp", "foyteen.webp", "fiveteen.webp",
        "memeu.webp", "memey.gif", "memet.gif", "memex.webp", "memer.webp",
        "memeq.gif", "memep.webp", "memeo.webp", "memen.webp", "memem.webp",
        "memel.gif", "memek.webp", "memej.webp", "memei.webp", "memeh.webp",
        "memev.webp", "memee.gif", "memed.webp", "memec.webp", "memeb.gif", "memea.gif"
    };

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        CountLabel.Text = $"Сгенерировано мемов: {count}";

        int randomIndex = random.Next(memeList.Count);
        currentMeme = memeList[randomIndex];
        MemImage.Source = currentMeme;

        if (!MemeStorage.SavedMemes.Contains(currentMeme))
        {
            MemeStorage.SavedMemes.Add(currentMeme);
        }
    }

    private void OnFavoriteClicked(object sender, EventArgs e)
    {
        DisplayAlert("Уведомление", "Добавлено в избранное", "OK");
    }

    // Логика скачивания для Windows
    private async void OnDownloadClicked(object sender, EventArgs e)
    {
        try
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string targetPath = Path.Combine(docPath, currentMeme);

            using var stream = await FileSystem.OpenAppPackageFileAsync(currentMeme);
            using var fileStream = File.Create(targetPath);
            await stream.CopyToAsync(fileStream);

            await DisplayAlert("Успешно", $"Мем сохранен в папку Документы", "ОК");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ошибка", $"Не удалось сохранить: {ex.Message}", "ОК");
        }
    }
}