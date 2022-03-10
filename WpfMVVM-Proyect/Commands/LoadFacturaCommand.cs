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
    class LoadFacturaCommand : ICommand
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
                    ProductoModel2 pro = (ProductoModel2)parameter;

                    formularioViewModel.CurrentProducto = (ProductoModel2)pro.Clone();
                }
                else
                {
                    formularioViewModel.CurrentProducto = null;
                }
            }
            catch (Exception e) { }
        }
        FormularioViewModel formularioViewModel { set; get; }
        public LoadFacturaCommand(FormularioViewModel formularioViewModel)
        {
            this.formularioViewModel = formularioViewModel;
        }
    }
}
