using Microsoft.Maui.Controls.Compatibility.Hosting;
using TestMaui.Data;
using TestMaui.Netflix;
using TestMaui.Services;
using Contact = TestMaui.Forms.Contact;
namespace TestMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>().UseMauiCompatibility()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddTransient<IMovieApIService, MovieApIService>();
		builder.Services.AddSingleton<ISQLiteDb ,SQLiteDb>();
		builder.Services.AddSingleton<Contact>();
		builder.Services.AddSingleton<SearchMovie>();
		return builder.Build();
	}
}
