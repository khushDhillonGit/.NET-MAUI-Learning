using System.Collections.ObjectModel;
using TestMaui.Models;
using TestMaui.ViewModels;

namespace TestMaui.MVVM;

public partial class PlaylistsPage : ContentPage
{
  

    public PlaylistsPage ()
    {
        InitializeComponent ();
    }

    protected override void OnAppearing ()
    {
        BindingContext = new PlaylistsViewModel();
        base.OnAppearing ();
    }

    void OnAddPlaylist (object sender, System.EventArgs e)
    {
        (BindingContext as PlaylistsViewModel).AddPlaylist();
    }

    void OnPlaylistSelected (object sender, SelectedItemChangedEventArgs e)
    {

        (BindingContext as PlaylistsViewModel).SelectPlaylist(e.SelectedItem as PlaylistViewModel);
        
    }
}
