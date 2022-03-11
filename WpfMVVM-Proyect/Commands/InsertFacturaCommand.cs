﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Proyect.Services.DataSet;
using WpfMVVM_Proyect.ViewModels;

namespace WpfMVVM_Proyect.Commands
{
    public class InsertFacturaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            /*int idFactura = DataSetHandler.GetDataByFactura(formularioViewModel.Factura._idFactura);
            
            if (idEmpleado == 0)
            {
                MessageBox.Show("El DNI no existe");
            }
            else
            {
                formViewModel.Incidencia.IdEmpleado = idEmpleado;
                bool insertarOk = DataSetHandler.InsertarIncidencia(formViewModel.Incidencia);
                if (!insertarOk)
                {
                    MessageBox.Show("No se pudo insertar. Llama al servicio técnico: 923442313");
                }
                else
                {
                    MessageBox.Show("La incidencia se registró correctamente");
                    formViewModel.Incidencia = new IncidenciaModel();
                }
            }*/
        }
        FormularioViewModel formularioViewModel { set; get; }
        InsertFacturaCommand(FormularioViewModel formularioViewModel)
        {
            this.formularioViewModel = formularioViewModel;
        }
    }
}
