using GerFuncProd.Business.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerFuncProd.Business.Models.Produtos
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto> ObterProdutoFornecedor(Guid id);
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
    }
}
