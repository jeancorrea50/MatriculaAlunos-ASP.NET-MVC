using Matricula;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaFaculdade.Data
{
    public class MatriculaDbContext : DbContext
    {

        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<CursoModel> Cursos { get; set; }



        // String de conexão com o Banco de dados (SQL)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // string C com o banco de dados sql server
            optionsBuilder.UseSqlServer("Password=Bf18102907;Persist Security Info=True;User ID=jeancpcorrea;Initial Catalog=Matricula Alunos;Data Source=DESKTOP-43O4B71\\SQLEXPRESS");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // to passando que o novo das tabelas no banco de dados será "Categoria " e "Produto", caso nao passe este parametro, será criado no pural, ex "Produtos" 
            modelBuilder.Entity<AlunoModel>().ToTable("Aluno");
            modelBuilder.Entity<CursoModel>().ToTable("Curso");

        }
    }
}
