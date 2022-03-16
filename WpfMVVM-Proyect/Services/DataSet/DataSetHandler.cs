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
        private static FacturaTableAdapter facturaAdapter = new FacturaTableAdapter();
        private static detalleFacturaTableAdapter detallesFacturaAdapter = new detalleFacturaTableAdapter();
        public static ObservableCollection<ClienteModel> getCliente()
        {
            DataTable clieDataTable = clienteAdapter.GetData();
            ObservableCollection<ClienteModel> listaClientes = new ObservableCollection<ClienteModel>();
            foreach (DataRow clie in clieDataTable.Rows)
            {
                ClienteModel myClie = new ClienteModel();
                myClie._dni = clie["DNI"].ToString();
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
            return adapter.GetDataByIdFactura(idF);
        }
        public static DataTable GetDataByClient(string dni)
        {
            return adapter.GetDataByDNICliente(dni);
        }
        public static DataTable GetDataByFecha(DateTime fecha)
        {
            return adapter.GetDataByFecha(fecha.ToString());
        }
        public static DataTable GetDataByCliFecha(string dni, DateTime fecha1, DateTime fecha2)
        {
            return adapter.GetDataByDateClient(dni,fecha1.ToString(), fecha2.ToString());
        }
        public static DataTable GetDataByFechas(DateTime fecha1, DateTime fecha2)
        {
            return adapter.GetDataByFechas(fecha1.ToString(), fecha2.ToString());
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
        public static bool insertarFactura(string dni, DateTime fecha, double total, ObservableCollection<ProductoModel2> listaProductos2)
        {
            try
            {
                facturaAdapter.Insert(dni,fecha.ToString(),total);
                DataRow ultimoRegistro = facturaAdapter.GetData().Last();
                int idUltimaFactura = (int)ultimoRegistro["Identificador"];
                foreach (ProductoModel2 p in listaProductos2)
                {
                    detallesFacturaAdapter.Insert(idUltimaFactura,p._id, p.Descripcion, p.Cantidad, p.Precio);
                }

                return true;
            }
            catch
            {
                return false;
            }

        }

        public static string GetClienteByDNI(string dni)
        {
            try
            {
                DataTable clienteDT = adapter.GetDataByDNICliente(dni);
                DataRow clienteRow = clienteDT.Rows[0];
                string dniCliente = (string)clienteRow["DNI"];
                return dniCliente;
            }
            catch
            {
                return "";
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
            try
            {
                productAdapter.Insert(p.Tipo,p.Marca, p.Color, p.Referencia,p.Descripcion,p.Precio, p.Stock, p.Cantidad, p.Total.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
