using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM_Proyect.Models
{
    public class ResponseModel
    {
        public object data { set; get; }
        public bool resultOk { set; get; }

        public ResponseModel()
        {
            data = "Error en la consulta";
            resultOk = false;
        }
    }
}
