
using Color = System.Drawing.Color;

namespace TestMaui.ViewModels
{
    public class PlaylistViewModel:BaseViewModel
    {
        public string Title { get; set; }

        private bool _isFavorite;
        public bool IsFavorite
        {
            get { return _isFavorite; }
            set
            {
                SetValue<bool>(ref _isFavorite, value);
                OnPropertyChanged(nameof(Color));
            }
        }

        public Color Color
        {
            get { return IsFavorite ? Color.Red : Color.Black; }
        }
    }
}
