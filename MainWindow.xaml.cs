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

namespace login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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
        public bool IsValid(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                    return false;
            }
            return true;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //  here u can add the code to be done when the login is pressed
            if (!IsValid(txtUser.Text.ToString()) || !IsValid(txtPass.Password.ToString()))
            {
                txtUser.Clear();
                txtPass.Clear();
            }

            PayContext c = new PayContext();
            var result = (from a in c.Logins
                          where a.username.Trim() == txtUser.Text &&
                          a.password.Trim() == txtPass.Password
                          select new { a.id }).ToList();
            if (result.Count != 0)
            {
                PayContext.currentId = result[0].id;
                Dashboard objDashWindow = new Dashboard();
                this.Close();
                objDashWindow.Show();
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register objRegWindow = new Register();
            this.Close();
            objRegWindow.Show();
        }


    }
}
