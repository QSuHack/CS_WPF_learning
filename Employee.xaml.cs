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

namespace WpfApp2
{
    /// <summary>
    /// Logika interakcji dla klasy Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        double cost_of_getting_income = 111.25;
        double pit_2 = 46.33;
        public Employee()
        {
            InitializeComponent();
        }
           
        private void Cost_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.SalaryGrossText.IsEnabled = false;
            double SalaryGross, PIT;
            try
            {
                SalaryGross = Double.Parse(this.SalaryGrossText.Text);
                double pension_contribution = Math.Round(SalaryGross * 0.0976, 2);
                double renta_contribution = Math.Round(SalaryGross * 0.015, 2);
                double disease_contribution = Math.Round(SalaryGross * 0.0245, 2);
                this.PensionBox.Text = pension_contribution.ToString();
                this.RentaBox.Text = renta_contribution.ToString();
                this.DiseaseBox.Text = disease_contribution.ToString();
                SalaryGross -= pension_contribution + renta_contribution + disease_contribution;
                double health_contribution = Math.Round(SalaryGross * 0.09, 2);
                double health_contribution_income = Math.Round(SalaryGross * 0.0775, 2); // 7,75%
                this.HealthCareBox.Text = health_contribution.ToString();
                SalaryGross -=  cost_of_getting_income;
                SalaryGross = Math.Round(SalaryGross, 0);
                if (SalaryGross*12 < 85528)
                {
                    PIT = Math.Round(Math.Round((SalaryGross ) * 0.18, 2) - pit_2 - health_contribution_income,0);
                    if (PIT < 0)
                        PIT = 0;
                    this.Tax_1Box.Text = PIT.ToString();
                }
                else
                {
                    PIT = SalaryGross; //TODO 32% podatku
                }
                SalaryGross = Double.Parse(this.SalaryGrossText.Text);
                this.SalaryNetText.Text = (SalaryGross - pension_contribution - renta_contribution - disease_contribution -health_contribution - PIT).ToString();

            }
            catch (FormatException)
            {
                MessageBox.Show("Popraw dane");
            }
            this.SalaryGrossText.IsEnabled = true;
        }

        private void WorkingNearHomeCheckbox_Checked(object sender, RoutedEventArgs e)
        {

            if ((bool)this.WorkingNearHomeCheckbox.IsChecked)
            {
                cost_of_getting_income = 111.25;
            }
            else
            {
                cost_of_getting_income = 139.06;
            }
        }

        private void SuppliedPIT2Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)this.SuppliedPIT2Checkbox.IsChecked)
            {
                pit_2 = 46.33;
            }
            else
            {
                pit_2 = 0;
            }
        }
    }
}
