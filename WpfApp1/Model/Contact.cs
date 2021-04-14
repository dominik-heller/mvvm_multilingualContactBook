using ContactBook.Helper;
using System.Drawing;

namespace ContactBook.Model
{
    public class Contact : ObservableObject
    {
        #region properties
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged();
            }
        }

        private string emailAddress;

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value;
                OnPropertyChanged();
            }
        }

        private string image;

        public string Image
        {
            get { return image; }
            set { image = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
