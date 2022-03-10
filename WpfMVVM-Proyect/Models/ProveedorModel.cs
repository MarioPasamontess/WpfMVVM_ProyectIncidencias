using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM_Proyect.Models
{

    public class ProveedorModel: INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ProveedorModel()
        {
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        private String id;
        public String _id
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
        private String nombre;
        public String Nombre
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
        private String poblacion;
        public String Poblacion
        {
            get
            {
                return poblacion;
            }
            set
            {
                poblacion = value;
                OnPropertyChanged(nameof(Poblacion));
            }
        }
        private int telefono;

        public int Telefono
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

    }
}
