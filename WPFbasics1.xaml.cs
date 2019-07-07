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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.NoteText == null)
            {
                return;
            }
            var combo = (ComboBox)sender;
            var value = (ComboBoxItem)combo.SelectedValue;
            this.NoteText.Text = (string) value.Content;
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The description is: {this.DescriptionText.Text}");
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            this.WeldCheckbox.IsChecked = this.AssemblyCheckbox.IsChecked = this.DrillCheckbox.IsChecked
                = this.FoldCheckbox.IsChecked = this.LaserCheckbox.IsChecked = this.LatheCheckbox.IsChecked = this.PlasmaCheckbox.IsChecked
                = this.PurchaseCheckbox.IsChecked = this.RollCheckbox.IsChecked = this.SawCheckbox.IsChecked = false;
            this.LengthTextBox.Text = "";
            this.MassText.Text = "";
            this.NoteText.Text = "";
            this.DescriptionText.Text = "";
        }

        private void Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            this.LengthTextBox.Text += (string) ((CheckBox)sender).Content; 
        }

      
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox_SelectionChanged(this.FinishComboBox, null);
        }

        private void SupplierNameText_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.MassText.Text += SupplierNameText.Text; 
        }
    }
}
