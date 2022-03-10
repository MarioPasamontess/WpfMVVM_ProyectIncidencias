using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Proyect.Services.DataSet;
using WpfMVVM_Proyect.ViewModels;

namespace WpfMVVM_Proyect.Commands
{
    internal class UpdateProductoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            formularioViewModel.ListaProductos = DataSetHandler.getProducto();
        }
        FormularioViewModel formularioViewModel { get; set; }
        public UpdateProductoCommand(FormularioViewModel formulario)
        {
            formularioViewModel = formulario;
        }
    }
}
