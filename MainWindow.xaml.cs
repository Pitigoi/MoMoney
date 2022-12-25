using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MoMoney.Models;

namespace MoMoney
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PayContext.currentId = 5;
            var c = new PayContext();

            //var test = new ObservableCollection<login>();
            //test.Add(c.Logins.Find(PayContext.currentId));
            //Righttable.ItemsSource = test;

            Righttable.ItemsSource = new ObservableCollection<income>(PayContext.ShowIncome());
            //PayContext.AddCategory("piss");
            //PayContext.AddCategory("jgsdbkv");
            //PayContext.AddUser("a e", "admin", "admin");
            //PayContext.AddIncome(decimal.Parse("1.2"), "wehdfg");
            //PayContext.AddPayment(1, decimal.Parse("1.2"), "poop");
            //PayContext.currentId = 6;
            //PayContext.AddPayment(2, decimal.Parse("4.2"), "poop2");
            //Lefttable.ItemsSource = new ObservableCollection<payments>(PayContext.ShowPayment());
            var result = (from a in c.Categories
                      join b in c.Payments
                      on a.id equals b.category
                      select new
                      {
                          name = a.name.Trim(),
                          b.time,
                          b.amount,
                          b.note
                      }).ToList();
            Lefttable.ItemsSource = result;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Lefttable.ItemsSource = new ObservableCollection<payments>(PayContext.ShowPayment(1));
            var c = new PayContext();
            var result = (from a in c.Categories
                          join b in c.Payments
                          on a.id equals b.category
                          where b.id == 2
                          select new
                          {
                              name = a.name.Trim(),
                              b.time,
                              b.amount,
                              b.note
                          }).ToList();
            Lefttable.ItemsSource = result;
        }
    }
}
