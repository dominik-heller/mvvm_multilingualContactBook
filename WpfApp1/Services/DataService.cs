using ContactBook.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace ContactBook.Model
{
    public class DataService : IDataService
    {

        #region UserData
        private IEnumerable<User> userList = new List<User> {
            new User { FirstName = "Test", LastName = "Test", Login = "test", Password = "test" }
        };

        public IEnumerable<User> GetUsers()
        {
            return userList;
        }

        public void SaveUsers(IEnumerable<User> list)
        {
            userList = list;
        }
        #endregion

        #region ContactData
        private IEnumerable<Contact> _contactList = new List<Contact> {
            new Contact { FirstName="Maxipes", LastName="Fík", PhoneNumber="6876968", EmailAddress="maxipes@fik.cz", Image="/Images/fik.jpg"},
            new Contact { FirstName="Karel", LastName="IV", PhoneNumber="6876968543", EmailAddress="karl@kaiser.de", Image="/Images/karelIV.jpg"},
            new Contact { FirstName="George", LastName="Orwell", PhoneNumber="12876968", EmailAddress="1984@animalfarm.en", Image="/Images/default-user-image.png"},
            new Contact { FirstName="Michael", LastName="Scofield", PhoneNumber="4698708", EmailAddress="michaels@prisonbreak.com", Image="/Images/default-user-image.png"},
            new Contact { FirstName="Jimmy", LastName="Hendrix", PhoneNumber="5869889", EmailAddress="purplehaze@woodstock.com", Image="/Images/default-user-image.png"},
            new Contact { FirstName="Don", LastName="Corleone", PhoneNumber="+4207899797", EmailAddress="offer@youtcantrefuse.it", Image="/Images/Godfather.jpg"}
        };


        public IEnumerable<Contact> GetContacts()
        {
            return _contactList;
        }


        public void SaveContacts(IEnumerable<Contact> contacts)
        {
            _contactList = contacts.Select(contact => new Contact { FirstName = contact.FirstName, LastName = contact.LastName, EmailAddress = contact.EmailAddress, PhoneNumber = contact.PhoneNumber, Image = contact.Image }).ToList();
        }
        #endregion
    }
}
