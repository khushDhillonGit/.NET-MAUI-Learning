using TestMaui.Models;
using TestMaui.Services;

namespace TestMaui.List;

public partial class ListEx : ContentPage
{
    private readonly SearchService _searchService;
    private string searchString = null;
	public ListEx()
	{
		InitializeComponent();
        _searchService = new SearchService();
        LoadList();
    }

    private void LoadList() 
    {
        List<SearchGroup> searches = new List<SearchGroup> { new SearchGroup("Resent Searches", "RS") };
        searches.FirstOrDefault().AddRange(_searchService.GetSearches(searchString));
        listView.ItemsSource = searches;
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        searchString = e.NewTextValue;
        LoadList();
    }

    private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var item = e.Item as Search;
        DisplayAlert("Search", item.Location, "Ok");
    }

    private void listView_Refreshing(object sender, EventArgs e)
    {
        LoadList();
        listView.EndRefresh();
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {

        var menuItem = sender as MenuItem;

        int id = (int)(sender as MenuItem).CommandParameter;
        _searchService.DeleteSearch(id);
    }
}