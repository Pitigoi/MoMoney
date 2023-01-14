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

        //change this function to suit u, i guess u ll be using a list as a parameter or idk
        public void addComboBoxCategoryItems(string category)
        {
            this.CategoryComboBox.Items.Add(category);
        }
        public Entry ReturnFromSaveBtn()
        {
            string categ = this.CategoryComboBox.SelectedItem.ToString();
            string value = this.txtAmount.Text;
            DateTime date = this.DateBox.SelectedDate.Value.Date;
           // string date = this.txtDate.Text;
            string desc = this.txtDescription.Text;
            return new Entry(desc, value, date, categ);

        }
        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            
            //here u do the magic to add the new entry to the db and the datagrid
            // use this.txtAmount.Text to get the amount of money
            // use this.txtDate.Text to get the date
            // use this.txtDescription.Text to get the description (ex: sold my latop; got money for xmas, etc)
            
            
            this.Close();

        }
    }
}
