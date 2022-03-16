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
        private string InformeIncidenciasCliente = "Report/InformeIncidenciasCliente.rdlc";
        private string InformeIncidenciasFecha = "Report/InformeIncidenciasFecha.rdlc";
        private string InformeIncidenciasFechaClient = "Report/InformeIncidenciasFechaClient.rdlc";

        public ReportViewModel()
        {
            myReport = new ReportViewer();
            rds = new ReportDataSource();
        }
        public bool GenerarInformeIncidenciasFactura(int factura)
        {
            rds.Name = "Informe";
            rds.Value = DataSetHandler.GetDataByFactura(factura);
            myReport.LocalReport.DataSources.Add(rds);
            //myReport.LocalReport.ReportPath = "../../Report/InformeIncidenciasFactura.rdlc";
            myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, InformeIncidenciasFactura);
            byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
            pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
            return true;
        }
        public bool GenerarInformeIncidenciasCliente(string dni)
        {
            rds.Name = "Informe";
            rds.Value = DataSetHandler.GetDataByClient(dni);
            myReport.LocalReport.DataSources.Add(rds);
            //myReport.LocalReport.ReportPath = "../../Report/InformeIncidenciasCliente.rdlc";
            myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, InformeIncidenciasCliente);
            byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
            pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
            return true;
        }
        public bool GenerarInformeIncidenciasFecha(DateTime fecha)
        {
            rds.Name = "Informe";
            rds.Value = DataSetHandler.GetDataByFecha(fecha);
            myReport.LocalReport.DataSources.Add(rds);
            //myReport.LocalReport.ReportPath = "../../Report/InformeIncidenciasFecha.rdlc";
            myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, InformeIncidenciasFecha);
            byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
            pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
            return true;
        }
        public bool GenerarInformeIncidenciasClienteFecha(string dni, DateTime fecha1, DateTime fecha2)
        {
            rds.Name = "Informe";
            rds.Value = DataSetHandler.GetDataByCliFecha(dni,fecha1,fecha2);
            myReport.LocalReport.DataSources.Add(rds);
            //myReport.LocalReport.ReportPath = "../../Report/InformeIncidenciasFechaClient.rdlc";
            myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, InformeIncidenciasFechaClient);
            byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
            pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
            return true;
        }
        public bool GenerarInformeIncidenciasFechas(DateTime fecha1, DateTime fecha2)
        {
            rds.Name = "Informe";
            rds.Value = DataSetHandler.GetDataByFechas(fecha1, fecha2);
            myReport.LocalReport.DataSources.Add(rds);
            //myReport.LocalReport.ReportPath = "../../Report/InformeIncidenciasFecha.rdlc";
            myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, InformeIncidenciasFecha);
            byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
            pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
            return true;
        }
    }
}
