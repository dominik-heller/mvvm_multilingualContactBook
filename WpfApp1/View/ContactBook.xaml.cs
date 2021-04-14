using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactBook.View
{
    /// <summary>
    /// Interaction logic for ContactBook.xaml
    /// </summary>
    public partial class ContactBook : UserControl
    {
        public ContactBook()
        {
            InitializeComponent();
        }

        private void Canvas_MouseEnter(object sender, MouseEventArgs e)
        {
            Canvas doc = (Canvas)sender;

            DoubleAnimation ani = new DoubleAnimation(1, TimeSpan.FromSeconds(0.5));

            doc.BeginAnimation(Canvas.OpacityProperty, ani);
        }

        private void Canvas_MouseLeave(object sender, MouseEventArgs e)
        {
            Canvas doc = (Canvas)sender;

            DoubleAnimation ani = new DoubleAnimation(0.4, TimeSpan.FromSeconds(0.5));

            doc.BeginAnimation(Canvas.OpacityProperty, ani);
        }
    }
}
