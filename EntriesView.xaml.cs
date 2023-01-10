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
    /// Interaction logic for EntriesView.xaml
    /// </summary>
    public partial class EntriesView : UserControl
    {
        //u can delete Entry class and directly add your data sets to the datagrid
        
        public EntriesView()
        {
            InitializeComponent();

            addData();
        }

        public void addData()   //edit this function so you can add data however u like them from db
        {
            //this.DataGridEntries.Items.Add(new Entry("ioana", "200", "12/2/2020", "groceries"));

            PayContext c = new PayContext();

            DataGridEntries.ItemsSource=(from a in c.Categories
                                         join b in c.Payments
                                         on a.id equals b.category
                                         where b.uid == PayContext.currentId
                                         select new
                                         {
                                             _category = a.name.Trim(),
                                             _date = b.time,
                                             _value = b.amount,
                                             _name = b.note
                                         }).ToList();
        }

        private void NewEntryBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEntryView entryWindow = new AddEntryView();
            
            //here I guess u will initialize the comboBox with the existent categories
            //it will be better suited to edit the below function to take no parameters and load the items directly froom your db
            entryWindow.addComboBoxCategoryItems();
            entryWindow.Show();
        }
    }
}
