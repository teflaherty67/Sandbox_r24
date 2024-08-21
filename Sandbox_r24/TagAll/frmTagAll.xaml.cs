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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sandbox_r24
{
    /// <summary>
    /// Interaction logic for Window.xaml
    /// </summary>
    public partial class frmTagAll : Window
    {
        public frmTagAll()
        {
            InitializeComponent();
        }

        internal bool GetCheckBoxDouble()
        {
            if (cbxDblTag.IsChecked == true)
                return true;

            return false;
        }

        internal bool GetCheckBoxDoors()
        {
            if (cbxTagDoors.IsChecked == true)
                return true;

            return false;
        }

        internal bool GetCheckBoxWndws()
        {
            if (cbxTagWndws.IsChecked == true)
                return true;

            return false;
        }

        internal bool GetCheckBoxOpenings()
        {
            if (cbxTagOpenings.IsChecked == true)
                return true;

            return false;
        }

        internal bool GetCheckBoxRooms()
        {
            if (cbxTagRooms.IsChecked == true)
                return true;

            return false;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}