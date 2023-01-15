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
        public Func<double,string> XFormatter = value =>  new DateTime((long)value).ToString("g");
        public Func<double,string> YFormatter = value => ((decimal)value).ToString("c");
        public ChartsView()
        {
            InitializeComponent();
            ChartInitializer();
            DataContext = this;

            var dayConfig = Mappers.Xy<Tuple<DateTime, decimal>>()
                          .X(dayModel => (double)dayModel.Item1.Ticks)
                          .Y(dayModel => ((double)dayModel.Item2));

            LiveCharts.Charting.For<Tuple<DateTime, string>>(dayConfig);
            chart.Series=new SeriesCollection(dayConfig);
            //axisx;
            axisx.LabelFormatter = XFormatter;
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

            var at = (from p in c.Payments where p.uid == PayContext.currentId && p.time >= dc1 && p.time <= dc2 select new { p.time,amount=Math.Abs(p.amount) }).OrderByDescending(s => s.time).AsEnumerable().Select(p => new Tuple<DateTime,decimal>(p.time, p.amount));
            var bt = (from i in c.Incomes where i.uid == PayContext.currentId && i.time >= dc1 && i.time <= dc2 select new {  i.time,  i.amount }).OrderByDescending(s => s.time).AsEnumerable().Select(i => new Tuple<DateTime, decimal>(i.time, i.amount));
            this.chart.Series.Clear();
            axisx.MinValue = dc1.Ticks;
            axisx.MaxValue = dc2.Ticks;
            if (at.Count() > 0)
            {
                this.chart.Series.Add(new LineSeries
                {
                    Values = new ChartValues<Tuple<DateTime, decimal>>(at),
                    Name = "Payments"
                });
            }
            if (bt.Count() > 0)
            {
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
            DateTime dt = DateTime.Now.Date;

            var at = (from p in c.Payments where p.uid == PayContext.currentId && p.time >= dt select new {  p.time, amount = Math.Abs(p.amount) }).OrderByDescending(s => s.time).AsEnumerable().Select(p => new Tuple<DateTime, decimal>(p.time, p.amount));
            var bt = (from i in c.Incomes where i.uid == PayContext.currentId && i.time >= dt select new { i.time,  i.amount }).OrderByDescending(s => s.time).AsEnumerable().Select(i => new Tuple<DateTime, decimal>(i.time, i.amount));
            this.chart.Series.Clear();
            axisx.MinValue = dt.Ticks;
            if (at.Count() > 0)
            {
                this.chart.Series.Add(new LineSeries
                {
                    Values = new ChartValues<Tuple<DateTime, decimal>>(at),
                    Name = "Payments"
                });
            }
            if (bt.Count() > 0)
            {
                this.chart.Series.Add(new LineSeries
                {
                    Values = new ChartValues<Tuple<DateTime, decimal>>(bt),
                    Name = "Incomes"
                });
            }
        }

        private void Week_Click(object sender, RoutedEventArgs e)
        {
            PayContext c = new PayContext();
            DateTime dw = DateTime.Now.Date.AddDays((((int)DateTime.Now.DayOfWeek+6)%7)*-1);

            var aw = (from p in c.Payments where p.uid == PayContext.currentId && p.time >= dw select new { p.time, amount = Math.Abs(p.amount) }).OrderByDescending(s => s.time).AsEnumerable().Select(p => new Tuple<DateTime, decimal>(p.time, p.amount));
            var bw = (from i in c.Incomes where i.uid == PayContext.currentId && i.time >= dw select new { i.time, i.amount }).OrderByDescending(s => s.time).AsEnumerable().Select(i => new Tuple<DateTime, decimal>(i.time, i.amount));
            this.chart.Series.Clear();
            axisx.MinValue = dw.Ticks;
            if (aw.Count() > 0)
            {
                this.chart.Series.Add(new LineSeries
                {
                    Values = new ChartValues<Tuple<DateTime, decimal>>(aw),
                    Name = "Payments"
                });
            }
            if (bw.Count() > 0)
            {
                this.chart.Series.Add(new LineSeries
                {
                    Values = new ChartValues<Tuple<DateTime, decimal>>(bw),
                    Name = "Incomes"
                });
            }
        }

        private void Month_Click(object sender, RoutedEventArgs e)
        {
            PayContext c = new PayContext();
            DateTime dl = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            var al = (from p in c.Payments where p.uid == PayContext.currentId && p.time >= dl select new { p.time, amount = Math.Abs(p.amount) }).OrderByDescending(s => s.time).AsEnumerable().Select(p => new Tuple<DateTime, decimal>(p.time, p.amount));
            var bl = (from i in c.Incomes where i.uid == PayContext.currentId && i.time >= dl select new { i.time, i.amount }).OrderByDescending(s => s.time).AsEnumerable().Select(i => new Tuple<DateTime, decimal>(i.time, i.amount));
            this.chart.Series.Clear();
            axisx.MinValue = dl.Ticks;
            if (al.Count() > 0)
            {
                this.chart.Series.Add(new LineSeries
                {
                    Values = new ChartValues<Tuple<DateTime, decimal>>(al),
                    Name = "Payments"
                });
            }
            if (bl.Count() > 0)
            { 
                this.chart.Series.Add(new LineSeries
                {
                    Values = new ChartValues<Tuple<DateTime, decimal>>(bl),
                    Name = "Incomes"
                });
            }
        }

        private void Year_Click(object sender, RoutedEventArgs e)
        {
            PayContext c= new PayContext();
            DateTime da = new DateTime(DateTime.Now.Year, 1, 1);

            var aa = (from p in c.Payments where p.uid == PayContext.currentId && p.time >= da select new { p.time, amount = Math.Abs(p.amount) }).OrderByDescending(s => s.time).AsEnumerable().Select(p => new Tuple<DateTime, decimal>(p.time, p.amount));
            var ba = (from i in c.Incomes where i.uid == PayContext.currentId && i.time >= da select new { i.time, i.amount }).OrderByDescending(s => s.time).AsEnumerable().Select(i => new Tuple<DateTime, decimal>(i.time, i.amount));
            this.chart.Series.Clear();
            axisx.MinValue = da.Ticks;
            if (aa.Count() > 0)
            {
                this.chart.Series.Add(new LineSeries
                {
                    Values = new ChartValues<Tuple<DateTime, decimal>>(aa),
                    Name = "Payments"
                });
            }
            if (ba.Count() > 0)
            {
                this.chart.Series.Add(new LineSeries
                {
                    Values = new ChartValues<Tuple<DateTime, decimal>>(ba),
                    Name = "Incomes"
                });
            }
        }
    }
}
