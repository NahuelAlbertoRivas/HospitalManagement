using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.ViewModels
{
    public class ListadoPaginadoVMR<T>{ // este VM se crea debido a la necesidad de retornar la cantidad total de elementos de una colección y una lista reducida; ' T ' indica que será un típo genérico, así se puede aplicar esta clase dinámicamente a cada objeto que se le aplique
        public int cantidadTotal { get; set; }
        public IEnumerable<T> elemento { get; set; } // ' IEnumerable ' aporta a la genericidad

        public ListadoPaginadoVMR(){
            elemento = new List<T>();
            cantidadTotal = 0;
        }
    }
}
