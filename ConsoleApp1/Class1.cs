using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///using System.Timers;
using System.IO;
using System.ServiceProcess;
using Microsoft.Win32;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace ConsoleApp1
{
    public class Class1
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

     ///   private readonly Timer _timer;

        public Class1()
        {
     ///       _timer = new Timer(1000) { AutoReset = true };
     ///       _timer.Elapsed += TimerElapsed;
            log.Info("Service Initialized");
        }

        ServiceController[] servicesList = ServiceController.GetServices();

    ///private void TimerElapsed(object sender, ElapsedEventArgs e)
     ///   {
     ///       string[] lines = new string[] { DateTime.Now.ToString() };
     ///       File.AppendAllLines(@"C:\Users\Dany\source\repos\ConsoleApp1\ConsoleApp1\Heartbeat.txt", lines);
     ///   }

        public void Start()
        {
            ///_timer.Start();
            foreach (ServiceController service in servicesList)
            {
                log.Info("Service Name: " + service.ServiceName);
            }

        }

        public void Stop()
        {
     ///       _timer.Stop();
        }
    }
}