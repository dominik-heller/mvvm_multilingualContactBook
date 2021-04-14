using ContactBook.Helper;
using ContactBook.Model;
using ContactBook.Services;
using ContactBook.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace ContactBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            var dataService = new DataService();
            var dialogService = new DialogService();
            var signupVM = new SignupViewModel(dataService, dialogService);
            var loginVM = new LoginViewModel(dataService, dialogService);
            var contactbookVM = new ContactBookViewModel(dataService, dialogService);
            var appVM = new AppViewModel(signupVM, loginVM, contactbookVM);
            DataContext = appVM;
            InitializeComponent();
        }

        //animace, týkají se GUI, takže zde  být mohou
        private void DockPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            DockPanel doc = (DockPanel)sender;

            DoubleAnimation ani = new DoubleAnimation(1, TimeSpan.FromSeconds(0.5));

            doc.BeginAnimation(DockPanel.OpacityProperty, ani);
        }

        private void DockPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            DockPanel doc = (DockPanel)sender;

            DoubleAnimation ani = new DoubleAnimation(0.2, TimeSpan.FromSeconds(0.5));

            doc.BeginAnimation(DockPanel.OpacityProperty, ani);

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

               //le throw;
            }
        }
    }
}
