using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using LiveCharts;
using LiveCharts.Wpf;


namespace login
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        
        public List<string> categories { get; set; }
        public List<double> usage { get; set; }

        public HomeView()
        {
            

            InitializeComponent();
            



            LoadBudgetInfoCardNumberValues();
            //AddCategories();
            PieChartInitializer();    
           

        }

        //add your link to the database here and the functions to compute the totals so you can display these values ^
        private void LoadBudgetInfoCardNumberValues()
        {
            PayContext c = new PayContext();
            var a = (from p in c.Payments where p.uid == PayContext.currentId select Math.Abs(p.amount)
                ).ToList().Sum();
            var b = (from i in c.Incomes
                     where i.uid == PayContext.currentId
                     select i.amount
                ).ToList().Sum();
            ///pentru luna,an
            /*
            DateTime dl = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            var al = (from p in c.Payments where p.uid == PayContext.currentId && p.time >= dl select Math.Abs(p.amount)
                ).ToList().Sum();
            var bl = (from i in c.Incomes
                      where i.uid == PayContext.currentId && i.time >= dl
                      select i.amount
                ).ToList().Sum();

            DateTime da = new DateTime(DateTime.Now.Year, 1, 1);

            var aa = (from p in c.Payments where p.uid == PayContext.currentId && p.time >= da select Math.Abs(p.amount)
                ).ToList().Sum();
            var ba = (from i in c.Incomes
                      where i.uid == PayContext.currentId && i.time >= da
                      select i.amount
                ).ToList().Sum();*/
            this.budget.Number = (b - a).ToString("c");
            this.income.Number = b.ToString("c");
            this.expense.Number = a.ToString("c");
        }

        public void AddCategories(List<string> categs)
        {
           
            categories = new List<string> { "groceries", "home", "bills" };

           // this.categories = categs;
        }

        public void AddUsageOfCategories(List<double> usage)
        {
            this.usage = new List<double> { 20, 70, 10 };

            //this.usage = usage;
        }
        
        private void PieChartInitializer()
        {
            PayContext c=new PayContext();
            var categories = (from p in c.Categories select p.name.Trim()
               ).ToList();
            var usage = (from p in c.Categories select (decimal)p.id).ToList();
              
            //for
            //= (from p in c.Payments where p.uid == PayContext.currentId select p.amount
            //   ).ToList();

            LiveCharts.SeriesCollection psc = new LiveCharts.SeriesCollection { };
            
            for(int i =0;i<categories.Count();i++)
            {
                usage[i] = (from p in c.Payments where p.id == i select p.amount).ToList().Sum();
                if (usage[i] != 0)
                {
                    psc.Add(
                    new PieSeries
                    {
                        Title = categories[i],
                        Values = new ChartValues<decimal> { usage[i] },
                        DataLabels = true,

                        //Fill = System.Windows.Media.Brushes.Gray
                    });
                }
            }

            /*psc.Add(
                new PieSeries
                {
                    Title = "bills",
                    Values = new ChartValues<double> { 20 },
                    DataLabels = true,

                    //Fill = System.Windows.Media.Brushes.Gray

                });
            psc.Add(
                new PieSeries
                {
                    Title = "GROCERIES",
                    Values = new ChartValues<double> { 80 },
                    DataLabels = true,

                    //Fill = System.Windows.Media.Brushes.Gray
                });*/



            //THIS STAYS HERE
            foreach (LiveCharts.Wpf.PieSeries ps in psc)
                {
                    myPieChart.Series.Add(ps);
                }
           
        }
        



    }
}
