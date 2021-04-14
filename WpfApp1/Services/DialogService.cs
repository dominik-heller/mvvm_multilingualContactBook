using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContactBook.Helper
{
    public class DialogService : IDialogService
    {
        public string OpenFile()
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                return dialog.FileName;
            }

            return null;
        }

        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }
    }
}
