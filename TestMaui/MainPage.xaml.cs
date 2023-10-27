
namespace TestMaui;

using Newtonsoft.Json;
using System.Text.Json.Serialization;
using IFileSystem = TestMaui.Services.IFileSystem;
public partial class MainPage : ContentPage
{

	private const string Url = "https://jsonplaceholder.typicode.com/posts";
	private HttpClient _httpClient = new HttpClient();

	public MainPage()
	{
		InitializeComponent();
		var fs = DependencyService.Get<IFileSystem>();
		fs.WriteTextAsync("", "");
	}

    protected override async void OnAppearing()
    {
		var content = await _httpClient.GetStringAsync(Url);
		var posts = JsonConvert.DeserializeObject<string>(content);
        base.OnAppearing();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}



