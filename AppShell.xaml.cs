namespace FinalProject;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(DataEntryPage), typeof(DataEntryPage));
		Routing.RegisterRoute(nameof(DataDisplayPage), typeof(DataDisplayPage));
		Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
	}
}
