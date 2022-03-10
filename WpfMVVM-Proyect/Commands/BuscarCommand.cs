using Newtonsoft.Json;
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
    class BuscarCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            string palabra = productos.Busqueda;
            //productos.ListaProductos = ProductosDBHandler.busquedaProductos(palabra);

            ProductosView vista = (ProductosView)parameter;
            if (vista != null)
            {
                RequestModel requestModel = new RequestModel();

                requestModel.route = "/productos";
                requestModel.method = "GET";
                requestModel.data = palabra;


                ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

                if (responseModel.resultOk)
                {
                    vista.E01MostrarProducto();
                    productos.CurrentProducto = JsonConvert.DeserializeObject<ProductoModel>((string)responseModel.data);
                }
                else
                {
                    MessageBox.Show((string)responseModel.data);
                }
            }
            
        }
        public ProductosViewModel productos;
        public BuscarCommand(ProductosViewModel productos)
        {
            this.productos = productos;
        }
    }
}
