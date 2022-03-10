using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Proyect.Commands;
using WpfMVVM_Proyect.Models;
using WpfMVVM_Proyect.Services;

namespace WpfMVVM_Proyect.ViewModels
{
    class ProductosViewModel: ViewModelBase
    {
       private ProductoModel currentProducto { set; get; }
       public ProductoModel CurrentProducto { get { return currentProducto; } set { currentProducto = value; OnPropertyChanged(nameof(CurrentProducto)); } }
       private ObservableCollection<ProductoModel> listaProductos { get; set; }
       public ObservableCollection<ProductoModel> ListaProductos 
        {
            get { return listaProductos; } 
            set { listaProductos = value; OnPropertyChanged(nameof(ListaProductos)); } 
        }
        private ObservableCollection<ProveedorModel> listaDeTodosProveedores { get; set; }
        public ObservableCollection<ProveedorModel> ListaDeTodosProveedores
        {
            get { return listaDeTodosProveedores; }
            set { listaDeTodosProveedores = value; OnPropertyChanged(nameof(ListaDeTodosProveedores)); }
        }

        private ObservableCollection<string> listaProveedores { get; set; }
        public ObservableCollection<string> ListaProveedores
        {
            get { return listaProveedores; }
            set { listaProveedores = value; OnPropertyChanged(nameof(ListaProveedores)); }
        }
        private string busqueda;
        public string Busqueda
        {
            get { return busqueda; }
            set { busqueda = value; OnPropertyChanged(nameof(Busqueda)); }
        }
       public ObservableCollection<String> ListaAlmacenes { get; set; }
       public ObservableCollection<String> ListaMarcas { get; set; }
       public ObservableCollection<String> ListaAlmacen { get; set; }
       public ICommand LoadProductsCommand { get; set; }
       public ICommand LoadProductCommand { get; set; }
       public ICommand NewProductoCommand { get; set; }
       public ICommand DeleteProductoCommand { get; set; }
       public ICommand EditProductoCommand { get; set; }
       public ICommand BuscarCommand { get; set; }
       public ProductosViewModel()
        {
            BuscarCommand = new BuscarCommand(this);
            ListaProveedores = new ObservableCollection<string>();
            listaDeTodosProveedores = new ObservableCollection<ProveedorModel>();
            ListaAlmacenes = new ObservableCollection<string>();
            ListaMarcas = new ObservableCollection<String>() { "Adidas", "Nike", "Puma", "Cole Haan", "Emidio Tucci", "Hugo Boss", "Lacoste"};
            ListaAlmacen = new ObservableCollection<string>() { "Almacen1", "Almacen2", "Almacen3" };
            LoadProductsCommand = new LoadProductsCommand(this);
            LoadProductCommand = new LoadProductCommand(this);
            listaProductos = new ObservableCollection<ProductoModel>();
            CurrentProducto = new ProductoModel();
            NewProductoCommand = new NewProductoCommand(this);
            DeleteProductoCommand = new DeleteProductoCommand(this);
            EditProductoCommand = new EditProductoCommand(this);
        }
    }
}
