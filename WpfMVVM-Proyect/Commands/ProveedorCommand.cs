using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    class ProveedorCommand : ICommand
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
            else if (string.IsNullOrWhiteSpace(view.telefono.Text) || proveedorViewModel.CurrentProveedor.Telefono <= 0)
            {
                view.warning.Text = "Debes introducir un teléfono";
            }
            else
            {
                bool insertar = true;
                ObservableCollection<ProveedorModel> proveedoresModel = ProveedoresDBHandler.ObtenerListaProveedores();
                foreach (ProveedorModel p in proveedoresModel)
                {
                    if (p._id.Equals(proveedorViewModel.CurrentProveedor._id))
                    {
                        view.warning.Text = "Ya existe este codigo de barras";
                        insertar = false;
                    }
                }
                if (insertar)
                {
                    insertar = ProveedoresDBHandler.NuevoProveedor(proveedorViewModel.CurrentProveedor);
                    if (insertar)
                    {
                        MessageBox.Show("Se ha creado correctamente");
                        proveedorViewModel.CurrentProveedor = new ProveedorModel();
                        

                    }
                    else
                    {
                        MessageBox.Show("No se ha creado correctamente");
                    }
                }
            }
          
        }
        private ProveedoresViewModel proveedorViewModel;
        public ProveedorCommand (ProveedoresViewModel proveedorViewModel)
        {
            this.proveedorViewModel = proveedorViewModel;
        }
       
    }
}
