using ContactBook.Helper;
using ContactBook.Model;
using ContactBook.Services;
using ContactBook.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace ContactBook.ViewModel
{
    public class SignupViewModel : ObservableObject, IEventHandler
    {
        #region properties
        private readonly IDataService dataService;
        private readonly IDialogService dialogService;

        private ObservableCollection<User> userList;
        public ObservableCollection<User> UserList
        {
            get { return userList; }
            set
            {
                userList = value;
              //  OnPropertyChanged();
            }
        }

        public string LoginName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        #endregion

        #region constructor
        public SignupViewModel(IDataService dataService, IDialogService dialogService)
        {
            this.dataService = dataService;
            this.dialogService = dialogService;
            SignupConrirmCommand = new RelayCommand(SignupConfirm, CanSignupConfirm);
            LoadUsers(dataService.GetUsers());
        }
        #endregion

        #region commands
        public RelayCommand SignupConrirmCommand { get; private set; }

        private bool CanSignupConfirm(object arg)
        {
            if (arg != null)
            {
                var passwordBox = (PasswordBox)arg;
                var Password = passwordBox.Password;
                if (string.IsNullOrEmpty(LoginName) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(FirstName))
                {
                    return false;
                }
                else { 
                    return true; 
                }
            }
            return false;
        }

        private void SignupConfirm(object arg)
        {
            var passwordBox = (PasswordBox)arg;
            var Password = passwordBox.Password;
            if (UserList.Any(x => x.Login == LoginName))
            {
                dialogService.ShowMessageBox(LocalizationProvider.GetLocalizedValue<String>("LoginExists"));
            }
            else
            {
                UserList.Add(new User { Login = LoginName, Password = Password, FirstName = FirstName, LastName = LastName });
                dataService.SaveUsers(UserList);
                dialogService.ShowMessageBox(LocalizationProvider.GetLocalizedValue<String>("SignupSuccessful"));
                OnViewChanged("Login");
            }
        }

        public void LoadUsers(IEnumerable<User> users)
        {
            UserList = new ObservableCollection<User>(users);
        }
        #endregion

        #region other
        public event EventHandler<string> ViewChange;
        public void OnViewChanged(string s)
        {
            if (ViewChange != null)
            {
                ViewChange(this, s);
            }
        }
        #endregion
    }
}
