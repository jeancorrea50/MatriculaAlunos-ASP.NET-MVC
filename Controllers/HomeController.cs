using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VendasCelulares.Models;

namespace VendasCelulares.Controllers
{
    public class HomeController : Controller
    {
      

        public IActionResult Index()
        {
            List<Produto> Produtos = new List<Produto>();
            Produtos.Add(new Produto() { Id = 1, NomeProduto = "Iphone XR", Preco = 2.400M, Cor = "Branco", Imagens = "IphoneXRBranco.jpg" });
            Produtos.Add(new Produto() { Id = 2, NomeProduto = "Iphone 11", Preco = 3.200M, Cor = "Branco", Imagens = "Iphone11.jpg" });
            Produtos.Add(new Produto() { Id = 3, NomeProduto = "Iphone 11 Mini", Preco = 2.800M, Cor = "Vermelho", Imagens = "Iphone11Red.jpg" });
            Produtos.Add(new Produto() { Id = 4, NomeProduto = "Iphone 12 Pro Max", Preco = 6.400M, Cor = "Cinza", Imagens = "Iphone12ProMax.jpg" });

            ViewBag.produtos = Produtos;

            return View();
        }

     
    }
}
