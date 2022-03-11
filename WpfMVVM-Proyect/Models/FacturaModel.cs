using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM_Proyect.Models
{
    internal class FacturaModel : INotifyPropertyChanged, ICloneable
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
        private int idFactura;
        public int _idFactura
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
        private ClienteModel idCliente;
        public ClienteModel _idCliente
        {
            get
            {
                return idCliente;
            }
            set
            {
                idCliente = value;
                OnPropertyChanged(nameof(_idCliente));
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
        private double total;
        public double Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
                OnPropertyChanged(nameof(Total));
            }
        }

    }
}
