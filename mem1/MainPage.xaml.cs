
using System.IO;

namespace mem1;

public partial class MainPage : ContentPage
{
    int count = 0;
    Random random = new Random();

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

        // Принудительный сброс источника
        MemImage.Source = null;

        // Явное указание загрузить файл как Asset
        // Если файлы лежат в Resources/Images, простого имени обычно достаточно,
        // если не заработает — попробуйте использовать путь: "Resources/Images/" + currentMeme
        MemImage.Source = ImageSource.FromFile(currentMeme);

        if (!MemeStorage.SavedMemes.Contains(currentMeme))
        {
            MemeStorage.SavedMemes.Add(currentMeme);
        }
    }

    private void OnFavoriteClicked(object sender, EventArgs e)
    {
        if (!MemeService.SavedMemes.Contains(currentMeme))
        {
            MemeService.SavedMemes.Add(currentMeme);
            DisplayAlert("Успешно", "Мем добавлен в избранное!", "OK");
        }
        else
        {
            DisplayAlert("Уведомление", "Этот мем уже в избранном.", "OK");
        }
    }
    private async void OnViewFavoritesClicked(object sender, EventArgs e)
{
    await Navigation.PushAsync(new SavedMemesPage());
}
}