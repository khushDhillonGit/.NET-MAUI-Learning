using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestMaui.Forms;

namespace TestMaui.ViewModels
{
    public class AddContactViewModel:BaseViewModel
    {
        public ContactM Contact { get; set; }
        public event EventHandler<ContactM> AddContact;
        public event EventHandler<ContactM> UpdateContact;

        public ICommand ButtonClickedCommand { get; set; }

        public AddContactViewModel()
        {
            MessagingCenter.Subscribe<ContactM>(this, "SendContact", (obj) => Contact = obj);
            Contact ??= new ContactM();
            ButtonClickedCommand = new Command((obj) => ButtonClicked(obj as ContactM));
        }

        private void ButtonClicked(ContactM contact) 
        {
            Contact = contact;
            if(Contact != null) 
            {
                if (Contact.Id == 0)
                {
                    AddContact?.Invoke(this, Contact);
                }
                else 
                {
                    UpdateContact?.Invoke(this, Contact);
                }
            }
        }

    }
}
