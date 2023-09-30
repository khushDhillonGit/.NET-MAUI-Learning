using Microsoft.Maui.Layouts;

namespace TestMaui;

public partial class AbsolutePage : ContentPage
{
	public AbsolutePage()
	{
		InitializeComponent();

		var al = new AbsoluteLayout { BackgroundColor = Colors.Red };
		Content = al;

		var aquaBox = new BoxView { Color = Colors.Cyan};
		al.Add(aquaBox);
		AbsoluteLayout.SetLayoutBounds(aquaBox, new Rect(0.5,0.1,100,100));
		AbsoluteLayout.SetLayoutFlags(aquaBox, AbsoluteLayoutFlags.PositionProportional);

		var btn = new Button { Text = "Hello", TextColor = Colors.White, BackgroundColor = Colors.Silver};
		al.Add(btn);
        AbsoluteLayout.SetLayoutBounds(btn, new Rect(0, 1, 1, 0.1));
        AbsoluteLayout.SetLayoutFlags(btn, AbsoluteLayoutFlags.All);

    }
}