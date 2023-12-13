

using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TestMaui.Data;
using TestMaui.ViewModels;

namespace TestMaui.Forms;

public partial class Contact : ContentPage
{
    private ContactsViewModel ViewModel { get => (BindingContext as ContactsViewModel); set { BindingContext = value; } }
    private bool isLoaded = false;
    public Contact(ISQLiteDb sQLite)
    {
        InitializeComponent();
        ViewModel = new ContactsViewModel(sQLite);
    }

    private void ContactList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        ViewModel.SelectItemCommand.Execute(e.SelectedItem);
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        if (!isLoaded) { await ViewModel.Initialize(); isLoaded = true; }
    }
}
public class ContactM : INotifyPropertyChanged
{

    public event PropertyChangedEventHandler PropertyChanged;

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    private string firstName;
    public string FirstName { get => firstName; set { firstName = value; OnPropertyChanged(); OnPropertyChanged(nameof(FullName)); } }

    private string lastName;
    public string LastName { get => lastName; set { lastName = value; OnPropertyChanged(); OnPropertyChanged(nameof(FullName)); } }

    private string phone;
    public string Phone { get => phone; set { phone = value; OnPropertyChanged(); } }

    private string email;
    public string Email { get => email; set { email = value; OnPropertyChanged(); } }

    private bool isBlocked = false;
    public bool IsBlocked { get => isBlocked; set { isBlocked = value; OnPropertyChanged(); } }

    public string FullName { get { return string.Join(' ', FirstName, LastName); } }

    private void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}