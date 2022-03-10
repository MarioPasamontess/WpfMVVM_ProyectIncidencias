using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Proyect.Models;
using WpfMVVM_Proyect.ViewModels;

namespace WpfMVVM_Proyect.Commands
{
    class LoadProveedoresCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {   
                if (parameter != null)
                {
                    ProveedorModel proveedor = (ProveedorModel)parameter;

                    proveedoresViewModel.CurrentProveedor = (ProveedorModel)proveedor.Clone();
                    proveedoresViewModel.SelectedProveedor = (ProveedorModel)proveedor.Clone();
                }
                else
                {
                    proveedoresViewModel.CurrentProveedor = null;
                    proveedoresViewModel.SelectedProveedor = null;
                }
            }
            catch (Exception e) { }
                
            
        }

        public ProveedoresViewModel proveedoresViewModel { get; set; }
        public LoadProveedoresCommand(ProveedoresViewModel proveedoresViewModel)
        {
            this.proveedoresViewModel = proveedoresViewModel;
        }
    }
}
