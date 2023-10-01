namespace TestMaui.Images;

public partial class ImageEx : ContentPage
{
	public ImageEx()
	{
		InitializeComponent();
		gallaryImage.Source = "bg.png";
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		gallaryImage.Source =  "dotnet_bot.svg";
    }

	private void ImageBack(object sender, EventArgs e) 
	{
        gallaryImage.Source = "pressure.png";
    }
}