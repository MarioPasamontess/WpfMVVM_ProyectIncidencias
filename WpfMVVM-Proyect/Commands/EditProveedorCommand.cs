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
    class EditProveedorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            ProveedoresView view = (ProveedoresView)parameter;
            if (string.IsNullOrWhiteSpace(view.id.Text))
            {
                view.warning.Text = "Debes introducir un cif";
            }
            else if (string.IsNullOrWhiteSpace(view.nombre.Text))
            {
                view.warning.Text = "Debes introducir un nombre";
            }
            else if (string.IsNullOrWhiteSpace(view.poblacion.Text))
            {
                view.warning.Text = "Debes introducir una población";
            }
            else if (string.IsNullOrWhiteSpace(view.telefono.Text) || proveedorViewModel.CurrentProveedor.Telefono<=0)
            {
                view.warning.Text = "Debes introducir un teléfono";
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("¿Desea modificar los cambios?", "Modificar", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        bool editar = ProveedoresDBHandler.EditProveedor(proveedorViewModel.CurrentProveedor);
                        if (editar)
                        {
                            MessageBox.Show("Se ha modificado el proveedor");
                            proveedorViewModel.CurrentProveedor = null;
                            proveedorViewModel.SelectedProveedor = null;
                        }
                            break;
                    case MessageBoxResult.None:
                            break;
                        /*RequestModel requestModel = new RequestModel();
                        requestModel.route = "/productos";
                        requestModel.method = "PUT";
                        requestModel.data = proveedorViewModel.CurrentProveedor;
                        ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);
                        if (responseModel.resultOk)
                        {
                            view.E01MostrarProveedor();
                            proveedorViewModel.LoadProveedorCommand.Execute("");
                        }
                    }
                    break;
                case MessageBoxResult.None:
                    break;*/
                }
                
            }
           
        }
        public ProveedoresViewModel proveedorViewModel;
        public EditProveedorCommand(ProveedoresViewModel proveedorViewModel)
        {
            this.proveedorViewModel = proveedorViewModel;
        }
    }
}
