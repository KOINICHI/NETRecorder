using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace NETRecorder
{
    public partial class MainWindow : System.Windows.Window
    {
        DispatcherTimer timer;
        int updateInterval = 1000;
        void AddEventHandlers()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, updateInterval);
            timer.Tick += timer_Tick;
            timer.Start();
            Timer_Tick_Func();

            ExitButtonImage.Click += ExitButtonImage_Click;
            SettingButtonImage.Click += SettingButtonImage_Click;
            MinimizeButtonImage.Click += MinimizeButtonImage_Click;
            RefreshButtonImage.Click += RefreshButtonImage_Click;

            UpdateIntervalTextBox.TextChanged += UpdateIntervalTextBox_TextChanged;

            SettingAnimationSetup();
        }

        void UpdateIntervalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            double n;
            try {
                n = Convert.ToDouble(tb.Text);
            }
            catch {
                n = 0;
            }
            UpdateIntervalUnitLabel.Content = "Second" + ((n != 1) ? "s" : "");
        }

        private Storyboard settingSB;
        private ThicknessAnimation settingTA;

        void SettingAnimationSetup()
        {
            settingTA = new ThicknessAnimation();
            settingSB = new Storyboard();

            settingTA.From = new Thickness(0, 140, 0, 0);
            settingTA.To = new Thickness(0, 0, 0, 0);
            settingTA.Duration = new Duration(TimeSpan.FromSeconds(0.1));


            settingSB.Children.Add(settingTA);
            Storyboard.SetTargetName(settingTA, SettingLayout.Name);
            Storyboard.SetTargetProperty(settingTA, new PropertyPath(Grid.MarginProperty));
        }


        void SettingButtonImage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try {
                updateInterval = Convert.ToInt32(Convert.ToDouble(UpdateIntervalTextBox.Text) * 1000);
            }
            catch { }
            settingSB.Begin(this);
            Thickness? temp = settingTA.From;
            settingTA.From = settingTA.To;
            settingTA.To = temp;
            timer.Interval = new TimeSpan(0, 0, 0, 0, updateInterval);
        }


        void RefreshButtonImage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            trafficCalculator.RefreshOffset();
        }

        void MinimizeButtonImage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }


        void timer_Tick(object sender, EventArgs e) { Timer_Tick_Func(); }
        void Timer_Tick_Func()
        {
            TotalDownloadLabel.Content = Format(trafficCalculator.GetTotalDL());
            TotalUploadLabel.Content = Format(trafficCalculator.GetTotalUL());
            DownloadSpeedLabel.Content = Format(trafficCalculator.GetDLSpeed()) + "/s";
            UploadSpeedLabel.Content = Format(trafficCalculator.GetULSpeed()) + "/s";
        }

        void ExitButtonImage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
            tray.Dispose();
        }
    }
}
