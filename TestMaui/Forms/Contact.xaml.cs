

using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TestMaui.Data;

namespace TestMaui.Forms;

public partial class Contact : ContentPage
{

	private ObservableCollection<ContactM> _contacts = new ObservableCollection<ContactM>();
	private bool isLoaded = false;
	private SQLiteAsyncConnection _connection;

	public Contact(SQLiteDb sQLite)
	{
		InitializeComponent();
		_connection = sQLite.GetConnection();
	}

	protected async override void OnAppearing() 
	{

		if (isLoaded) return;

		isLoaded = true;

        await _connection.CreateTableAsync<ContactM>();
		var contacts = await _connection.Table<ContactM>().ToListAsync();
		_contacts = new(contacts);
		ContactList.ItemsSource = _contacts;

        base.OnAppearing();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        var addContactPage = new AddContact(null);
		addContactPage.NewContactEvent += async (sender, contact) =>
		{
			_contacts.Add(contact);
			await _connection.InsertAsync(contact);
		};
        await Navigation.PushAsync(addContactPage);
    }

    private async void ContactList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if (e.SelectedItem != null) 
		{
			var contact = (ContactM)e.SelectedItem;
			var addContactPage = new AddContact(contact);
			addContactPage.UpdateContactEvent += async (sender, contact) => 
			{
				var oldContact = _contacts.FirstOrDefault(a=>a.Id == contact.Id);
				_contacts.Remove(oldContact);
				_contacts.Add(contact);
				await _connection.UpdateAsync(contact);
			};
            await Navigation.PushAsync(addContactPage);
		}

    }

}
public class ContactM : INotifyPropertyChanged
{

	public event PropertyChangedEventHandler PropertyChanged;

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }

	private string firstName;
	public string FirstName { get=> firstName; set { firstName = value; OnPropertyChanged(); OnPropertyChanged(nameof(FullName));  } }

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
		//PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}
}