using MoMoney.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
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

namespace MoMoney
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            
            //btnClose
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
            //txtUser;
            int warn = 0;
            if (!IsValid(txtUser.Text.ToString()))
                warn++;
            if (!IsValid(txtPass.Password.ToString()))
                warn++;
            PayContext c = new PayContext();
            var result = (from a in c.Logins
                          where a.username.Trim() == txtUser.Text.ToString() && 
                          a.password.Trim() == txtPass.Password.ToString()
                          select new {a.id}).ToList()[0];
            PayContext.currentId = result.id;
            this.Close();
        }
    }
    
}