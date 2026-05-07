namespace FinalProject;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Animate zodiac image frame
        zodiacFrame.Opacity = 0;
        zodiacFrame.Scale = 0.8;

        await zodiacFrame.FadeTo(1, 1200);
        await zodiacFrame.ScaleTo(1, 1200);

        // Animate welcome title
        welcomeLabel.TranslationY = -50;
        welcomeLabel.Opacity = 0;

        await welcomeLabel.TranslateTo(0, 0, 1000);
        await welcomeLabel.FadeTo(1, 1000);
    }

    private async void OnExploreClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(DataEntryPage));
    }
}
