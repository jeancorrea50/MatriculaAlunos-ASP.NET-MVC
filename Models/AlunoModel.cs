using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaFaculdade.Models
{
    public class AlunoModel
    {
        [Key]
        public int IdAluno { get; set; }

        [Required, MaxLength(128)]
        [DisplayName("Nome Completo")]
        public string NomeCompleto { get; set; }

        [Required, Column(TypeName = "char(14)")]
        public string CPF { get; set; }


      

        [Required, MaxLength(128)]
        public string Email { get; set; }

      
        public DateTime? DataCadastro { get; }


        public DateTime DataNascimento { get; set; }

        [NotMapped]
        public int Idade
        {
            get => (int)Math.Floor((DateTime.Now - DataNascimento).TotalDays / 365.2425);
        }

        [ForeignKey("Curso")]
        public int IdCurso { get; set; }

        public CursoModel Curso { get; set; }

       
    }
}
