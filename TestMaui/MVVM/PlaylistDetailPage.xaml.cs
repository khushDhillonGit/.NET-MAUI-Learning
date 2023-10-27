using System;
using System.Collections.Generic;
using TestMaui.Models;

namespace TestMaui.MVVM;

public partial class PlaylistDetailPage : ContentPage
{
    private Playlist _playlist; 

    public PlaylistDetailPage (Playlist playlist)
    {
        _playlist = playlist; 
        
        InitializeComponent ();

        title.Text = _playlist.Title;
    }
}
