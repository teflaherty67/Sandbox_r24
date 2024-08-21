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
    public partial class frmTagSelectedViews : Window
    {
        public frmTagSelectedViews()
        {
            InitializeComponent();

            // create list of tag orientations
            List<string> listTagOrients = new List<string> { "Horizontal", "Vertical" };

            // populate the orientation combobox
            foreach (string tagOrient in listTagOrients)
            {
                cmbOrientation.Items.Add(tagOrient);
            }

            cmbOrientation.SelectedIndex = 0;
        }

        private void cbxLeader_Checked(object sender, RoutedEventArgs e)
        {
            // if checked make length text box active

            Controls.CheckBox cBox = (Controls.CheckBox)sender;

            if (cBox.IsChecked == true) { tbxLength.IsEnabled = true; }
        }

        internal bool GetCheckBoxLeader()
        {
            if (cbxLeader.IsChecked == true)
                return true;

            return false;
        }

        internal double GetTextBoxLength()
        {
            return tbxLength.Text.Length;
        }

        internal string GetComboboxOrient()
        {
            return cmbOrientation.Text.ToString();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {

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