using MoMoney.Models;
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
    /// Interaction logic for AddEntryView.xaml
    /// </summary>
    public partial class AddEntryView : Window
    {
        public AddEntryView()
        {
            InitializeComponent();
            PayContext c = new PayContext();
            CategoryComboBox.ItemsSource =(from a in c.Categories select a.name).ToList();
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

        public void addComboBoxCategoryItems()
        {
            //this.CategoryComboBox.Items.Add(category);
            PayContext c = new PayContext();
            CategoryComboBox.ItemsSource = (from a in c.Categories
                                            select  a.name.Trim()
                                            ).ToList();
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {

            //here u do the magic to add the new entry to the db and the datagrid
            // use this.txtAmount.Text to get the amount of money
            // use this.txtDate.Text to get the date
            // use this.txtDescription.Text to get the description (ex: sold my latop; got money for xmas, etc)
            PayContext c = new PayContext();
            //txtAmount.Text

            //PayContext.AddPayment(category, float.Parse(txtAmount.Text.ToString()), this.txtDescription.Text.ToString(), DateTime.Parse(txtDate.Text));
            
            this.Close();

        }
    }
}
