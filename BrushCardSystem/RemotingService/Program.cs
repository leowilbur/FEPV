using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using log4net;

namespace RemotingService
{
    class Program
    {
        private static readonly ILog logs = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [STAThread]
        static void Main(string[] args)
        {
           try
           {
              
                Console.WriteLine("Service start.Service.TServiceHelper......");
                RemotingConfiguration.Configure("Remoting.xml", false);
                Console.ReadLine();
           }catch(Exception ex){
           
                   logs.Error(ex);
               Console.WriteLine(ex.Message);
           }
           
        }
    }
}
