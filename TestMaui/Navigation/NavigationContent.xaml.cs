namespace TestMaui.Navigation;

public partial class NavigationContent : ContentPage
{
	public NavigationContent()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new MainPage());
    }
}