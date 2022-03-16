using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM_Proyect.ViewModels;

namespace WpfMVVM_Proyect.Commands
{
    internal class ConsultarCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string tipoInforme = (string)parameter;
            if (tipoInforme.Equals("idF"))
            {
                bool insertar = consultaViewModel.updateViewCommand.reportViewModel.GenerarInformeIncidenciasFactura(consultaViewModel.idFactura);
                if (insertar)
                {
                    consultaViewModel.updateViewCommand.Execute("report");
                }
                else
                {
                    MessageBox.Show("No se encontró la factura", "Facturas", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                
            }
            else if (tipoInforme.Equals("Client"))
            {
                bool insertar = consultaViewModel.updateViewCommand.reportViewModel.GenerarInformeIncidenciasCliente(consultaViewModel.Cliente._dni);
                if (insertar)
                {
                    consultaViewModel.updateViewCommand.Execute("report");
                }
                else
                {
                    MessageBox.Show("El cliente no tiene facturas", "Facturas", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
            else if (tipoInforme.Equals("Fecha"))
            {
                bool insertar = consultaViewModel.updateViewCommand.reportViewModel.GenerarInformeIncidenciasFecha(consultaViewModel.Fecha);
                if (insertar)
                {
                    consultaViewModel.updateViewCommand.Execute("report");
                }
                else
                {
                    MessageBox.Show("No se encontró la factura", "Facturas", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
            else if (tipoInforme.Equals("CliDate"))
            {
                if (consultaViewModel.Cliente != null)
                {
                    bool insertar = consultaViewModel.updateViewCommand.reportViewModel.GenerarInformeIncidenciasClienteFecha(consultaViewModel.Cliente._dni,consultaViewModel.Fecha1,consultaViewModel.Fecha2);
                    if (insertar)
                    {
                        consultaViewModel.updateViewCommand.Execute("report");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la factura", "Facturas", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    
                }
                else
                {
                    bool insert = consultaViewModel.updateViewCommand.reportViewModel.GenerarInformeIncidenciasFechas(consultaViewModel.Fecha1, consultaViewModel.Fecha2);
                    if (insert)
                    {
                        consultaViewModel.updateViewCommand.Execute("report");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la factura", "Facturas", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    
                }
                
            }
        }
        ConsultaViewModel consultaViewModel { set; get; }
        public ConsultarCommand(ConsultaViewModel consultaViewModel)
        {
            this.consultaViewModel = consultaViewModel;
        }
    }
}
