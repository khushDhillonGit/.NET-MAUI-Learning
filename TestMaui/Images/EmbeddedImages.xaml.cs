namespace TestMaui.Images;

public partial class EmbeddedImages : ContentPage
{
	public EmbeddedImages()
	{
		InitializeComponent();
		image.Source = ImageSource.FromResource("bg.png");
	}
}