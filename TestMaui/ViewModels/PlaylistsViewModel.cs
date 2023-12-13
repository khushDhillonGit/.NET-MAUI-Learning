using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestMaui.Models;
using TestMaui.MVVM;

namespace TestMaui.ViewModels
{
    public class PlaylistsViewModel : BaseViewModel
    {
        private PlaylistViewModel _selectedPlaylist;

        public ObservableCollection<PlaylistViewModel> Playlists { get; private set; } = new ObservableCollection<PlaylistViewModel>();
        public PlaylistViewModel SelectedPlayList { get => _selectedPlaylist; set { if (_selectedPlaylist == value) return; _selectedPlaylist = value; OnPropertyChanged(); } }

        public ICommand AddPlaylistCommand { get; private set; }
        public ICommand SelectPlaylistCommand { get; private set; }

        private readonly IPageService _pageService; 
        //public PlaylistsViewModel(IPageService pageService) 
        public PlaylistsViewModel(IPageService pageService) 
        {
            _pageService = pageService;
            AddPlaylistCommand = new Command(AddPlaylist);
            SelectPlaylistCommand = new Command<PlaylistViewModel>(async (vm) => await SelectPlaylist(vm));
        }

        private void AddPlaylist() 
        {
            var newPlaylist = "Playlist " + (Playlists.Count + 1);

            Playlists.Add(new PlaylistViewModel { Title = newPlaylist });
        }

        private async Task SelectPlaylist(PlaylistViewModel playlist) 
        {
            if (playlist == null)
                return;
            playlist.IsFavorite = !playlist.IsFavorite;

            SelectedPlayList = null;
            await _pageService.PushAsync(new PlaylistDetailPage(playlist));
            //await Application.Current.MainPage.Navigation.PushAsync(new PlaylistDetailPage(playlist));
            //await Navigation.PushAsync(new PlaylistDetailPage(playlist)); //we dont have navigation part of this vm it is part of page
        }
    }
}
