using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VendasCelulares.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome produto")]
        public string NomeProduto { get; set; }

        [Required]
        [Display(Name = "Preco")]
        public Decimal Preco { get; set; }

        public string Cor { get; set; }
        public string Imagens { get; set; }
    }
}
