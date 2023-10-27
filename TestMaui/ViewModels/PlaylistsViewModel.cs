using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMaui.Models;

namespace TestMaui.ViewModels
{
    public class PlaylistsViewModel : BaseViewModel
    {
        public ObservableCollection<PlaylistViewModel> Playlists { get; private set; } = new ObservableCollection<PlaylistViewModel>();

        private PlaylistViewModel _selectedPlaylist;
        public PlaylistViewModel SelectedPlayList { get => _selectedPlaylist; set { if (_selectedPlaylist == value) return; _selectedPlaylist = value; OnPropertyChanged(); } }

        private readonly IPageService _pageService; 
        public PlaylistsViewModel(IPageService pageService) 
        {
            _pageService = pageService;
        }

        public void AddPlaylist() 
        {
            var newPlaylist = "Playlist " + (Playlists.Count + 1);

            Playlists.Add(new PlaylistViewModel { Title = newPlaylist });
        }

        public void SelectPlaylist(PlaylistViewModel playlist) 
        {
            if (playlist == null)
                return;
            playlist.IsFavorite = !playlist.IsFavorite;

            SelectedPlayList = null;
            await Navigation.PushAsync (new PlaylistDetailPage(playlist));
        }
    }
}
