using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                OnPropertyChanged(nameof(Colour));
            }
        }

        public Color Colour
        {
            get { return IsFavorite ? Color.Red : Color.Black; }
        }
    }
}
