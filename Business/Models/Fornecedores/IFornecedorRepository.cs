/*
 * Nesta interface para fornecedor, herdamos todos os métodos da interface genérica passando o objetos fornecedor 
 * e implementamos métoso específicos de fornecedorneste caso 2 métodos
 */

using GerFuncProd.Business.Core.Data;
using System;
using System.Threading.Tasks;

namespace GerFuncProd.Business.Models.Fornecedores
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorEndereco(Guid Id);
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid Id);
    }
}
    