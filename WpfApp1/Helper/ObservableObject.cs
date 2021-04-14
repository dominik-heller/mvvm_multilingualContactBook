using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Helper
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //atribut [CallerMemberName] získá název metody volající OnPropertyChanged => tzn. př. public string EmailAddress {get; set;} => získám název "EmailAddress" a ten se použije jako argument => výhoda: není třeba při volání OnPropertyChanged udávat argument názvu property =>získá ho automaticky z názvu
        protected void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
