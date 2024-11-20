namespace Pages;

public partial class GamesPage : ContentPage
{

	public GamesPage()
	{

		InitializeComponent();


        Loaded += OnPageLoaded;
	}


    private async void OnPageLoaded(object? sender, EventArgs e)
    {

        await DisplayAlert("Loaded event raised", "Fuck it", "Csdjksd");
     
        Loaded -= OnPageLoaded;
    }
}