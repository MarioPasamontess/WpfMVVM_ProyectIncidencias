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

namespace WpfMVVM_Proyect.Commands
{
    class InsertFacturaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ClienteModel cliente = formularioViewModel.Cliente;
            formularioViewModel.Factura.Total = formularioViewModel.Total;
            if (cliente is null)
            {
                MessageBox.Show("Selecciona un cliente");
            }
            else if (formularioViewModel.Factura.Fecha.ToString() == "")
            {
                MessageBox.Show("Seleccione una fecha.");
            }
            else if (formularioViewModel.Factura.Total <= 0)
            {
                MessageBox.Show("Inserte algún producto.");
            }
            else {
                bool insertarOK = DataSetHandler.insertarFactura(cliente._dni, formularioViewModel.Factura.Fecha,formularioViewModel.Factura.Total, formularioViewModel.ListaProductos2);
                if (insertarOK)
                {
                    MessageBox.Show("Factura insertada correctamente");
                    formularioViewModel.Factura = new FacturaModel();
                    
                }
                else
                {
                    MessageBox.Show("La Factura no se ha registrado correctamente");

                }
            }
        }
        public FormularioViewModel formularioViewModel { set; get; }
        public InsertFacturaCommand(FormularioViewModel formularioViewModel)
        {
            this.formularioViewModel = formularioViewModel;
        }
    }
}
