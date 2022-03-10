using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM_Proyect.Models
{
    class ProductoModel : INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        public ProductoModel()
        {
            fecha = DateTime.Today;
            proveedor = new ObservableCollection<string>();
        }
        public object Clone()
        {
            return MemberwiseClone();
        }

        private string id;
        public string _id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged(nameof(_id));
            }
        }
        private ObservableCollection<string> proveedor;
        public ObservableCollection<string> Proveedor
        {
            get
            {
                return proveedor;
            }
            set
            {
                proveedor = value;
                OnPropertyChanged(nameof(Proveedor));
            }
        }
        private string tipo;
        public string Tipo
        {
            get
            {
                return tipo;
            }
            set
            {
               tipo = value;
                OnPropertyChanged(nameof(Tipo));
            }
        }
        private string marca;
        public string Marca
        {
            get
            {
                return marca;
            }
            set
            {
                marca = value;
                OnPropertyChanged(nameof(Marca));
            }
        }
        private string color;
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                OnPropertyChanged(nameof(Color));
            }
        }
        private string referencia;
        public string Referencia
        {
            get
            {
                return referencia;
            }
            set
            {
                referencia = value;
                OnPropertyChanged(nameof(Referencia));
            }
        }
        private string descripcion;
        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                descripcion = value;
                OnPropertyChanged(nameof(Descripcion));
            }
        }

        private double precio;
        public double Precio
        {
            get
            {
                return precio;
            }
            set
            {
                precio = value;
                OnPropertyChanged(nameof(Precio));
            }
        }
        private DateTime fecha;
        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
                OnPropertyChanged(nameof(Fecha));
            }
        }
        private int stock;
        public int Stock
        {
            get
            {
                return stock;
            }
            set
            {
                stock = value;
                OnPropertyChanged(nameof(Stock));
            }
        }
        private int cantidad;
        public int Cantidad
        {
            get
            {
                return cantidad;
            }
            set
            {
                cantidad = value;
                OnPropertyChanged(nameof(Cantidad));
            }
        }
        public override string ToString()
        {
            return "Id: " + id + ",Marca: " + marca + ",Tipo: " + tipo;
        }
    }
}
