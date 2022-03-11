using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                consultaViewModel.updateViewCommand.reportViewModel.GenerarInformeIncidenciasFactura(consultaViewModel.IdF);
                consultaViewModel.updateViewCommand.Execute("report");
            }
        }
        ConsultaViewModel consultaViewModel { set; get; }
        public ConsultarCommand(ConsultaViewModel consultaViewModel)
        {
            this.consultaViewModel = consultaViewModel;
        }
    }
}
