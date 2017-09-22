using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace eGateCard
{
    public class Poris:IDisposable
    {
        public Poris(string COM)
        {
            if (spID.IsOpen)
                spID.Close();

            spID.PortName = COM;

            spID.Open();
            spID.ReadExisting();
            spID.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(spID_DataReceived);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 250;
            timer.Tick+=new EventHandler(timer_Tick);
            timer.Enabled = true;
        }

        private System.Windows.Forms.Timer timer;

        private System.IO.Ports.SerialPort spID =
        new System.IO.Ports.SerialPort
        {
           PortName = "COM1",
           BaudRate = 19200,
           Parity = System.IO.Ports.Parity.Even,
           DataBits = 8,
           StopBits = System.IO.Ports.StopBits.One

        };

        public bool ON
        {
            set
            {
                if (value == true)
                {
                    spID.DtrEnable = true;
                    System.Threading.Thread.Sleep(TimeOut);
                    spID.DtrEnable = false;
                }
            }
        }

        public int TimeOut { get; set; }

        static Regex regexID = //new Regex(@"(?<MAC>\d+)");
                        new Regex(@"A(?<ID>\d\d)F0(?<MAC>(C|\w\w\w\w\w\w\w\w))");
        StringBuilder temp = new StringBuilder(string.Empty);

        DateTime stamp = DateTime.Now;
        void spID_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
                temp.Append(spID.ReadExisting());

                Match match1 = regexID.Match(temp.ToString());

                while (match1.Success)
                {
                    if (match1.Groups["MAC"].Value.Length > 1)
                    {
                        string mac = match1.Groups["MAC"].Value;

                        mac = Convert.ToInt32(mac, 16).ToString().PadLeft(10, '0');
                                                            //1 second
                        if (eventPassportScaned != null && stamp.AddMilliseconds(15000) > DateTime.Now)
                            eventPassportScaned.Invoke(mac, EventArgs.Empty);
                        //if (eventPassportScaned != null && stamp.AddMilliseconds(1000) > DateTime.Now)
                        //    eventPassportScaned.Invoke(mac, EventArgs.Empty);

                        temp.Length = 0; //= new StringBuilder(string.Empty);
                    }

                    stamp = DateTime.Now;
                    match1 = match1.NextMatch();
                }
        }

        public event EventHandler eventPassportScaned;

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                timer.Enabled = false;

                if (spID.IsOpen)
                    spID.WriteLine(string.Format(@"{0}A01F0F{1}", (char)09, (char)13));//指纹控制器
                  //spID.WriteLine(string.Format(@"{0}A00F0E{1}", (char)09, (char)13));//Poris S1
            }
            catch
            { }
            finally
            {
                timer.Enabled = true;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            timer.Enabled = false;
            if(spID.IsOpen)
                spID.Close();
        }

        #endregion
    }
}
