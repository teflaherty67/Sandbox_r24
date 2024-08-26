using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for frmRenumber.xaml
    /// </summary>
    public partial class frmRenumber : Window
    {

        ObservableCollection<string> listRenumElems { get; set; }

        public frmRenumber(List<string> catList)
        {
            InitializeComponent();

            listRenumElems = new ObservableCollection<string>(catList);

            lbxReNumElem.ItemsSource = listRenumElems;
        }

        // add code for radio button result

        // add code for textbox result

        
        internal bool GetCheckBoxExclude()
        {
            if (cbxExclude.IsChecked == true)
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
