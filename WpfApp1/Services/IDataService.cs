using ContactBook.Model;
using System.Collections.Generic;

namespace ContactBook.Services
{
    public interface IDataService
    {
        IEnumerable<Contact> GetContacts();
        void SaveContacts(IEnumerable<Contact> contacts);

        IEnumerable<User> GetUsers();
        void SaveUsers(IEnumerable<User> contacts);

    }
}
