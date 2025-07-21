using System;
using System.Windows;
using BusinessObjects;
using Services;

namespace PhanLeHuyWpf
{
    /// <summary>
    /// Interaction logic for UpdateCustomerDialog.xaml
    /// </summary>
    public partial class UpdateCustomerDialog : Window
    {
        private CustomerService cs = new CustomerService();
        private InputValidator iv = new InputValidator();
        public UpdateCustomerDialog(Customer existingCustomer)
        {
            InitializeComponent();

            txtCustomerId.Text = existingCustomer.CustomerId.ToString();
            txtCompany.Text = existingCustomer.CompanyName;
            txtContactName.Text = existingCustomer.ContactName;
            txtContactTitle.Text = existingCustomer.ContactTitle;
            txtAddress.Text = existingCustomer.Address;
            txtPhone.Text = existingCustomer.Phone;

            txtCustomerId.IsReadOnly = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(!iv.isPhoneValidation(txtPhone.Text))
            {
                MessageBox.Show("Thong tin khong hop le");
                return;
            }
            try
            {
                Customer customer = new Customer
                {
                    CustomerId = int.Parse(txtCustomerId.Text),
                    CompanyName = txtCompany.Text,
                    ContactName = txtContactName.Text,
                    ContactTitle = txtContactTitle.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text
                };

                if (cs.UpdateCustomer(customer))
                {
                    DialogResult = true;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
