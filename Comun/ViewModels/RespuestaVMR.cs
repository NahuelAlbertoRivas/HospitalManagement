using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Comun.ViewModels
{
    public class RespuestaVMR<T>
    {
        public HttpStatusCode codigo { get; set; } // rta. que permite saber si la transacción fue exitosa o no
        public T datos { get; set; } // se define tipo genérico (en tiempo de ejecución se reemplaza dinámicamente con el correspondiente) para manejar cualquier estructura en cuestión
        public List<string> mensajes { get; set; } // si hubo errror, esta almacenará la info. asociada al mismo
        
        public RespuestaVMR()
        {
            codigo = HttpStatusCode.OK;
            datos = default(T); // asigna info. inicial de acuerdo al tipo de dato que adquiera en tiempo de ejecución
            mensajes = new List<string>();
        }
    }
}
