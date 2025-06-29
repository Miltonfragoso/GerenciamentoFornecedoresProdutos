using GerFuncProd.Business.Models.Fornecedores;
using GerFuncProd.Business.Models.Produtos;
using Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection.Emit;
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


        //É um método virtual fornecido pela classe DbContext, que permite configurar o mapeamento entre suas classes (entidades)
        //e o banco de dados de forma mais avançada Configuração via Fluent API
       //Permite definir regras de mapeamento como Nome da tabela ou coluna Tamanho de campos(HasMaxLength) Chaves primárias e estrangeiras
       //Relacionamentos(HasOne, HasMany, etc.)  Restrições e índices
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new FornecedorConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());

        }


    }
}
