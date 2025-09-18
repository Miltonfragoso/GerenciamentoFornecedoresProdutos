using GerFuncProd.Business.Models.Fornecedores;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace GerFuncProd.Infra.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                               .FirstOrDefaultAsync(f => f.Id == fornecedorId);

            /* Ou
             * return await Db.ObterPorId(fornecedorId);
             * porque os ID são os mesmos
             */
        }
    }
}
