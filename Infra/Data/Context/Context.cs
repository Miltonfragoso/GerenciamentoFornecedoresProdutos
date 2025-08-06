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
        { 
            Configuration.ProxyCreationEnabled = false; //Desabilita a criação de proxies dinâmicos para as entidades
            Configuration.LazyLoadingEnabled = false; //Desabilita o carregamento preguiçoso (Lazy Loading) das entidades
        }


        //Mapeando os DbSets
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedors { get; set; }


        //É um método virtual fornecido pela classe DbContext, que permite configurar o mapeamento entre suas classes (entidades)
        //e o banco de dados de forma mais avançada Configuração via Fluent API
       //Permite definir regras de mapeamento como Nome da tabela ou coluna Tamanho de campos(HasMaxLength) Chaves primárias e estrangeiras
       //Relacionamentos(HasOne, HasMany, etc.)  Restrições e índices
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //Otimizando o script(modelagem via contexto) para criar o banco de dados 
            //Removendo convenções configurados por padrão


            //Removendo essa conveção para que os nomes das tabelas sejam criadas no plural
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Removendo essa conveção para que não seja deletado todos relacionamenotos 1 para muitos ex: se deletar fornecedores não deleta os produtos desse fornecedor 
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Removendo essa conveção para que não seja deletado todos relacionamenotos N para N ex: se deletar fornecedores não deleta os produtos desse fornecedor 
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();



            modelBuilder.Properties<string>()
                        .Configure(c => c.HasColumnType("varchar") //Define o tipo de coluna como varchar
                        .HasMaxLength(100)); //Define o tamanho máximo da coluna como 100 caracteres    



            modelBuilder.Configurations.Add(new FornecedorConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());


            base.OnModelCreating(modelBuilder);

        }


    }
}
