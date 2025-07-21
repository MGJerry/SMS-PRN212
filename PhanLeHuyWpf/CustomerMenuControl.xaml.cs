using BusinessObjects;
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

namespace PhanLeHuyWpf
{
    /// <summary>
    /// Interaction logic for CustomerMenuControl.xaml
    /// </summary>
    public partial class CustomerMenuControl : UserControl
    {
        public CustomerMenuControl()
        {
            InitializeComponent();
        }
        public Customer currentCustomer { get; set; }

        private void mnuAccount_Click(object sender, RoutedEventArgs e)
        {
            ProfileManagement pm = new ProfileManagement(currentCustomer);
            pm.Show();
            Window.GetWindow(this)?.Close();
        }

        private void mnuOrders_Click(object sender, RoutedEventArgs e)
        {
            CustomerOrderWindow cow = new CustomerOrderWindow(currentCustomer);
            cow.Show();
            Window.GetWindow(this)?.Close();
        }

        private void mnuLogout_Click(object sender, RoutedEventArgs e)
        {
            CustomerLogin cl = new CustomerLogin();
            cl.Show();
            Window.GetWindow(this)?.Close();
        }
    }
}
