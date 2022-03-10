using WpfMVVM_Proyect.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Proyect.ViewModels;

namespace WpfMVVM_Proyect.Commands
{
    class UpdateViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine(parameter.ToString());
            string vista = parameter.ToString();
            if (vista.Equals("Home"))
            {
                MainViewModel.SelectedViewModel = new HomeViewModel();
            }else if (vista.Equals("proveedores"))
            {
                MainViewModel.SelectedViewModel = new ProveedoresViewModel();
            }else if (vista.Equals("productos"))
            {
                MainViewModel.SelectedViewModel = new ProductosViewModel();
            }
            else if (vista.Equals("factura"))
            {
                MainViewModel.SelectedViewModel = new FormularioViewModel();
            }
            else if (vista.Equals("report"))
            {
                MainViewModel.SelectedViewModel = new ReportViewModel();
            }
            /*else if (vista.Equals("consulta"))
            {
                MainViewModel.SelectedViewModel = new ConsultaViewModel();
            }*/

        }
        public MainViewModel MainViewModel { get; set; }
        public ReportViewModel reportViewModel { set; get; }
        public UpdateViewCommand(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            MainViewModel.SelectedViewModel = new HomeViewModel();
            reportViewModel = new ReportViewModel();
        }
    }
}
