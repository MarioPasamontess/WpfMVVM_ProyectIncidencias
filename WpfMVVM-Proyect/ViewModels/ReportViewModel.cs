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

        private string CurrentPath = Environment.CurrentDirectory;
        private string InformeIncidenciasFactura = "Report/InformeIncidenciasFactura.rdlc";

        public ReportViewModel()
        {
            myReport = new ReportViewer();
            rds = new ReportDataSource();
        }
        public void GenerarInformeIncidenciasFactura(int factura)
        {
            rds.Name = "Informe";
            rds.Value = DataSetHandler.GetDataByFactura(factura);
            myReport.LocalReport.DataSources.Add(rds);
            myReport.LocalReport.ReportPath = "../../Report/InformeIncidenciasFactura.rdlc";
            //myReport.LocalReport.ReportPath = "../../Report/InformeIncidenciasFactura.rdlc";
            myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, InformeIncidenciasFactura);
            byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
            pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
        }
        public void GenerarInformeIncidenciasCliente(int dni)
        {
            rds.Name = "Informe";
            rds.Value = DataSetHandler.GetDataByClient(dni);
            myReport.LocalReport.DataSources.Add(rds);
            myReport.LocalReport.ReportPath = "../../Report/InformeIncidenciasCliente.rdlc";
            //myReport.LocalReport.ReportPath = "../../Report/InformeIncidenciasFactura.rdlc";
            myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, InformeIncidenciasFactura);
            byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
            pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
        }
        public void GenerarInformeIncidenciasFecha(DateTime fecha)
        {
            rds.Name = "Informe";
            rds.Value = DataSetHandler.GetDataByFecha(fecha);
            myReport.LocalReport.DataSources.Add(rds);
            myReport.LocalReport.ReportPath = "../../Report/InformeIncidenciasFactura.rdlc";
            //myReport.LocalReport.ReportPath = "../../Report/InformeIncidenciasFactura.rdlc";
            myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, InformeIncidenciasFactura);
            byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
            pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
        }
    }
}
