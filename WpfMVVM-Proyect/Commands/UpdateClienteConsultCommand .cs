using WpfMVVM_Proyect.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Proyect.Services.DataSet;

namespace WpfMVVM_Proyect.Commands
{
    class UpdateClienteConsultCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            consultaViewModel.ListaClientes = DataSetHandler.getCliente();
        }
        public ConsultaViewModel consultaViewModel { set; get; } 
        public UpdateClienteConsultCommand (ConsultaViewModel consultaViewModel)
        {
            this.consultaViewModel = consultaViewModel;
        }
    }
}
