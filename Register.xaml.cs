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

namespace login
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        string username;
        string password;
        public Register()
        {
            InitializeComponent();
           
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private bool checkPassword(string check)
        {
            if (password != check)
            {
                Error.Visibility = Visibility.Visible;
                txtPass.Clear();
                txtPassConfirm.Clear();

                return false;
            }

            return true;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            username = txtUser.Text;
            password = txtPass.Password;
            string check = txtPassConfirm.Password;

            if (password != check)
            {
                Error.Visibility = Visibility.Visible;
                txtPass.Clear();
                txtPassConfirm.Clear();
                
            }
            else
            {
                Error.Visibility = Visibility.Hidden;
                Dashboard objDashWindow = new Dashboard();
               // this.Hide();
                objDashWindow.Show();

            }

            //to do: save in db user and pass;
        }
    }
}
