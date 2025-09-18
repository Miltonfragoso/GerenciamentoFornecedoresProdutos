using GerFuncProd.Business.Models.Fornecedores;
using System;
using System.Data.Entity;
using System.Threading.Tasks;


namespace GerFuncProd.Infra.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public async Task<Fornecedor> ObterFornecedorEndereco(Guid Id)
        {
            return await Db.Fornecedors.AsNoTracking()
                                       .Include(f => f.Endereco)
                                       .FirstOrDefaultAsync(f => f.Id == Id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid Id)
        {
            return await Db.Fornecedors.AsNoTracking()
                                      .Include(f => f.Produtos)
                                      .Include(f => f.Endereco)
                                      .FirstOrDefaultAsync(f => f.Id == Id);
        }
    }
}
