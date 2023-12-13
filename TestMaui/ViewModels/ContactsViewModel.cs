using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestMaui.Data;
using TestMaui.Forms;

namespace TestMaui.ViewModels
{
    public class ContactsViewModel: BaseViewModel
    {
        private readonly ISQLiteDb _connection;
        private ContactM _selectedItem;

        public ObservableCollection<ContactM> Contacts { get; set; }
        public ContactM SelectedItem { get => _selectedItem; set { SetValue(ref _selectedItem, value);} }

        public ICommand AddButtonCommand { get; set; }
        public ICommand SelectItemCommand { get; set; }

        public ContactsViewModel(ISQLiteDb sqlite) 
        {
            _connection = sqlite;
            Contacts = new ObservableCollection<ContactM>();
            AddButtonCommand = new Command(async() => await AddButton());
            SelectItemCommand = new Command(async(obj) => await SelectItem(obj as ContactM));
        }

        public async Task Initialize() 
        {
            var contacts = await _connection.GetAllContacts();
            //TODO : Optimize the observable list
            foreach (var contact in contacts) 
            {
                Contacts.Add(contact);
            }
        }

        private async Task AddButton() 
        {
            var addContactPage = new AddContactViewModel();
            addContactPage.AddContact += async (sender, contact) =>
            {
                Contacts.Add(contact);
                await _connection.AddContactAsync(contact);
            };
            await Application.Current.MainPage.Navigation.PushAsync(new AddContact());
        }
        
        private async Task SelectItem(ContactM contactM) 
        {
            SelectedItem = contactM;
            if (SelectedItem != null)
            {
                var contact = SelectedItem;
                var addContactPage = new AddContactViewModel();
                MessagingCenter.Send<ContactsViewModel,ContactM>(this, "SendContact", contact);
                addContactPage.UpdateContact += async (sender, contact) =>
                {
                    var oldContact = Contacts.FirstOrDefault(a => a.Id == contact.Id);
                    oldContact.FirstName = contact.FirstName;
                    oldContact.LastName = contact.LastName;
                    oldContact.Email = contact.Email;

                    oldContact.Phone = contact.Phone;
                    oldContact.IsBlocked = contact.IsBlocked;

                    await _connection.UpdateContactAsync(contact);
                };
                await Application.Current.MainPage.Navigation.PushAsync(new AddContact());
            }

        }

    }
}
