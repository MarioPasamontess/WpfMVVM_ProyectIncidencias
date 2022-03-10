using WpfMVVM_Proyect.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM_Proyect.Services.DataSet.ProyectoDataSetTableAdapters;

namespace WpfMVVM_Proyect.Services.DataSet
{
    class DataSetHandler
    {
        private static InformeTableAdapter adapter = new InformeTableAdapter();
        private static clienteTableAdapter clienteAdapter = new clienteTableAdapter();
        public static ObservableCollection<ClienteModel> getCliente()
        {
            DataTable clieDataTable = clienteAdapter.GetData();
            ObservableCollection<ClienteModel> listaClientes = new ObservableCollection<ClienteModel>();
            foreach (DataRow clie in clieDataTable.Rows)
            {
                ClienteModel myClie = new ClienteModel();
                myClie._dni = (int)clie["DNI"];
                myClie.Nombre = clie["Nombre"].ToString();
                myClie.Direccion = clie["Direccion"].ToString();
                myClie.Telefono = clie["Telefono"].ToString();
                myClie.Mail = clie["Email"].ToString();

                listaClientes.Add(myClie);
            }
            return listaClientes;
            {

            }
        }
        public static DataTable GetDataByFactura(int idF)
        {
            return adapter.GetData(idF);
        }
        private static productoTableAdapter productoAdapter = new productoTableAdapter();
        public static ObservableCollection<ProductoModel2> getProducto()
        {
            DataTable prosDataTable = productoAdapter.GetData();
            ObservableCollection<ProductoModel2> listaProductos = new ObservableCollection<ProductoModel2>();
            foreach (DataRow pro in prosDataTable.Rows)
            {
                ProductoModel2 myPro = new ProductoModel2();
                myPro._id = (int)pro["Id"];
                myPro.Tipo = pro["Tipo"].ToString();
                myPro.Marca = pro["Marca"].ToString();
                myPro.Color = pro["Color"].ToString();
                myPro.Referencia = pro["Referencia"].ToString();
                myPro.Descripcion = pro["Descripcion"].ToString();
                myPro.Precio = (double)pro["Precio"];
                myPro.Stock = (int)pro["Stock"];
                myPro.Cantidad = (int)pro["Cantidad"];

                listaProductos.Add(myPro);
            }
            return listaProductos;
            {

            }
        }
        private static detalleFacturaTableAdapter detalleAdapter = new detalleFacturaTableAdapter();
        public static int GetUltimaFactura()
        {
            DataRow ultimoRegistro = detalleAdapter.GetData().Last();
            int idUltimaFactura = (int)ultimoRegistro["IdFactura"];
            return idUltimaFactura;
        }
        private static productoTableAdapter productAdapter = new productoTableAdapter();
        public static bool InsertarProducto(ProductoModel2 p)
        {
            int id = 3;
            try
            {
                productAdapter.Insert(id,p.Tipo,p.Marca, p.Color, p.Referencia,p.Descripcion,p.Precio, p.Stock, p.Cantidad);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
