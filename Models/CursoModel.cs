using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaFaculdade.Models
{
    public class CursoModel
    {
        [Key]
        public int IdCurso { get; set; }

        [Required]
      
        public string NomeCurso { get; set; }

        
    }
}
