using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM_Proyect.Models;
using WpfMVVM_Proyect.Services;
using WpfMVVM_Proyect.ViewModels;
using WpfMVVM_Proyect.Views;

namespace WpfMVVM_Proyect.Commands
{
    class EditProductoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            ProductosView view = (ProductosView)parameter;
            if(view != null) { 
            if (string.IsNullOrWhiteSpace(view.codBarras.Text))
            {
                view.warning.Text = "Debes introducir un CIF";
            }
            else if (string.IsNullOrWhiteSpace(view.comboProveedores.Text))
            {
                view.warning.Text = "Debes introducir un proveedor";
            }
            else if (string.IsNullOrWhiteSpace(view.comboTipo.Text))
            {
                view.warning.Text = "Debes introducir un tipo";
            }
            else if (string.IsNullOrWhiteSpace(view.Marca.Text))
            {
                view.warning.Text = "Debes introducir una marca";
            }
            else if (string.IsNullOrWhiteSpace(view.Color.Text))
            {
                view.warning.Text = "Debes introducir un color";
            }
            else if (string.IsNullOrWhiteSpace(view.referencia.Text))
            {
                view.warning.Text = "Debes introducir una referencia";
            }
            else if (string.IsNullOrWhiteSpace(view.descripcion.Text))
            {
                view.warning.Text = "Debes introducir una descripción";
            }
            else if (string.IsNullOrWhiteSpace(view.precio.Text) || productosViewModel.CurrentProducto.Precio <= 0)
            {
                view.warning.Text = "Debes introducir un precio";
            }
            else if (string.IsNullOrWhiteSpace(view.date.Text))
            {
                view.warning.Text = "Debes introducir una fecha";
            }
            else if (string.IsNullOrWhiteSpace(view.stock.Text) || productosViewModel.CurrentProducto.Stock <= 0)
            {
                view.warning.Text = "Debes introducir un stock";
            }
            else
            {
            MessageBoxResult result = MessageBox.Show("¿Desea modificar los cambios?", "Modificar", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                            //MessageBox.Show("Se ha modificado el producto");
                            //productosViewModel.CurrentProducto = null;
                            //productosViewModel.ListaAlmacenes = null;
                            RequestModel requestModel = new RequestModel();
                            requestModel.route = "/productos";
                            requestModel.method = "PUT";
                            requestModel.data = productosViewModel.CurrentProducto;
                            ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);
                            if (responseModel.resultOk)
                            {
                                MessageBox.Show((string)responseModel.data, "Modificar");
                                view.E01MostrarProducto();
                                productosViewModel.LoadProductsCommand.Execute("");
                            }

                            break;
                    case MessageBoxResult.None:
                        break;
                }
                
            }
            }
            else
            {
                Console.WriteLine("vista nula");
            }

        }

        public ProductosViewModel productosViewModel;
        public EditProductoCommand(ProductosViewModel productosViewModel)
        {
            this.productosViewModel = productosViewModel;
        }
    }
}
