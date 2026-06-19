namespace mem1;

public partial class MemeEditorPage : ContentPage
{
    private string selectedTemplate = "one.gif";

    public MemeEditorPage()
    {
        InitializeComponent();
    }

    private void OnTemplateSelected(object sender, EventArgs e)
    {
        if (sender is ImageButton button)
        {
            selectedTemplate = button.Source.ToString().Replace("File: ", "");
            PreviewImage.Source = selectedTemplate;
        }
    }

    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        PreviewLabel.Text = e.NewTextValue;
    }

    private void OnEmojiClicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            MemeTextEntry.Text += button.Text;
        }
    }

    private async void OnSaveMemeClicked(object sender, EventArgs e)
    {
        var newMeme = new UserMeme
        {
            TemplatePath = selectedTemplate,
            MemeText = MemeTextEntry.Text
        };

        CustomMemeStorage.CreatedMemes.Add(newMeme);
        MemeTextEntry.Text = string.Empty; // Очищаем поле после сохранения

        await DisplayAlert("Успешно", "Мем с подписью сохранен в вашу галерею!", "ОК");
    }
}