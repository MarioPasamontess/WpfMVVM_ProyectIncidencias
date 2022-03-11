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
        public ICommand UpdateClienteCommand { set; get; }

        public int IdF { set; get; }
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
        public UpdateViewCommand updateViewCommand { set; get; }
        public ConsultaViewModel(UpdateViewCommand updateViewCommand)
        {
            ConsultarCommand = new ConsultarCommand(this);
            this.updateViewCommand = updateViewCommand;
            //UpdateClienteCommand = new UpdateClienteCommand(); DUDA QUE PONGO AQUÍ

        }
    }
}
