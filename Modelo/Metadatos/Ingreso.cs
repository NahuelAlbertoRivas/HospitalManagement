using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelos
{
    [MetadataType(typeof(IngresoMetadato))]
    public partial class Ingreso
    {
    }

    public class IngresoMetadato{
        [Required]
        public long idPaciente { get; set; }
        [Required]
        public long idRegClinico { get; set; }
        [Required]
        public System.DateTime fecha { get; set; }
        [Required]
        public int nroSala { get; set; }
        [Required]
        public int nroCama { get; set; }
        [Required]
        public string diagnostico { get; set; }
    }
}
