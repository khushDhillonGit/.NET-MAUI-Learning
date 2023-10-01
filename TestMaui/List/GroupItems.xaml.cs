namespace TestMaui.List;
using Contact = TestMaui.Models.Contact;
using TestMaui.Models;
using System.Collections.ObjectModel;
public partial class GroupItems : ContentPage
{
    private ObservableCollection<ContactGroup> contacts;
    public GroupItems()
    {
        InitializeComponent();
        contacts = new ObservableCollection<ContactGroup>
        {
            new ContactGroup("K","K")
            {
                new Contact { Name = "Khush", Status="Whatsapp is using me" , ImageUrl = "bg.png"},
            },
            new ContactGroup("S","S")
            {
                new Contact { Name = "Singh", Status="sing is king" , ImageUrl = "bg.png"}
            }
        };
        listView.ItemsSource = contacts;
    }

    //triggeres every time
    //private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
    //{
    //    var a = e.Item as Contact;
    //    DisplayAlert("Tapped", a.Name, "ok");
    //}


    //first time selected event fires after that tapped button is triggered
    //each item is a contact object
    //only triggers first time
    private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var a = e.SelectedItem as Contact;
        DisplayAlert("Selected",a.Name,"ok");
    }

    private void Call_Clicked(object sender, EventArgs e)
    {
        var a = sender as MenuItem;
        var contact = a.CommandParameter as Contact;
        DisplayAlert("Call", contact.Name, "Ok");
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        var contact = (sender as MenuItem).CommandParameter as Contact;
        var one = contacts.FirstOrDefault(a => a.Contains(contact));
        contacts.Remove(one);
        DisplayAlert("Removed", contact.Name, "Ok");
    }
}