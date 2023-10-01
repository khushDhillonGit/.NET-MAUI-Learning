namespace TestMaui.List;
using Contact = TestMaui.Models.Contact;
public partial class CustomCell : ContentPage
{
	public CustomCell()
	{
		InitializeComponent();

        listView.ItemsSource = new List<Contact>
        {
            new Contact { Name = "Khush", Status="Whatsapp is using me" , ImageUrl = "bg.png"},
            new Contact { Name = "Singh", Status="sing is king" , ImageUrl = "bg.png"}
        };
    }
}