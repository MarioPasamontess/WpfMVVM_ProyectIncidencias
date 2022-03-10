using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM_Proyect.Models;
using WpfMVVM_Proyect.Services;
using WpfMVVM_Proyect.ViewModels;

namespace WpfMVVM_Proyect.Commands
{
    class LoadProductsCommand: ICommand //, INotifyPropertyChanged
    {
        public event EventHandler CanExecuteChanged;
        
        //public event PropertyChangedEventHandler PropertyChanged;

        ProductosViewModel productos;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public async void Execute(object parameter)
        {
            ProductosDBHandler.CargarLista();

            RequestModel requestModel = new RequestModel();
            requestModel.route = "/productos";
            requestModel.method = "GET";
            requestModel.data = "all";

            ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

            if (responseModel.resultOk)
            {
                productosViewModel.ListaProductos = JsonConvert.DeserializeObject<ObservableCollection<ProductoModel>>((string)responseModel.data);
            }
            else
            {
                MessageBox.Show((string)responseModel.data);
            }
                //productosViewModel.ListaDeTodosProveedores = ProveedoresDBHandler.ObtenerListaProveedores();
                //ProductosDBHandler.CargarLista();
                //productosViewModel.ListaProductos = ProductosDBHandler.ObtenerListaProductos();
        }
        public ProductosViewModel productosViewModel;
        public LoadProductsCommand(ProductosViewModel productosViewModel)
        {
            this.productosViewModel = productosViewModel;
        }
    }
}
