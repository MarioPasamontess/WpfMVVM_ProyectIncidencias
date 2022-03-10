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
   
    public partial class ProductosView : UserControl
    {
        public ProductosView()
        {
            InitializeComponent();
            E00EstadoInicial();
        }
        public void E00EstadoInicial()
        {
            codBarras.IsEnabled = true;
            GridPrincipal.Visibility = Visibility.Visible;
            GridSecundario.Visibility = Visibility.Visible;
            ProductoListView.IsEnabled = true;
            btnBorrar.Visibility = Visibility.Collapsed;
            btnModificar.Visibility = Visibility.Collapsed;
            btnCrear.Visibility = Visibility.Visible;
        }
        public void E01MostrarProducto()
        {
            codBarras.IsEnabled = false;
            GridPrincipal.Visibility = Visibility.Visible;
            GridSecundario.Visibility = Visibility.Visible;
            ProductoListView.IsEnabled = false;
            btnBorrar.Visibility = Visibility.Visible;
            btnModificar.Visibility = Visibility.Visible;
            btnCrear.Visibility = Visibility.Collapsed;
        }
        private void ProductoListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            E01MostrarProducto();
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

        }
    }
}
