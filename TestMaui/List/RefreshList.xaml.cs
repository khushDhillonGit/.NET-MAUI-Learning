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
    List<Contact> GetContacts() 
    {
        return new List<Contact>
        {
            new Contact { Name = "Khush", Status="Whatsapp is using me" , ImageUrl = "bg.png"},
            new Contact { Name = "Singh", Status="sing is king" , ImageUrl = "bg.png"}
        };
    }
    private void listView_Refreshing(object sender, EventArgs e)
    {
        listView.ItemsSource = GetContacts();

        listView.IsRefreshing = false;
        //or
        listView.EndRefresh();
    }
}