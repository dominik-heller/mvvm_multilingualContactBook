using ContactBook.Helper;
using ContactBook.Model;
using ContactBook.Services;
using ContactBook.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace ContactBook.ViewModel
{
    public class ContactBookViewModel : ObservableObject, IEventHandler
    {
        #region contstructor
        private readonly IDataService dataService;
        private readonly IDialogService dialogService;

        public ContactBookViewModel(IDataService _dataService, IDialogService _dialogService)
        {
            dataService = _dataService;
            dialogService = _dialogService;
            LogoutCommand = new RelayCommand(LogoutButton);
            DeleteCommand = new RelayCommand(Delete, CanDelete);
            AddCommand = new RelayCommand(Add, CanAdd);
            EditCommand = new RelayCommand(Edit, CanEdit);
            CancelEditCommand = new RelayCommand(CancelEdit);
            SaveCommand = new RelayCommand(Save);
            EditImageCommand = new RelayCommand(EditImage, CanEditImage);
            LoadContacts();
        }
        #endregion

        #region properties
        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Contact> contactList;
        public ObservableCollection<Contact> ContactList
        {
            get { return contactList; }
            private set
            {
                contactList = value;
                OnPropertyChanged();
            }
        }

        private bool editMode;
        public bool EditMode
        {
            get
            {
                return editMode;
            }
            set
            {
                editMode = value;
                OnPropertyChanged();
            }
        }

        private bool visibilityProperty;
        public bool VisibilityProperty
        {
            get
            {
                return visibilityProperty;
            }
            set
            {
                visibilityProperty = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region commands
        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand LogoutCommand { get; private set; }
        public RelayCommand AddCommand { get; private set; }
        public RelayCommand EditCommand { get; private set; }
        public RelayCommand EditImageCommand { get; private set; }
        public RelayCommand CancelEditCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }


        private bool CanDelete(object arg)
        {
            if (SelectedContact == null || EditMode == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CanEditImage(object arg)
        {
            if (SelectedContact == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CanAdd(object arg)
        {
            if (EditMode == true)
                return false;
            else return true;
        }

        private bool CanEdit(object arg)
        {
            if (EditMode == true || SelectedContact == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void EditImage(object arg)
        {
            SelectedContact.Image = dialogService.OpenFile();
            //dialogService.ShowMessageBox(LocalizationProvider.GetLocalizedValue<String>("ImageAdd"));
        }
        private void Edit(object arg)
        {
            dataService.SaveContacts(ContactList);
            VisibilityProperty = true;
            EditMode = true;
            //dialogService.ShowMessageBox(LocalizationProvider.GetLocalizedValue<String>("ContactEdit"));
        }

        private void CancelEdit(object arg)
        {
            LoadContacts();
            EditMode = false;
            VisibilityProperty = false;
        }

        private void Add(object arg)
        {
            VisibilityProperty = true;
            EditMode = true;
            var newContact = new Contact { FirstName = "N/A", Image = "/Images/default-user-image.png" };
            ContactList.Add(newContact);
            SelectedContact = newContact;
        }

        private void Save(object arg)
        {
            dataService.SaveContacts(ContactList);
            editMode = false;
            VisibilityProperty = false;
        }

        private void Delete(object arg)
        {
            ContactList.Remove(SelectedContact);
            dataService.SaveContacts(ContactList);
            //dialogService.ShowMessageBox(LocalizationProvider.GetLocalizedValue<String>("ContactDelete"));
            VisibilityProperty = false;
            EditMode = false;
        }

        private void LogoutButton(object arg)
        {
            OnViewChanged("Login");
        }


        private void LoadContacts()
        {
            ContactList = new ObservableCollection<Contact>(dataService.GetContacts());
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
