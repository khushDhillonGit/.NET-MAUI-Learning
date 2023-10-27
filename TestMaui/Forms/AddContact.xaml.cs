namespace TestMaui.Forms;

public partial class AddContact : ContentPage
{
	public ContactM ContactM { get; set; }
	
	public event EventHandler<ContactM> NewContactEvent;
	public event EventHandler<ContactM> UpdateContactEvent;

	public AddContact(ContactM contact)
	{
		InitializeComponent();
		ContactM = contact;
		if (ContactM == null) 
		{
			ContactM = new ContactM();
		}
		BindingContext = ContactM;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		var contact = (sender as Button).CommandParameter as ContactM;
		if (contact.Id == 0)
		{
			NewContactEvent?.Invoke(this, contact);
		}
		else 
		{
			UpdateContactEvent?.Invoke(this, contact);
		}
    }

	public Button Button { get => saveButton; }


}