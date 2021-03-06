using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ICommand UpdateClienteConsultCommand { set; get; }

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
        public DateTime Fecha { set; get; }
        public DateTime Fecha1 { set; get; }
        public DateTime Fecha2 { set; get; }

        public bool checkFiltro { set; get; }

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
        private DetalleFacturaModel detalleFactura;
        public DetalleFacturaModel DetalleFactura
        {
            get { return detalleFactura; }
            set
            {
                detalleFactura = value;
                OnPropertyChanged(nameof(DetalleFactura));
            }
        }
        private ObservableCollection<ClienteModel> listaClientes;
        public ObservableCollection<ClienteModel> ListaClientes
        {
            get
            {
                return listaClientes;
            }
            set
            {
                listaClientes = value;
                OnPropertyChanged(nameof(ListaClientes));
            }
        }
        public int idFactura { set; get; }
        public UpdateViewCommand updateViewCommand { set; get; }
        public ConsultaViewModel(UpdateViewCommand updateViewCommand)
        {
            ConsultarCommand = new ConsultarCommand(this);
            this.updateViewCommand = updateViewCommand;
            UpdateClienteConsultCommand = new UpdateClienteConsultCommand(this);
            Fecha = DateTime.Today;
            Fecha1 = DateTime.Today;
            Fecha2 = DateTime.Today;
            Factura = new FacturaModel();
        }
    }
}
