using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM_Proyect.Models
{
    class DetalleFacturaModel : INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
        private int idDetalle;
        public int _idDetalle
        {
            get
            {
                return idDetalle;
            }
            set
            {
                idDetalle = value;
                OnPropertyChanged(nameof(_idDetalle));
            }
        }
        private FacturaModel idFactura;
        public FacturaModel _idFactura
        {
            get
            {
                return idFactura;
            }
            set
            {
                idFactura = value;
                OnPropertyChanged(nameof(_idFactura));
            }
        }
        private ProductoModel idProducto;
        public ProductoModel _idProducto
        {
            get
            {
                return idProducto;
            }
            set
            {
                idProducto = value;
                OnPropertyChanged(nameof(_idProducto));
            }
        }
        private String descripcion;
        public String Descripcion
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
    }
}
