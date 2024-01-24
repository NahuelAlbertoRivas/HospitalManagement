using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelos
{
    [MetadataType(typeof(RegistroClinicoMetadato))]
    public partial class RegistroClinico
    {
        
    }

    public class RegistroClinicoMetadato{
        [Required]
        public long idPaciente { get; set; }
        [Required]
        public long idMedico { get; set; }
    }
}
