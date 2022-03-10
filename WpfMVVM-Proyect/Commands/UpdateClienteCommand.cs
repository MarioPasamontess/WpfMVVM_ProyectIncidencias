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
    class UpdateClienteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            formularioViewModel.ListaClientes = DataSetHandler.getCliente();
        }
        public FormularioViewModel formularioViewModel { set; get; } 
        public UpdateClienteCommand (FormularioViewModel formularioViewModel)
        {
            this.formularioViewModel = formularioViewModel;
        }
    }
}
