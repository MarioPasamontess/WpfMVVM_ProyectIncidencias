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
    /// Lógica de interacción para ConsultaView.xaml
    /// </summary>
    public partial class ConsultaView : UserControl
    {
        public ConsultaView()
        {
            InitializeComponent();
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            cbClient.Visibility = Visibility.Visible;
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            cbClient.Visibility=Visibility.Collapsed;
        }
    }
}
