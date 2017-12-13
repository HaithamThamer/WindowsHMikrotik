using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HMikrotik
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length > 2)
            {
                MK mk = new MK(e.Args[0]);
                if (mk.Login(e.Args[1],e.Args[2]))
                {
                    Random random = new Random();
                    int code = random.Next(10000, 99999);
                    mk.Send("/ip/hotspot/user/add");
                    mk.Send("=name=" + code);
                    mk.Send("=password=haitham");
                    mk.Send("=comment=HMikrotik");
                    mk.Send("=disabled=no",true);
                    InternetTicket internetTicket = new InternetTicket(e.Args[3], "go to \"http://" + e.Args[0] + "/\" then enter code below", code.ToString());
                    ReportPrintTool rpt = new ReportPrintTool(internetTicket);
                    rpt.Print();
                    string s = "";
                    foreach (string h in mk.Read())
                    {
                        s += h;
                    }
                }
                else
                {
                    MessageBox.Show("ERROR in login");
                }
            }
            Environment.Exit(0);
        }
    }
}
