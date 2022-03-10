using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Proyect.ViewModels;

namespace WpfMVVM_Proyect.Commands
{
    class ProveedorAlmacenCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            almacen = parameter.ToString();
            producto.CurrentProducto.Proveedor.Add(almacen);
        }
        private string almacen;
        ProductosViewModel producto;
        ProveedorAlmacenCommand(ProductosViewModel producto)
        {
            this.producto = producto;
        }
    }
}
