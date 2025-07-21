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
using BusinessObjects;
using Services;

namespace PhanLeHuyWpf
{
    /// <summary>
    /// Interaction logic for OrderUpdateDialog.xaml
    /// </summary>
    public partial class OrderUpdateDialog : Window
    {
        OrderService os = new OrderService();
        InputValidator iv = new InputValidator();
        public OrderUpdateDialog(Order existingOrder)
        {
            InitializeComponent();

            txtOrderId.Text = existingOrder.OrderId.ToString();
            txtCustomerId.Text = existingOrder.CustomerId.ToString();
            txtEmployeeId.Text = existingOrder.EmployeeId.ToString();
            dpOrderDate.SelectedDate = existingOrder.OrderDate;

            txtOrderId.IsReadOnly = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int cid = int.Parse(txtCustomerId.Text);
                int eid = int.Parse(txtEmployeeId.Text);
                int oid = int.Parse(txtOrderId.Text);

                if(iv.IsCustomerIdExist(cid) || !iv.IsEmployeeIdExist(eid) || !iv.IsOrderIdExist(oid))
                {
                    return;
                }

                Order order = new Order
                {
                    OrderId = int.Parse(txtOrderId.Text),
                    CustomerId = int.Parse(txtCustomerId.Text),
                    EmployeeId = int.Parse(txtEmployeeId.Text),
                    OrderDate = dpOrderDate.SelectedDate ?? DateTime.Now
                };
                
                if(os.UpdateOrder(order))
                {
                    DialogResult = true;
                    Close();
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
