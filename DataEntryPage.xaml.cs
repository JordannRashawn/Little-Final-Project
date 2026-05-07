using FinalProject.Models;
using FinalProject.Services;

namespace FinalProject;

public partial class DataEntryPage : ContentPage
{
    private readonly GoogleSheetsService service = new GoogleSheetsService();

	public DataEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        formCard.Opacity = 0;
        formCard.Scale = 0.9;
        await formCard.FadeTo(1, 600);
        await formCard.ScaleTo(1, 600);
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(nameEntry.Text))
        {
            await DisplayAlert("Missing Name", "Please enter your name.", "OK");
            return;
        }
        if (zodiacPicker.SelectedItem == null)
        {
            await DisplayAlert("Missing Zodiac", "Please choose your zodiac sign.", "OK");
            return;
        }

        var reading = new ZodiacReading
        {
            name = nameEntry.Text,
            birthdate = birthDatePicker.Date.ToString("MM/dd/yyyy"),
            birthtime = birthTimePicker.Time.ToString(@"hh\:mm"),
            zodiac = zodiacPicker.SelectedItem.ToString()
        };

        await service.AddEntry(reading);
        await DisplayAlert("Saved", "Your zodiac reading was saved.", "OK");
        nameEntry.Text = "";
        zodiacPicker.SelectedItem = null;
    }

    private async void OnViewClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(DataDisplayPage));
    }
}
