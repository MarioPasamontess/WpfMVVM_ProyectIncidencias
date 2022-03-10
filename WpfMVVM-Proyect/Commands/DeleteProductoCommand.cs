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
    class DeleteProductoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            ProductosView view = (ProductosView)parameter;
            MessageBoxResult result = MessageBox.Show("¿Está seguro que desa eliminar?", "Eliminar Producto", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    RequestModel requestModel = new RequestModel();                  
                    requestModel.method = "DELETE";
                    requestModel.route = "/productos";
                    requestModel.data = productosViewModel.CurrentProducto._id;
                    ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

                    if (responseModel.resultOk)
                    {
                        // view.E00EstadoInicial();
                        productosViewModel.LoadProductsCommand.Execute("");
                        MessageBox.Show("Se ha eliminado el producto");
                    }
                    else
                    {
                        MessageBox.Show((string)responseModel.data);
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }

        }
        public ProductosViewModel productosViewModel;
        public DeleteProductoCommand(ProductosViewModel productosViewModel)
        {
            this.productosViewModel = productosViewModel;
        }
    }
}
