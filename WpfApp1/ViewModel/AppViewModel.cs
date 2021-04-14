using System;
using ContactBook.Helper;
using ContactBook.Model;

namespace ContactBook.ViewModel
{
    public class AppViewModel : ObservableObject
    {

        #region properties
        private object currentView;

        public object CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                OnPropertyChanged();
            }
        }

        private LoginViewModel loginVM;

        public LoginViewModel LoginVM
        {
            get { return loginVM; }
            set
            {
                loginVM = value;
                OnPropertyChanged();
            }
        }

        private SignupViewModel signupVM;

        public SignupViewModel SignupVM
        {
            get { return signupVM; }
            set
            {
                signupVM = value;
                OnPropertyChanged();
            }
        }

        private ContactBookViewModel contactbookVM;
        public ContactBookViewModel ContactbookVM
        {
            get { return contactbookVM; }
            set
            {
                contactbookVM = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region constructor

        public AppViewModel(SignupViewModel _signupVM, LoginViewModel _loginVM, ContactBookViewModel _contactbookVM)
        {
            signupVM = _signupVM;
            loginVM = _loginVM;
            contactbookVM = _contactbookVM;
            loginVM.ViewChange += this.OnViewChanged;
            contactbookVM.ViewChange += this.OnViewChanged;
            signupVM.ViewChange += this.OnViewChanged;
            CurrentView = this;
            SignupButtonCommand = new RelayCommand(SignupButton);
            LoginButtonCommand = new RelayCommand(LoginButton);
            ExitButtonCommand = new RelayCommand(ExitButton);
        }
        #endregion

        #region commands
        public RelayCommand SignupButtonCommand { get; private set; }
        public RelayCommand LoginButtonCommand { get; private set; }
        public RelayCommand ExitButtonCommand { get; private set; }

        private void SignupButton(object arg)
        {
            CurrentView = signupVM;
        }

        public void LoginButton(object arg)
        {
            CurrentView = loginVM;
        }

        private void ExitButton(object arg)
        {
            System.Windows.Application.Current.Shutdown();
        }

        public void ContactBookEntry(string ModelViewName)
        {
            if (ModelViewName.Equals("ContactBook"))
            {
                CurrentView = contactbookVM;
            }
            if (ModelViewName.Equals("Login"))
            {
                LoginButton("");
            }
        }
        #endregion

        #region other
        public void OnViewChanged(object source, string e)
        {
            if (e.Equals("ContactBook"))
            {
                CurrentView = contactbookVM;
            }
            if (e.Equals("Login"))
            {
                CurrentView = loginVM;
            }

            if (e.Equals("Signup"))
            {
                CurrentView = loginVM;
            }
        }
        #endregion
    }
}