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
            LoadBudgetInfoCardNumberValues("700", "777", "1111");
             //AddCategories();
              PieChartInitializer();
           

        }

        //add your link to the database here and the functions to compute the totals so you can display these values ^
        private void LoadBudgetInfoCardNumberValues(string budget, string income, string expense)
        {
            this.budget.Number = budget;
            this.income.Number = income;
            this.expense.Number = expense;
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


            LiveCharts.SeriesCollection psc = new LiveCharts.SeriesCollection { };
            /*
            for(int i =0;i<categories.Count();i++)
            {
                psc.Add(
                new PieSeries
                {
               Title = categories[i],
               Values = new ChartValues<double> {usage[i] },
               DataLabels = true,

               //Fill = System.Windows.Media.Brushes.Gray
                });
            }*/
            psc.Add(
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
                });



            //THIS STAYS HERE
            foreach (LiveCharts.Wpf.PieSeries ps in psc)
                {
                    myPieChart.Series.Add(ps);
                }
           
        }
        



    }
}
