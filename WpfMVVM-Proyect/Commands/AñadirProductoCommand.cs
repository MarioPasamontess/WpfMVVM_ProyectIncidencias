using WpfMVVM_Proyect.ViewModels;
using WpfMVVM_Proyect.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Proyect.Models;
using System.Data;
using WpfMVVM_Proyect.Services.DataSet.ProyectoDataSetTableAdapters;
using WpfMVVM_Proyect.Services.DataSet;
using System.Windows;
using System.Collections.ObjectModel;
using WpfMVVM_Proyect.Services;

namespace WpfMVVM_Proyect.Commands
{
    class AñadirProductoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            /*bool okinsertar = DataSetHandler.InsertarProducto(formulario.Producto);
            if (okinsertar)
            {
                formulario.Producto = new ProductoModel2();
            }
            else
            {
                MessageBox.Show("Error al insertar");
            }*/
            bool insertar = true;
            formulario.CurrentProducto = (ProductoModel2)parameter;         
            foreach (ProductoModel2 p in formulario.ListaProductos2)
            {
                //if(formulario.ListaProductos2.Contains(p))
                if (formulario.CurrentProducto._id.Equals(p._id))
                {
                    p.Cantidad = p.Cantidad + formulario.Cantidad; 
                    p.Total = p.Cantidad * p.Precio;
                    formulario.Total = formulario.Total + p.Total;
                    insertar = false;
                    break;
                }
                else
                {
                    insertar = true;
                }

            }
            if (insertar)
            {
                formulario.CurrentProducto.Cantidad = formulario.Cantidad;
                insertar = formulario.NuevoProducto(formulario.CurrentProducto);
                if (insertar)
                {
                    formulario.CurrentProducto.Cantidad = formulario.Cantidad;
                    formulario.CurrentProducto.Total = formulario.CurrentProducto.Cantidad * formulario.CurrentProducto.Precio;
                    MessageBox.Show("Se ha creado correctamente");
                    formulario.CurrentProducto = new ProductoModel2();
                    formulario.Total = formulario.Total + formulario.CurrentProducto.Total;


                }
                else
                {
                    MessageBox.Show("No se ha creado correctamente");
                }
            }
        }
        public void cargarListaP(ProductoModel producto)
        {
            FormularioView view = new FormularioView();
            
        }
        FormularioViewModel formulario;
        public AñadirProductoCommand(FormularioViewModel formulario)
        {
            this.formulario = formulario;
        }
    }
}
