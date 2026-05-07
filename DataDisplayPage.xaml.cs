using FinalProject.Models;
using FinalProject.Services;

namespace FinalProject;

public partial class DataDisplayPage : ContentPage
{
    private readonly GoogleSheetsService service = new GoogleSheetsService();
    private List<ZodiacReading> allReadings = new List<ZodiacReading>();

	public DataDisplayPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        allReadings = await service.GetEntries();
        readingsCollection.ItemsSource = allReadings;
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string search = e.NewTextValue?.ToLower() ?? "";
        readingsCollection.ItemsSource = allReadings
            .Where(r => (r.name ?? "").ToLower().Contains(search) || (r.zodiac ?? "").ToLower().Contains(search))
            .ToList();
    }

    private async void OnSwipeInfo(object sender, EventArgs e)
    {
        await DisplayAlert("Swipe Feature", "This is an extra feature for the project.", "OK");
    }
}
