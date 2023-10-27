namespace TestMaui.Navigation;

public partial class SendingData : ContentPage
{
	public SendingData()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		var a = sender as Contact;
    }
}