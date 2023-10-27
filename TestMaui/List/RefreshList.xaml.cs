namespace TestMaui.List;
using Contact = TestMaui.Models.Contact;
using TestMaui.Models;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;

public partial class RefreshList : ContentPage
{
    private ObservableCollection<Contact> contacts;
    public RefreshList()
	{
		InitializeComponent();
     
        listView.ItemsSource = GetContacts();
    }
    
    IEnumerable<Contact> GetContacts(string searchText = null) 
    {

        var contacts = new List<Contact>
        {
            new Contact { Name = "Khush", Status="Whatsapp is using me" , ImageUrl = "bg.png"},
            new Contact { Name = "Singh", Status="sing is king" , ImageUrl = "bg.png"}
        };

        if (string.IsNullOrWhiteSpace(searchText)) 
        {
            return contacts;
        }

        return contacts.Where(x=>x.Name.StartsWith(searchText));
    }
    private void listView_Refreshing(object sender, EventArgs e)
    {
        listView.ItemsSource = GetContacts();

        listView.IsRefreshing = false;
        //or
        listView.EndRefresh();
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        listView.ItemsSource = GetContacts(e.NewTextValue);
    }
}