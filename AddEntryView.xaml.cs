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
    public partial class AddEntryView : Window
    {
        public AddEntryView()
        {
            InitializeComponent();
            PayContext c = new PayContext();
            CategoryComboBox.ItemsSource =(from a in c.Categories select a.name.Trim()).ToList();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {

            //here u do the magic to add the new entry to the db and the datagrid
            // use this.txtAmount.Text to get the amount of money
            // use this.txtDate.Text to get the date
            // use this.txtDescription.Text to get the description (ex: sold my latop; got money for xmas, etc)
            PayContext c = new PayContext();
            decimal val = decimal.Parse(txtAmount.Text.ToString());
            if (CategoryComboBox.SelectedIndex!=-1)
            {
                int categid= (from a in c.Categories
                              select a.id).ToList()[CategoryComboBox.SelectedIndex];
                if (val > 0)
                    val = -val;
                PayContext.AddPayment(categid, val, txtDescription.Text, DateTime.Parse(txtDate.Text));
                Close();
            }
            else if(val>0)
            {
                PayContext.AddIncome(val, txtDescription.Text, DateTime.Parse(txtDate.Text));
                Close();
            }
            else
            {
                txtAmount.Text.Remove(0,1);
            }
        }
    }
}
