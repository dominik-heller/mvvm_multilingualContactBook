using ContactBook.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContactBook.Model
{
  
    public class User : ObservableObject
    {
        #region properties
        private string login;

        public string Login
        {
            get { return login; }
            set { login = value;
                OnPropertyChanged();
            }
        }


        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value;
                OnPropertyChanged();
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value;
                OnPropertyChanged();
            }
        }


        private string password;

        public string Password
        {
            get { return password; }
            set { password = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
