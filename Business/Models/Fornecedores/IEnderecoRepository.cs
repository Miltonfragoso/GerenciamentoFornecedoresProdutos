/*
 * Nesta interface herdamos todos os métodos da interface genérica 
 * e implementamos uma método para obter endereço apartir do id do fornecedor
 */
using Business.Core.Data;
using System;
using System.Threading.Tasks;

namespace GerFuncProd.Business.Models.Fornecedores
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}