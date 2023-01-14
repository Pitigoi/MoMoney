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
    public partial class EntriesView : UserControl
    {
        
        public EntriesView()
        {
            InitializeComponent();
            PayContext c = new PayContext();
            DataGridEntries.ItemsSource = (from a in c.Categories
                                           join b in c.Payments
                                           on a.id equals b.category
                                           where b.uid == PayContext.currentId
                                           select new
                                           {
                                               _name = b.note,
                                               _category = a.name.Trim(),
                                               _value = b.amount,
                                               _date = b.time
                                           }).Union(from b in c.Incomes
                                                    where b.uid == PayContext.currentId
                                                    select new
                                                    {
                                                        _name = b.note,
                                                        _category = "Income",
                                                        _value = b.amount,
                                                        _date = b.time
                                                    }).OrderByDescending(s => s._date).ToList();
        }

        private void NewEntryBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEntryView entryWindow = new AddEntryView();
            entryWindow.Show();
        }
    }
}
