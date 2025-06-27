using GerFuncProd.Business.Models.Fornecedores;
using GerFuncProd.Business.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Context
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        { }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedors { get; set; }
    }
}
