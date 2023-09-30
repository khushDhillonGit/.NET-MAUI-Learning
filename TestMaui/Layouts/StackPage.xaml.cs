namespace TestMaui;

public partial class StackPage : ContentPage
{
	public StackPage()
	{
		InitializeComponent();

		var layout  = new StackLayout 
		{
			Orientation = StackOrientation.Horizontal,
			Spacing = 10,
			Padding = new Thickness(0,20,0,0)
		};

		layout.Children.Add(new Label { Text = "Label1"});

		Content = layout;
	}
}