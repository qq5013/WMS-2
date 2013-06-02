using System;
using System.Windows;
using System.Windows.Threading;

namespace MES.Board
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var timer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 1)};
            timer.Tick += TimeUp;
            timer.Start();
        }

        private int k = 100;
        private void TimeUp(object sender, EventArgs e)
        {
            LblPlanQuantity.Content = (k ++).ToString();
        }
    }
}