using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfMVVM_Proyect.Models;

namespace WpfMVVM_Proyect.Services
{
    class ProveedoresDBHandler
    {
        private static ObservableCollection<ProveedorModel> listaProveedores = new ObservableCollection<ProveedorModel>();
        public static bool EditProveedor(ProveedorModel proveedorModel)
        {
            bool editOk = false;
            try
            {
                foreach( ProveedorModel p in listaProveedores)
                {
                    if (p._id.Equals(proveedorModel._id))
                    {
                        p.Nombre = proveedorModel.Nombre;
                        p.Poblacion = proveedorModel.Poblacion;
                        p.Telefono = proveedorModel.Telefono;
                        editOk = true;
                        break;
                    }
                }
            }
            catch
            {

            }
            return editOk;
        }
        public static bool DeleteProveedor(ProveedorModel proveedorModel)
        {
            bool DeleteOk = false;
            try
            {
                foreach (ProveedorModel p in listaProveedores)
                {
                    if (p._id.Equals(proveedorModel._id))
                    {
                        listaProveedores.Remove(p);
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

        public static bool NuevoProveedor(ProveedorModel proveedor)
        {
            /* try
             {
                 foreach (ProveedorModel p in listaProveedores)
                 {
                     if (!p._id.Equals(proveedor._id))
                     {
                         listaProveedores.Add(proveedor);
                         MessageBox.Show("Proveedor " + proveedor.Nombre + " creado correctamente");
                         return true;
                     }
                     else
                     {
                        // view.warning.Text = "Ya existe este codigo de barras";
                         //
                         //insertar = false;
                     }
                 }

             }
             catch (Exception e)
             {
                 MessageBox.Show("Error al crear el proveedor " + proveedor.Nombre + ". Error: " + e.Message);
                 return false;
             }
               Boolean okinsertar = false;
               Boolean encontrado = false;
               try
               {
                   foreach (ProveedorModel pr in listaProveedores)
                   {

                       if (pr._id.Equals(proveedor._id))
                       {
                           encontrado = true;
                           break;
                       }

                   }
                   if (!encontrado)
                   {
                       listaProveedores.Add(proveedor);
                       okinsertar = true;
                   }
                   else
                   {
                       okinsertar = false;
                   }
               }
               catch (Exception ex) { }

               return okinsertar;
           }*/
            bool insertarOk = false;
            try
            {
                listaProveedores.Add(proveedor);
                insertarOk = true;
            }
            catch (Exception ex) { }          
                return insertarOk;
        }
        public static ObservableCollection<ProveedorModel> ObtenerListaProveedores()
        {
            return listaProveedores;
        }
        public static void CargarLista()
        {
            listaProveedores = new ObservableCollection<ProveedorModel>();
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
               ProveedorModel p = new ProveedorModel();
                p._id = i.ToString();
                p.Nombre = "Nombre: " + i.ToString();
                p.Poblacion = "Población: " + i.ToString();
                p.Telefono =  r.Next(100000,999999);
                listaProveedores.Add(p);
            }

        }
    }
}
