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
using LiveCharts.Wpf;

namespace login
{
    /// <summary>
    /// Interaction logic for ChartsView.xaml
    /// </summary>
    public partial class ChartsView : UserControl
    {
        public ChartsView()
        {
            InitializeComponent();
            ChartInitializer();
        }

        private void ChartInitializer()
        {
            this.chart.Series.Add(new LineSeries
            {
                Values = new ChartValues<double> { 2, 6, 7, 9 }

            }); ;
            
        }
    }
}
