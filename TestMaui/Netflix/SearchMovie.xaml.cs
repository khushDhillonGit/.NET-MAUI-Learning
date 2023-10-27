using SQLite;
using System.Collections.ObjectModel;
using TestMaui.Data;
using TestMaui.Models;
using TestMaui.Services;

namespace TestMaui.Netflix;

public partial class SearchMovie : ContentPage
{
    private ObservableCollection<Movie> Movies { get; set; }
    private readonly SQLiteAsyncConnection _connection;
    private readonly IMovieApIService _movieApIService;

    private BindableProperty IsSearchingProperty = BindableProperty.Create(nameof(IsSearching),typeof(bool),typeof(SearchMovie), false);

    public bool IsSearching 
    {
        get { return (bool)GetValue(IsSearchingProperty); }
        set { SetValue(IsSearchingProperty, value); }
    }

    public SearchMovie(ISQLiteDb sQLiteDb, IMovieApIService movieApIService)
    {
        InitializeComponent();
        _movieApIService = movieApIService;
        _connection = sQLiteDb.GetConnection();
        BindingContext = this;
    }

    protected async override void OnAppearing()
    {
        var a = await _connection.Table<Movie>().ToListAsync();
        await _connection.CreateTableAsync<Movie>();
       
        base.OnAppearing();
    }

    private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            var movie = (Movie)e.SelectedItem;
            await Navigation.PushAsync(new MovieDescription(movie));
        }
    }

    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Length >= 4)
        {
            IsSearching = true;
            var movies = await _movieApIService.GetMovies(e.NewTextValue);
            Movies = new(movies);
            movieList.ItemsSource = Movies;
            IsSearching = false;
            SaveToDatabase(movies);
        }
    }

    
    private void SaveToDatabase(List<Movie> movies) 
    {
         Task.Run(() => _connection.InsertAllAsync(movies));
    }

}