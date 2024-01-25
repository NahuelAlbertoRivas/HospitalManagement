using Comun.ViewModels;
using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DAL;

namespace Logica.BLL
{
    public class MedicoBLL // acá se llaman a los métodos correspondientes de la capa acceso a datos
    {
        public static long Crear(Medico item){
            return MedicoDAL.Crear(item);
        }

        public static MedicoVMR LeerUno(long id){
            return MedicoDAL.LeerUno(id);
        }

        public static ListadoPaginadoVMR<MedicoVMR> LeerTodo(int cantItems, int pagina, string textoBusqueda){
            return MedicoDAL.LeerTodo(cantItems, pagina, textoBusqueda);

        }

        public static void Actualizar(MedicoVMR item){
            MedicoDAL.Actualizar(item);
        }

        public static void Eliminar(List<long> ids){
            MedicoDAL.Eliminar(ids);
        }
    }
}
