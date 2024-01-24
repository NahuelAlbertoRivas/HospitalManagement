using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelos
{
    public partial class DbConexion : DbContext
    { 
        private DbConexion(string nombreConexion) // se recibe el nombre de la conexión, la cual establecerá la comunicación con la DB
            : base(nombreConexion) // se invoca constructor de clase base 
        {   // las primeras propiedades se heredan de ' DbContext ' 
            this.Configuration.LazyLoadingEnabled = false; // evitar que objetos anidados dentro de otros se carguen automáticamente haciendo uso de las propiedades ' get/set '; esto debido al la referenciación cíclica de objetos y la necesidad de convertirlos a json
            this.Configuration.ProxyCreationEnabled = false; // no cargar de manera automática objetos relacionados con otros que se están consultando actualmente (está de alguna manera asociado similarmente a la sentencia anterior)
            this.Database.CommandTimeout = 900; // tiempo de espera de respuesta de la DB
        }

        public static DbConexion Create() // método que facilita la creación de la conexión a la DB
        {
            return new DbConexion("name=DbConexion");
        }
    }
}
