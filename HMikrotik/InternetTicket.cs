using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace HMikrotik
{
    public partial class InternetTicket : DevExpress.XtraReports.UI.XtraReport
    {
        public InternetTicket(string imagePath,string howTo,string code)
        {
            InitializeComponent();
            lblCode.Text = code;
            lblHowTo.Text = howTo;
            picCompany.Image = Image.FromFile(imagePath);
            PrinterName = new System.Drawing.Printing.PrinterSettings().PrinterName;
        }

    }
}
