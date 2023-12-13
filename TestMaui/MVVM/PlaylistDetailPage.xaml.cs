using System;
using System.Collections.Generic;
using TestMaui.Models;
using TestMaui.ViewModels;

namespace TestMaui.MVVM;

public partial class PlaylistDetailPage : ContentPage
{
    private PlaylistViewModel _playlist; 

    public PlaylistDetailPage (PlaylistViewModel playlist)
    {
        _playlist = playlist; 
        
        InitializeComponent ();

        title.Text = _playlist.Title;
    }
}
