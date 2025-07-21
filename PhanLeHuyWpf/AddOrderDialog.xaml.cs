using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for OrderDialog.xaml
    /// </summary>
    public partial class OrderDialog : Window
    {
        private OrderService os = new OrderService();
        private InputValidator iv = new InputValidator();
        public OrderDialog()
        {
            InitializeComponent();
        }

        private Order CreateOrderFromForm()
        {
            int cid = int.Parse(txtCustomerId.Text);
            int eid = int.Parse(txtEmployeeId.Text);
            int oid = int.Parse(txtOrderId.Text);

            if (iv.IsCustomerIdExist(cid) || !iv.IsEmployeeIdExist(eid) || !iv.IsOrderIdExist(oid))
            {
                return null;
            }

            return new Order
            {
                OrderId = int.Parse(txtOrderId.Text),
                CustomerId = int.Parse(txtCustomerId.Text),
                EmployeeId = int.Parse(txtEmployeeId.Text),
                OrderDate = dpOrderDate.SelectedDate ?? DateTime.Now
            };
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = CreateOrderFromForm();
                if (order == null)
                {
                    MessageBox.Show("Thong tin nhap khong hop le");
                    return;
                }
                bool isSuccess = os.AddOrder(order);
                if (isSuccess)
                {
                    DialogResult = true;
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Khong the them don hang vui long kiem tra thong tin");
            }
        }
    }
}
