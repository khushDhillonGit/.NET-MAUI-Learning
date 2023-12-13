using Moq;
using TestMaui.Models;
using TestMaui.MVVM;
using TestMaui.ViewModels;
namespace TestMaui.Tests
{
    public class Tests
    {
        private PlaylistsViewModel _viewModel;
        private Mock<IPageService> _pageService;

        [SetUp]
        public void Setup()
        {
            _pageService = new Mock<IPageService>();
            _viewModel = new PlaylistsViewModel(_pageService.Object);
        }

        [Test]
        public void AddPlaylist_WhenCalled_NewPlaylistIsInTheList()
        {
            _viewModel.AddPlaylistCommand.Execute(null);
            Assert.That(_viewModel.Playlists, Has.Count.EqualTo(1));
        }

        [Test]
        public void SelectPlaylist_WhenCalled_ItemDeselected() 
        {
            var playlist = new PlaylistViewModel();
            _viewModel.Playlists.Add(playlist);

            _viewModel.SelectPlaylistCommand.Execute(playlist);

            Assert.That(_viewModel.SelectedPlayList, Is.Null);
        }

        [Test]
        public void SelectPlaylist_WhenCaller_IsfavoirteWorking() 
        {
            var playlist = new PlaylistViewModel();
            _viewModel.Playlists.Add(playlist);

            _viewModel.SelectPlaylistCommand.Execute(playlist);

            Assert.That(playlist.IsFavorite, Is.True);
        }

        [Test]
        public void SelectPlaylist_WhenCalled_NavigateToPlaylistDetailPage() 
        {
            var playlist = new PlaylistViewModel();
            _viewModel.Playlists.Add(playlist);

            _viewModel.SelectPlaylistCommand.Execute(playlist);

            _pageService.Verify(p => p.PushAsync(It.IsAny<PlaylistDetailPage>()));
        }
    }
}