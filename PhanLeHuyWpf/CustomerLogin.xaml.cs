using BusinessObjects;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace PhanLeHuyWpf
{
    /// <summary>
    /// Interaction logic for CustomerLogin.xaml
    /// </summary>
    public partial class CustomerLogin : Window
    {
        CustomerService cs = new CustomerService();
        InputValidator iv = new InputValidator();
        List<Customer> customers = new List<Customer>();    
        public CustomerLogin()
        {
            InitializeComponent();
            cs.GenerateSampleDataset();
            customers = cs.GetCustomers();
            RestoreLoginInformation();
        }

        private void btnCustomerLogin_Click(object sender, RoutedEventArgs e)
        {
            string phone = txtPhone.Text;
            if(!iv.isPhoneValidation(phone))
            {
                MessageBox.Show("So dien thoai khong hop le");
            }
            Customer c = customers.FirstOrDefault(cus => cus.Phone.Equals(phone));

            if (c != null) {
                CustomerMainForm cmf = new CustomerMainForm(c);
                cmf.Show();
                Close();
                SaveLoginInformation(c, chkSaveInfor.IsChecked.Value);
            }else
            {
                MessageBox.Show("So dien thoai dang nhap sai hoac khong ton tai");
                return;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Ban muon dang xuat?", "Xac nhan dang xuat", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mbr == MessageBoxResult.No)
            {
                return;
            }

            Welcome w = new Welcome();
            w.Show();
            Close();
        }

        private void RestoreLoginInformation()
        {
            string log_file = "cuslogin_log.txt";
            if (File.Exists(log_file))
            {//nếu có tồn tại file này:
                StreamReader sr = new StreamReader(log_file);
                string line = sr.ReadLine();
                sr.Close();
                //tách line thành 3 thông tin: email; password; save
                string[] arrData = line.Split(';');
                if (arrData.Length == 2 && arrData[1] == "True")
                {
                    txtPhone.Text = arrData[0];
                    chkSaveInfor.IsChecked = true;
                }
            }
        }

        void SaveLoginInformation(Customer cus, bool saved)
        {
            string infor = cus.Phone + ";" + saved;
            StreamWriter sw = new StreamWriter("cuslogin_log.txt", false, Encoding.UTF8);
            sw.WriteLine(infor);
            sw.Close();
        }
    }
}
