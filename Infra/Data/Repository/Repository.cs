using GerFuncProd.Business.Core.Data;
using GerFuncProd.Business.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GerFuncProd.Infra.Data.Context;
using System.Data.Entity;
using System.Linq;


namespace GerFuncProd.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        //Contexto geral 
        protected readonly MeuDbContext Db;
        //Acesso rapido a entidade que está sendo manipulada
        protected readonly DbSet<TEntity> DbSet;


        protected Repository()
        {
            Db = new MeuDbContext();
            DbSet = Db.Set<TEntity>();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        //Aqui começa os métodos de persistência ou transação de dados
        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            Db.Entry(new TEntity { Id = id }).State = EntityState.Deleted;
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}

/*Na  realização da interface genérica os métodos são do tipo  virtual para que possam ser sobrescritos cajo ajá essa necissidade*/