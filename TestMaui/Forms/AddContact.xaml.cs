using TestMaui.ViewModels;
namespace TestMaui.Forms;

public partial class AddContact : ContentPage
{
	public AddContact()
	{
		InitializeComponent();
		BindingContext = new AddContactViewModel().Contact;
	}
}