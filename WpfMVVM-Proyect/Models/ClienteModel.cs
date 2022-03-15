using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM_Proyect.Models
{
    class ClienteModel : INotifyPropertyChanged, ICloneable
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
        private string dni;
        public string _dni
        {
            get
            {
                return dni;
            }
            set
            {
                dni = value;
                OnPropertyChanged(nameof(_dni));
            }
        }
        private string nombre;
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }
        private string direccion;
        public string Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                direccion = value;
                OnPropertyChanged(nameof(Direccion));
            }
        }
        private string telefono;
        public string Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                telefono = value;
                OnPropertyChanged(nameof(Telefono));
            }
        }
        private string mail;
        public string Mail
        {
            get
            {
                return mail;
            }
            set
            {
                mail = value;
                OnPropertyChanged(nameof(Mail));
            }
        }
        public override string ToString()
        {
            return "DNI: "  + dni + ",nombre: " + nombre;
        }

    }
}
