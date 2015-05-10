using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.IO;

namespace NETRecorder
{
    public class TrafficCalculator
    {
        long OffsetDL=0, OffsetUL=0;
        List<long> PrevDL, PrevUL;
        int TickInterval = 100;
        string data_filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"NETRecorder\data.txt");
        NetworkInterface[] NetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

        public long TotalDL = 0, TotalUL = 0;
        public long DLSpeed = 0, ULSpeed = 0;

        public TrafficCalculator()
        {
            if (!NetworkInterface.GetIsNetworkAvailable()) {
                throw new Exception("Not Connected to any network");
            }

            PrevDL = new List<long>();
            PrevUL = new List<long>();

            if (!Directory.Exists(Path.GetDirectoryName(data_filename))) {
                Directory.CreateDirectory(Path.GetDirectoryName(data_filename));
            }
            if (!File.Exists(data_filename)) {
                File.Create(data_filename).Dispose();
            }
            using (StreamReader reader = new StreamReader(data_filename)) {
                if (!(reader.Peek() < 0)) {
                    OffsetDL = Convert.ToInt64(reader.ReadLine());
                    OffsetUL = Convert.ToInt64(reader.ReadLine());
                }
                else {
                    foreach (NetworkInterface ni in NetworkInterfaces) {
                        OffsetUL += ni.GetIPv4Statistics().BytesSent;
                        OffsetDL += ni.GetIPv4Statistics().BytesReceived;
                    }
                }
            }
            TotalDL = OffsetDL;
            TotalUL = OffsetUL;
            AddEventHandlers();
        }

        ~TrafficCalculator()
        {
            using (StreamWriter writer = new StreamWriter(data_filename)) {
                writer.WriteLine(OffsetDL.ToString());
                writer.WriteLine(OffsetUL.ToString());
            }
        }

        void AddEventHandlers()
        {
            DispatcherTimer DisplayerTimer = new DispatcherTimer();
            DisplayerTimer.Interval = new TimeSpan(0, 0, 0, 0, TickInterval);
            DisplayerTimer.Tick += DisplayerTimer_Tick;
            DisplayerTimer.Start();
            UpdateData();
        }

        void DisplayerTimer_Tick(object sender, EventArgs e)
        {
            UpdateData();
        }

        void AddPrevDL(long n)
        {
            PrevDL.Add(n);
            if (PrevDL.Count > 10) {
                PrevDL.RemoveAt(0);
            }
        }
        void AddPrevUL(long n)
        {
            PrevUL.Add(n);
            if (PrevUL.Count > 10) {
                PrevUL.RemoveAt(0);
            }
        }

        void UpdateData()
        {
            long DL = 0, UL = 0;
            foreach (NetworkInterface ni in NetworkInterfaces) {
                DL += ni.GetIPv4Statistics().BytesReceived;
                UL += ni.GetIPv4Statistics().BytesSent;
            }
            AddPrevDL(DL);
            AddPrevUL(UL);
            TotalDL = DL;
            TotalUL = UL;

            DL = 0;
            UL = 0;
            if (PrevDL.Count != 0 && PrevUL.Count != 0) {
                for (int i=1; i<PrevDL.Count; i++) {
                    DL += (PrevDL[i] - PrevDL[i-1]) * 10;
                    UL += (PrevUL[i] - PrevUL[i-1]) * 10;
                }
                DLSpeed = DL/PrevDL.Count;
                ULSpeed = UL/PrevUL.Count;
            }

        }

        public long GetTotalDL() { return TotalDL - OffsetDL; }
        public long GetTotalUL() { return TotalUL - OffsetUL; }
        public long GetDLSpeed() { return DLSpeed; }
        public long GetULSpeed() { return ULSpeed; }

        public void RefreshOffset()
        {
            long UL = 0, DL = 0;
            foreach (NetworkInterface ni in NetworkInterfaces) {
                UL += ni.GetIPv4Statistics().BytesSent;
                DL += ni.GetIPv4Statistics().BytesReceived;
            }
            OffsetDL = DL;
            OffsetUL = UL;
            TotalDL = TotalUL = 0;
            DLSpeed = ULSpeed = 0;
            PrevDL.RemoveRange(0, PrevDL.Count);
            PrevUL.RemoveRange(0, PrevUL.Count);
        }

    }
}
