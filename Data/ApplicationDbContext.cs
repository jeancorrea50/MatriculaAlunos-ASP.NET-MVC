using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VendasCelulares.Models;

namespace VendasCelulares.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
            public DbSet<CarrinhoDeCompa> CarrinhoDeCompras { get; set; }
            public DbSet<Produto> Produtos { get; set; }
    }
    }


