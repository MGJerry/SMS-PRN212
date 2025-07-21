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
    /// Interaction logic for EmployeeLogin.xaml
    /// </summary>
    public partial class EmployeeLogin : Window
    {
        EmployeeService employeeService = new EmployeeService();
        List<Employee> employees = new List<Employee>();
        public EmployeeLogin()
        {
            InitializeComponent();
            employeeService.GenerateSampleDataset();
            employees = employeeService.GetEmployees();
            RestoreLoginInformation();
        }

        private void btnEmployeeLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            Employee emp = employees.FirstOrDefault(e => e.UserName.Equals(username) && e.Password.Equals(password));

            if (emp != null)
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                Close();

                SaveLoginInformation(emp, chkSaveInfor.IsChecked.Value);
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
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
            string log_file = "login_log.txt";
            if (File.Exists(log_file))
            {//nếu có tồn tại file này:
                StreamReader sr = new StreamReader(log_file);
                string line = sr.ReadLine();
                sr.Close();
                //tách line thành 3 thông tin: email; password; save
                string[] arrData = line.Split(';');
                if (arrData.Length == 3 && arrData[2] == "True")
                {
                    txtUsername.Text = arrData[0];
                    txtPassword.Password = arrData[1];
                    chkSaveInfor.IsChecked = true;
                }
            }
        }

        void SaveLoginInformation(Employee emp, bool saved)
        {
            string infor = emp.UserName + ";" + emp.Password + ";" + saved;
            StreamWriter sw = new StreamWriter("login_log.txt", false, Encoding.UTF8);
            sw.WriteLine(infor);
            sw.Close();
        }
    }
}
