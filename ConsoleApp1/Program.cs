using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using System.IO;
using System.ServiceProcess;

namespace ConsoleApp1
{
    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {

            ///log.Error("This Is My error message");
            Console.WriteLine("Dany + 1");
            Console.ReadLine();

            var exitCode = HostFactory.Run(x => ///This is  a usage of Topshelf for starting and stopping windows service
            {
                x.Service<Class1>(s =>
                {
                    s.ConstructUsing(class1 => new Class1());
                    s.WhenStarted(class1 => class1.Start());
                    s.WhenStopped(class1 => class1.Stop());
                });
                x.RunAsLocalSystem();

                x.SetServiceName("Class1isService");
                x.SetDisplayName("Class1 Display Service");
                x.SetDescription("THis is just my service to test");

            });
            
            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
