using GerFuncProd.Business.Models.Fornecedores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Mappings
{
    //EntityTypeConfiguration é usada no Entity Framework 6 (não no EF Core!) para fazer a configuração das entidades do modelo
    //— mapeando propriedades, chaves, nomes de tabelas, relacionamentos, etc. — de forma fluente (via Fluent API), fora da classe de contexto.
    public class FornecedorConfig : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorConfig()
        {
            //Mapeando chaves
            HasKey(f => f.Id);


            //Mapeando Propriedades
            Property(f => f.Nome).IsRequired()
                                 .HasMaxLength(200);

            Property(f => f.Documento).IsRequired()
                                      .HasMaxLength(14)
                                      //Transforma a coluna documento em um Index,que no banco fará o mapeamento de forma rapida
                                      .HasColumnAnnotation("IX_Documento", new IndexAnnotation(new IndexAttribute { IsUnique = true}));


            //Relacionamentos
            HasRequired(f => f.Endereco).WithRequiredPrincipal(e => e.Fornecedor);



            //Nome da tabela
            ToTable("Fornecedores");

        }
    }
}
