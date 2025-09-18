/*
 * Essa interface vai persistir qualquer entidade fazendo o básico de persistencia (CRUD)
 * O TEntity representa uma entidade generica porque não sabemos qual entidade será persistida
 * 
 * Então temos uma interface que é um contrato, que é genérico pode ser passado uma entidade que herda de Entity 
 * e o Dispose faz a limpeza apos seus uso
 */


using GerFuncProd.Business.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GerFuncProd.Business.Core.Data
{
    public  interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar (TEntity entity);
        Task <TEntity> ObterPorId (Guid id);
        Task <List<TEntity>> ObterTodos ();
        Task Atualizar (TEntity entity);
        Task Remover (Guid id);

        //Este método buscar retorna uma coleção de entidades, porém ele vai receber como parâmetro de busca uma expressão lambda personalizada
        Task<IEnumerable<TEntity>> Buscar (Expression<Func<TEntity, bool>> predicate);

        //Neste método salvar, o int vai simbolizar se o objeto foi salvo ou não, 1 representa que sim e 0 significa que nada foi salvo
        Task<int> SaveChanges();
    }
} 