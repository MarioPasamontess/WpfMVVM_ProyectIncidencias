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
    class ProveedoresViewModel : ViewModelBase
    {
        public ICommand ProveedorCommand { set; get; }

        private ProveedorModel currentProveedor { set; get; }
        public ProveedorModel CurrentProveedor 
        {
            get
            {
                return currentProveedor;
            }
            set
            {
                currentProveedor = value;
                OnPropertyChanged(nameof(CurrentProveedor));
            }
        }
        public ICommand LoadProveedorCommand { get; set; }
        public ICommand LoadProveedoresCommand { get; set; }
        public ProveedoresViewModel()
        {
            ListaProveedores = new ObservableCollection<ProveedorModel>();
            LoadProveedorCommand = new LoadProveedorCommand(this);
            LoadProveedoresCommand = new LoadProveedoresCommand(this);
            CurrentProveedor = new ProveedorModel();
            ProveedorCommand = new ProveedorCommand(this);
            DeleteProveedorCommand = new DeleteProveedorCommand(this);
            EditProveedorCommand = new EditProveedorCommand(this);
        }
        private ObservableCollection<ProveedorModel> listaProveedores { get; set; }
        public ObservableCollection<ProveedorModel> ListaProveedores
        {
            get { return listaProveedores; }
            set { listaProveedores = value; OnPropertyChanged(nameof(ListaProveedores)); }
        }
        private ProveedorModel selectedProveedor;
        public ProveedorModel SelectedProveedor { get { return selectedProveedor; } set { selectedProveedor = value; OnPropertyChanged(nameof(selectedProveedor)); } }
        public ICommand DeleteProveedorCommand { set; get; }
        public ICommand EditProveedorCommand { set; get; }
    }
}
