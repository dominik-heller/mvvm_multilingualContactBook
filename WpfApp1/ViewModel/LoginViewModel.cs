using ContactBook.Helper;
using ContactBook.Model;
using ContactBook.Services;
using ContactBook.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ContactBook.ViewModel
{
    public class LoginViewModel : ObservableObject, IEventHandler
    {
        #region properties;
        private readonly IDataService dataService;
        private readonly IDialogService dialogService;

        public IEnumerable<User> UserList
        {
            get { return dataService.GetUsers(); }
        }

        public string LoginName { get; set; }

        #endregion

        #region constructor
        public LoginViewModel(IDataService dataService, IDialogService dialogService)
        {
            this.dataService = dataService;
            this.dialogService = dialogService;
            LoginConrirmCommand = new RelayCommand(LoginConfirm, CanLoginConfirm);
        }

        #endregion

        #region commands
        public RelayCommand LoginConrirmCommand { get; private set; }

        private bool CanLoginConfirm(object arg)
        {
            if (arg != null)
            {
                var passwordBox = (PasswordBox)arg;
                if (string.IsNullOrEmpty(LoginName) || string.IsNullOrEmpty(passwordBox.Password)) { return false; } else { return true; }
            } return false;
        }

        private void LoginConfirm(object arg)
        {
            var passwordBox = (PasswordBox)arg;
            if (UserList.Any(x => x.Login == LoginName) && UserList.Any(x => x.Password == passwordBox.Password))
            {
                //dialogService.ShowMessageBox(LocalizationProvider.GetLocalizedValue<String>("LoginSuccessful"));
                OnViewChanged("ContactBook");
            }
            else { dialogService.ShowMessageBox(LocalizationProvider.GetLocalizedValue<String>("InvalidLogin")); }
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
