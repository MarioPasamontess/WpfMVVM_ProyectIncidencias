using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM_Proyect.Services.DataSet;

namespace WpfMVVM_Proyect.ViewModels
{
    internal class ReportViewModel: ViewModelBase
    {
        public string pdfData { set; get; }
        ReportViewer myReport { set; get; }
        ReportDataSource rds { set; get; }

        public ReportViewModel()
        {
            myReport = new ReportViewer();
            rds = new ReportDataSource();
        }
        public void GenerarInformeIncidenciasFactura(int factura)
        {
            rds.Name = "InformeIncidencias";
            //rds.Value = DataSetHandler.GetDataByFactura(factura);
            myReport.LocalReport.DataSources.Add(rds);
            myReport.LocalReport.ReportPath = "../../Reports/InformeIncidenciasDNI.rdlc";
            byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
            pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
        }
    }
}
