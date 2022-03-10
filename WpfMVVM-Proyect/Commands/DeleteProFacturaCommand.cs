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
            /*if (formularioViewModel.SelectedDpto != null)
            {
                bool okResult = DataSetHandler.BorrarDpto(resumenViewModel.SelectedDpto);
                if (okResult)
                {
                    resumenViewModel.UpdateDptoCommand.Execute(null);
                    MessageBox.Show("Departamento borrado");
                }
                else
                {
                    MessageBox.Show("No se puedo eliminar el departamento");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un departamento");
            }*/
            //bool okResult = formularioViewModel.DeleteProducto(formularioViewModel.CurrentProducto);
            FormularioView view = (FormularioView)parameter;
            ProductoModel2 pro = (ProductoModel2)view.ProductoListView.SelectedItem;
            bool okResult = formularioViewModel.DeleteProducto(pro);
            if (okResult)
            {
                MessageBox.Show("Se ha eliminado el producto");
            }
            else
            {
                MessageBox.Show("No se ha eliminado el producto");
            }
        }
        FormularioViewModel formularioViewModel { get; set; }
        public DeleteProFacturaCommand(FormularioViewModel formularioViewModel)
        {
            this.formularioViewModel = formularioViewModel;
        }
    }
}
