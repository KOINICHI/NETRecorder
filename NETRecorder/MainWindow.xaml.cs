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
using System.Threading;

namespace NETRecorder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TrafficCalculator trafficCalculator;
        public MainWindow()
        {
            InitializeComponent();
            try {
                trafficCalculator = new TrafficCalculator();
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
                this.Close();
                return;
            }


            AddEventHandlers();
            MakeDraggable();
            initTray();
        }



        string[] units = new string[] { "B", "KB", "MB", "GB", "TB", "PB" };
        string Format(long n)
        {
            int count = 0;
            double m = Convert.ToDouble(n);
            while (m > 999) {
                if (count == 5) { break; }
                m /= 1024;
                count++;
            }
            int precision = 0;
            if (m < 10) { precision = 2; }
            else if (m < 100) { precision = 1; }
            
            return String.Format(String.Format("{{0:F{0}}} {{1}}", precision), m, units[count]);
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tray.Dispose();
        }
    }
}
