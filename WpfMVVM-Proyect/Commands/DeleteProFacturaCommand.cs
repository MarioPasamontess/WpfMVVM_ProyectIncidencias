using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM_Proyect.Models;
using WpfMVVM_Proyect.Services.DataSet;
using WpfMVVM_Proyect.ViewModels;
using WpfMVVM_Proyect.Views;

namespace WpfMVVM_Proyect.Commands
{
    internal class DeleteProFacturaCommand : ICommand
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
                foreach (ProductoModel2 p in formularioViewModel.ListaProductos2)
                {
                    if (p._id.Equals(formularioViewModel.CurrentProducto._id))
                    {
                        formularioViewModel.Total = formularioViewModel.Total - p.Total;
                        formularioViewModel.ListaProductos2.Remove(p);
                        
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        FormularioViewModel formularioViewModel { get; set; }
        public DeleteProFacturaCommand(FormularioViewModel formularioViewModel)
        {
            this.formularioViewModel = formularioViewModel;
        }
    }
}
