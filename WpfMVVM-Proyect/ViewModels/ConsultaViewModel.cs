﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Proyect.Commands;
using WpfMVVM_Proyect.Models;

namespace WpfMVVM_Proyect.ViewModels
{
    internal class ConsultaViewModel: ViewModelBase
    {
        public ICommand ConsultarCommand { set; get; }

        public string IdF { set; get; }
        private ClienteModel cliente;
        public ClienteModel Cliente
        {
            get { return cliente; }
            set
            {
                cliente = value;
                OnPropertyChanged(nameof(Cliente));
            }
        }
        private FacturaModel factura;
        public FacturaModel Factura
        {
            get { return factura; }
            set
            {
                factura = value;
                OnPropertyChanged(nameof(Factura));
            }
        }
        public UpdateViewCommand updateViewCommand { set; get; }
        public ConsultaViewModel(UpdateViewCommand updateViewCommand)
        {
            ConsultarCommand = new ConsultarCommand(this);
            this.updateViewCommand = updateViewCommand;

        }
    }
}
