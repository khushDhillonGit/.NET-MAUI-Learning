using System.Collections.ObjectModel;
using TestMaui.Models;
using TestMaui.ViewModels;

namespace TestMaui.MVVM;

public partial class PlaylistsPage : ContentPage
{
    public PlaylistsPage ()
    {
        InitializeComponent ();
        ViewModel = new PlaylistsViewModel (new PageService());
    }

    protected override void OnAppearing ()
    {
        base.OnAppearing();
    }

    void OnPlaylistSelected (object sender, SelectedItemChangedEventArgs e)
    {
       ViewModel.SelectPlaylistCommand.Execute(e.SelectedItem);
    }

    private PlaylistsViewModel ViewModel { get { return BindingContext as PlaylistsViewModel;  } set { BindingContext = value;  } }
}
