using WpfMVVM_Proyect.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM_Proyect.Commands;
using WpfMVVM_Proyect.Models;
using WpfMVVM_Proyect.ViewModels;
using System.Windows.Input;

namespace WpfMVVM_Proyect.ViewModels
{
    class FormularioViewModel: ViewModelBase
    {
        public ICommand UpdateClienteCommand { set; get; }
        public ICommand UpdateProductoCommand { set; get; }
        public ICommand AñadirProductoCommand { set; get; }
        public ICommand LoadFacturaCommand { set; get; }
        public ICommand DeleteProFacturaCommand { set; get; }
        private int cantidad;
        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                cantidad = value;
                OnPropertyChanged(nameof(Cantidad));
            }
        }
        private double total;
        public double Total
        {
            get { return total; }
            set
            {
                total = value;
                OnPropertyChanged(nameof(Total));
            }
        }
        private ProductoModel2 producto;
        public ProductoModel2 Producto
        {
            get { return producto; }
            set
            {
               producto = value;
                OnPropertyChanged(nameof(Producto));
            }
        }
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
        private ObservableCollection<ProductoModel2> listaProductos;
        public ObservableCollection<ProductoModel2> ListaProductos
        {
            get
            {
                return listaProductos;
            }
            set
            {
                listaProductos = value;
                OnPropertyChanged(nameof(ListaProductos));
            }
        }
        private ObservableCollection<ProductoModel2> listaProductos2;
        public ObservableCollection<ProductoModel2> ListaProductos2
        {
            get
            {
                return listaProductos2;
            }
            set
            {
                listaProductos = value;
                OnPropertyChanged(nameof(ListaProductos2));
            }
        }
        public bool NuevoProducto(ProductoModel2 producto)
        {
            bool insertarOk = false;
            try
            {
                listaProductos2.Add(producto);
                insertarOk = true;
            }
            catch (Exception ex) { }
            return insertarOk;
        }
        public bool DeleteProducto(ProductoModel2 productoModel)
        {
            bool DeleteOk = false;
            try
            {
                foreach (ProductoModel2 p in listaProductos2)
                {
                    if (p._id.Equals(productoModel._id))
                    {
                        listaProductos2.Remove(p);
                        DeleteOk = true;
                        break;
                    }
                }
            }
            catch
            {

            }
            return DeleteOk;
        }
        private ProductoModel2 currentProducto { set; get; }
        public ProductoModel2 CurrentProducto
        {
            get
            {
                return currentProducto;
            }
            set
            {
                currentProducto = value;
                OnPropertyChanged(nameof(CurrentProducto));
            }
        }
        public UpdateViewCommand update { set; get; }
        public FormularioViewModel()
        {
            listaProductos2 = new ObservableCollection<ProductoModel2>();
            UpdateClienteCommand = new UpdateClienteCommand(this);
            UpdateProductoCommand = new UpdateProductoCommand(this);
            AñadirProductoCommand = new AñadirProductoCommand(this);
            LoadFacturaCommand = new LoadFacturaCommand(this);
            DeleteProFacturaCommand = new DeleteProFacturaCommand(this);
        }
    }
}
