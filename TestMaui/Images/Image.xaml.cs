namespace TestMaui.Images;

public partial class Image : ContentPage
{
	public Image()
	{
		InitializeComponent();

		//maui chaches images for 24 hours in the system 
		var imageSource = new UriImageSource { Uri = new Uri("https://media.istockphoto.com/id/838308750/photo/golden-retriever-dog-puppy-playing-with-toy.webp?b=1&s=612x612&w=0&k=20&c=ULnpwu0yqcd-_74utsUOmtq-twUOacKU0lg6J8u48T8=") };
		//to load instantly
		imageSource.CachingEnabled = false;
		//we can change image cache
		imageSource.CacheValidity = TimeSpan.FromHours(1);
		image.Source = imageSource;

	}
}