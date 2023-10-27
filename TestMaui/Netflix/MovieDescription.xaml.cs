using TestMaui.Models;

namespace TestMaui.Netflix;

public partial class MovieDescription : ContentPage
{
	private readonly Movie _movie;
	public MovieDescription(Movie movie)
	{
		InitializeComponent();
		_movie = movie;
		BindingContext = _movie;
	}
}