using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfMVVM_Proyect.Views
{
    /// <summary>
    /// Lógica de interacción para ProveedoresView.xaml
    /// </summary>
    public partial class ProveedoresView : UserControl
    {
        public ProveedoresView()
        {
            InitializeComponent();
            E00EstadoInicial();
        }
        public void E00EstadoInicial()
        {
            id.IsEnabled = true;
            GridProveedor.Visibility = Visibility.Visible;
            btnCrear.Visibility = Visibility.Visible;
            GridListaProveedor.IsEnabled = true;
            btnModificar.Visibility = Visibility.Collapsed;
            btnBorrar.Visibility = Visibility.Collapsed;
        }
        public void E01MostrarProveedor()
        {
            id.IsEnabled = false;
            GridProveedor.Visibility = Visibility.Visible;
            GridListaProveedor.IsEnabled = false;
            btnCrear.Visibility = Visibility.Collapsed;
            btnModificar.Visibility = Visibility.Visible;
            btnBorrar.Visibility = Visibility.Visible;
        }
        private void proveedorlistView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            E01MostrarProveedor();
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            E00EstadoInicial();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            //E00EstadoInicial();
        }
        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            E00EstadoInicial();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            E01MostrarProveedor();
        }
    }
}
