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
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;

namespace login
{
    /// <summary>
    /// Interaction logic for ChartsView.xaml
    /// </summary>
    public partial class ChartsView : UserControl
    {
        public long MinVal;
        public Func<double,string> XFormatter = value =>  new DateTime((long)value).ToString("g");
        public Func<double,string> YFormatter = value => ((decimal)value).ToString("c");
        public ChartsView()
        {
            InitializeComponent();
            ChartInitializer();
            DataContext = this;
            MinVal= 0;

            var dayConfig = Mappers.Xy<Tuple<DateTime, decimal>>()
                          .X(dayModel => (double)dayModel.Item1.Ticks)
                          .Y(dayModel => ((double)dayModel.Item2));

            LiveCharts.Charting.For<Tuple<DateTime, string>>(dayConfig);
            //axisx;
            axisy.LabelFormatter = YFormatter;
            dateend.SelectedDate = datestart.SelectedDate = DateTime.Now.Date;
        }

        private void ChartInitializer()
        {
            this.chart.Series.Add(new LineSeries
            {
                Values = new ChartValues<double> { 2, 6, 7, 9 }

            }); ;
            
        }

        private void Custom_Click(object sender, RoutedEventArgs e)
        {
            PayContext c = new PayContext();
            DateTime dc1 =(DateTime)datestart.SelectedDate;
            DateTime dc2 = ((DateTime)dateend.SelectedDate).AddDays(1);

            var at = (from p in c.Payments where p.uid == PayContext.currentId && p.time >= dc1 && p.time <= dc2 select new { time=p.time,amount=Math.Abs(p.amount) }).AsEnumerable().Select(p => new Tuple<DateTime,decimal>(p.time, p.amount));
            var bt = (from i in c.Incomes where i.uid == PayContext.currentId && i.time >= dc1 && i.time <= dc2 select new { time = i.time, amount = i.amount }).AsEnumerable().Select(i => new Tuple<DateTime, decimal>(i.time, i.amount));
            this.chart.Series.Clear();
            if (at.Count() > 0)
            {
                MinVal = at.AsEnumerable().Select(s => s.Item1.Ticks).Min();
                this.chart.Series.Add(new LineSeries
                {
                    Values = new ChartValues<Tuple<DateTime, decimal>>(at),
                    Name = "Payments"
                });
                this.chart.Series.Add(new LineSeries
                {
                    Values = new ChartValues<Tuple<DateTime, decimal>>(bt),
                    Name = "Incomes"
                });
            }
        }

        private void Today_Click(object sender, RoutedEventArgs e)
        {
            PayContext c = new PayContext();
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            var at = (from p in c.Payments where p.uid == PayContext.currentId && p.time >= dt select Math.Abs(p.amount)).ToList();
            var bt = (from i in c.Incomes where i.uid == PayContext.currentId && i.time >= dt select i.amount).ToList();
            this.chart.Series.Clear();
            this.chart.Series.Add(new LineSeries
            {
                Values = new ChartValues<decimal>(at),
                Name = "Payments"
            });
            this.chart.Series.Add(new LineSeries
            {
                Values = new ChartValues<decimal>(bt),
                Name = "Incomes"
            });
        }

        private void Week_Click(object sender, RoutedEventArgs e)
        {
            PayContext c = new PayContext();
            DateTime dw = DateTime.Now.Date.AddDays((1 - (int)DateTime.Now.DayOfWeek) % 7);

            var aw = (from p in c.Payments where p.uid == PayContext.currentId && p.time >= dw select Math.Abs(p.amount)).ToList();
            var bw = (from i in c.Incomes where i.uid == PayContext.currentId && i.time >= dw select i.amount).ToList();
            this.chart.Series.Clear();
            this.chart.Series.Add(new LineSeries
            {
                Values = new ChartValues<decimal>(aw),
                Name = "Payments"
            });
            this.chart.Series.Add(new LineSeries
            {
                Values = new ChartValues<decimal>(bw),
                Name = "Incomes"
            });
        }

        private void Month_Click(object sender, RoutedEventArgs e)
        {
            PayContext c = new PayContext();
            DateTime dl = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            var al = (from p in c.Payments where p.uid == PayContext.currentId && p.time >= dl select Math.Abs(p.amount)).ToList();
            var bl = (from i in c.Incomes where i.uid == PayContext.currentId && i.time >= dl select i.amount).ToList();
            this.chart.Series.Clear();
            this.chart.Series.Add(new LineSeries
            {
                Values = new ChartValues<decimal>(al),
                Name = "Payments"
            });
            this.chart.Series.Add(new LineSeries
            {
                Values = new ChartValues<decimal>(bl),
                Name = "Incomes"
            });
        }

        private void Year_Click(object sender, RoutedEventArgs e)
        {
            PayContext c= new PayContext();
            DateTime da = new DateTime(DateTime.Now.Year, 1, 1);

            var aa = (from p in c.Payments where p.uid == PayContext.currentId && p.time >= da select Math.Abs(p.amount)).ToList();
            var ba = (from i in c.Incomes where i.uid == PayContext.currentId && i.time >= da select i.amount).ToList();
            this.chart.Series.Clear();
            this.chart.Series.Add(new LineSeries
            {
                Values = new ChartValues<decimal>(aa),
                Name = "Payments"
            });
            this.chart.Series.Add(new LineSeries
            {
                Values = new ChartValues<decimal>(ba),
                Name = "Incomes"
            });
        }
    }
}
