using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM_Proyect.Models;
using WpfMVVM_Proyect.ViewModels;

namespace WpfMVVM_Proyect.Services
{
    class ProductosDBHandler
    {
        private static ObservableCollection<ProductoModel> listaProductos = new ObservableCollection<ProductoModel>();
        public static ObservableCollection<ProductoModel> ObtenerListaProductos()
        {
            return listaProductos;
        }
        public static bool NuevoProducto(ProductoModel producto)
        {
            bool insertar = false;
            try
            {
                listaProductos.Add(producto);
                insertar = true;
            }
            catch (Exception ex) { }

            return insertar;
        }
        public static ObservableCollection<ProductoModel> busquedaProductos(string palabra)
        {
            ObservableCollection<ProductoModel> lista = new ObservableCollection<ProductoModel>();
            foreach (ProductoModel p in listaProductos)
            {
                string precio = p.Precio.ToString();
                string stock = p.Stock.ToString();

                if (p._id.Equals(palabra))
                {
                    lista.Add(p);
                }
                else if (p.Tipo.Equals(palabra))
                {
                    lista.Add(p);
                }else if (p.Marca.Equals(palabra))
                {
                    lista.Add(p);
                }
                else if (p.Color.Equals(palabra))
                {
                    lista.Add(p);
                }else if (p.Referencia.Equals(palabra))
                {
                    lista.Add(p);
                }
                else if (p.Descripcion.Equals(palabra))
                {
                    lista.Add(p);
                }
                else if (precio.Equals(palabra))
                {
                    lista.Add(p);
                }
                else if (p.Fecha.Equals(palabra))
                {
                    lista.Add(p);
                }
                else if (stock.Equals(palabra))
                {
                    lista.Add(p);
                }

            }
            return lista;
        }
        public static bool EditProduct(ProductoModel producto)
        {
            bool editar = false;
            try
            {
                foreach(ProductoModel p in listaProductos)
                {
                    if (p._id.Equals(producto._id))
                    {
                        p.Proveedor = producto.Proveedor;
                        p.Tipo = producto.Tipo;
                        p.Marca = producto.Marca;
                        p.Color = producto.Color;
                        p.Referencia = producto.Referencia;
                        p.Descripcion = producto.Descripcion;
                        p.Precio = producto.Precio;
                        p.Fecha = producto.Fecha;
                        p.Stock = producto.Stock;
                        editar = true;
                        break;
                    }
                }    
            }
            catch
            {

            }
            return editar;
        }
        public static bool DeleteProducto(ProductoModel productoModel)
        {
            bool DeleteOk = false;
            try
            {
                foreach (ProductoModel p in listaProductos)
                {
                    if (p._id.Equals(productoModel._id))
                    {
                        listaProductos.Remove(p);
                        DeleteOk = true;
                        break;
                    }
                }
            }
            catch
            {

            }
            return DeleteOk;
        }
        public static void CargarLista()
        {
            Random r = new Random();
            string proveedor = "almacen1";
            string proveedor2 = "almacen2";
            listaProductos = new ObservableCollection<ProductoModel>();
            for (int i = 0; i < 20; i++)
            {
                ProductoModel p = new ProductoModel();
                p._id = i.ToString();
                p.Proveedor.Add(proveedor);
                p.Proveedor.Add(proveedor2);
                p.Tipo = "Tipo: " + i.ToString();
                p.Marca = "Marca" + i.ToString();
                p.Color = "Color: " + i.ToString();
                p.Referencia = "Ref: " + r.Next(100,99999) + "S";
                p.Descripcion = "Des: " + i.ToString();
                p.Precio = r.Next(10,200);
                p.Fecha = DateTime.Today;
                p.Stock = r.Next(0, 200);
                listaProductos.Add(p);
            }
        }
        public static ObservableCollection<String> CargarListaProveedor(ProductoModel p)
        {
            ObservableCollection<String> almacens = new ObservableCollection<string>();
            for (int i = 0; i < p.Proveedor.Count; i++)
            {
                almacens.Add(p.Proveedor.ElementAt(i));
                
            }
            return almacens;
        }
        public static async Task<bool> NuevoEstudiante(ProductoModel estudiante)
        {
            bool okinsertar = false;

            var handler = new WinHttpHandler();
            var client = new HttpClient(handler);

            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5000/productos");

            var data = JsonConvert.SerializeObject(estudiante);

            request.Headers.Add("Accept", "application/json");
            request.Content = new StringContent(data.ToString(), Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseJSON = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseJSON);
                okinsertar = true;
            }

            return okinsertar;
        }
    }
}
