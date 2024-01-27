using Comun.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using Modelo.Modelos;

namespace AccesoDatos.DAL
{
    public class MedicoDAL{
        public static long Crear(Medico item){ // una vez creada la instancia, se devuelve el id

            using (var db = DbConexion.Create())
            { // permite declarar la conexión a la DB
                item.borrado = false;
                db.Medico.Add(item);
                db.SaveChanges();
            }

            return item.id;
        }

        public static MedicoVMR LeerUno(long id){
            MedicoVMR item = null;

            using (var db = DbConexion.Create()){ // permite declarar la conexión a la DB
                item = db.Medico.Where(x => !x.borrado && x.id == id).Select(x => new MedicoVMR{
                    id = x.id,
                    cedula = x.cedula,
                    nombre = x.nombre,
                    apellidoMaterno = x.apellidoMaterno,
                    apellidoPaterno = x.apellidoPaterno,
                    habilitado = x.habilitado,
                    esEspecialista = x.esEspecialista
                }).FirstOrDefault(); // si no encuentra primer elemento, devuelve null
            }

            return item;
        }

        public static ListadoPaginadoVMR<MedicoVMR> LeerTodo(int cantItems, int pagina, string textoBusqueda){ // ' cantItems ': cantidad de ítems que se mostrarán en una página; ' pagina ': nro. de página a la que se accede; ' textoBusqueda ': cadena clave recibida por el input de búsqueda por la cual se filtrará la búsqueda
            ListadoPaginadoVMR<MedicoVMR> listado = new ListadoPaginadoVMR<MedicoVMR>();

            using (var db = DbConexion.Create()){ // permite declarar la conexión a la DB
                var query = db.Medico.Where(x => !x.borrado).Select(x => new MedicoVMR{ // ver consultas parciales, uso del ' .Where '; expresiones Lambda permiten declarar objetos del tipo tabla (estructura de DB) en tiempo de escritura
                    id = x.id,
                    cedula = x.cedula,
                    nombre = x.nombre, //+ " " + x.apellidoPaterno + (x.apellidoMaterno != null? (" " + x.apellidoMaterno) : ""),
                    apellidoMaterno = x.apellidoMaterno,
                    apellidoPaterno = x.apellidoPaterno,
                    habilitado = x.habilitado,
                    esEspecialista = x.esEspecialista
                });

                if (!string.IsNullOrEmpty(textoBusqueda)){
                    query = query.Where(x => x.cedula.Contains(textoBusqueda) || x.nombre.Contains(textoBusqueda));
                }

                listado.cantidadTotal = query.Count();

                listado.elemento = query
                    .OrderBy(x => x.id)
                    .Skip(pagina * cantItems)
                    .Take(cantItems)
                    .ToList(); // " .Skips " permite justamente saltar una cierta cantidad de páginas; " .Take " indica cota superior de elementos a mostrar, en este caso será la misma ' cantItems '; ' ToList ' lo convierte a lista de objetos
            }

            return listado;
        }

        public static void Actualizar(MedicoVMR item){ // no retornarán valor alguno ya que se controlará el estado de la fn. a través de excepciones

            using (var db = DbConexion.Create())
            { // permite declarar la conexión a la DB
                var itemUpdate = db.Medico.Find(item.id);

                itemUpdate.cedula = item.cedula;
                itemUpdate.nombre = item.nombre;
                itemUpdate.apellidoMaterno = item.apellidoMaterno;
                itemUpdate.apellidoPaterno = item.apellidoPaterno;
                itemUpdate.habilitado = item.habilitado;
                itemUpdate.esEspecialista = item.esEspecialista;

                db.Entry(itemUpdate).State = System.Data.Entity.EntityState.Modified; // si se encuentra y todo sale ok, esta línea se encarga de ' commitear ' los cambios
                db.SaveChanges(); // se actualiza la DB y guarda la nueva info.
            }

        }

        public static void Eliminar(List<long> ids){

            using (var db = DbConexion.Create())
            { // permite declarar la conexión a la DB
                var items = db.Medico.Where(x => ids.Contains(x.id));

                foreach (var item in items){ // realmente hacemos un ' borrado lógico ', lo que implica un simple update donde se indica particularmente en el campo ' borrado ' esta nueva condición
                    item.borrado = true;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();
            }

        }
    }
}
