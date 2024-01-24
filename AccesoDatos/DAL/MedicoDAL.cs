using Comun.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.DAL
{
    public class MedicoDAL{
        public static Crear(){
        }

        public static MedicoVMR LeerUno(long id){
            MedicoVMR item = new MedicoVMR();
            return item;
        }

        public static ListadoPaginadoVMR<MedicoVMR> LeerTodo(int cantElementos, int pagina, string textoBusqueda){ // ' cantElementos ': cantidad de ítems que se mostrarán en una página; ' pagina ': nro. de página a la que se accede; ' textoBusqueda ': cadena clave recibida por el input de búsqueda por la cual se filtrará la búsqueda
            ListadoPaginadoVMR<MedicoVMR> listado = new ListadoPaginadoVMR<MedicoVMR>();
            return listado;
        }

        public Actualizar(){
        }

        public Eliminar(){
        }
}
}
