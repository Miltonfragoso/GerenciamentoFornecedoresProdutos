/*
 * Na pasta Core teremos todos os objetos base da aplicação
 * A classe Entity do tipo abstract que somente vai ser herdada
 * A classe tem uma propriedade do tipo Guid e no método constrtutor 
 * é gerado um novo Guid toda vez que uma classe que herda a classe Entity for instanciada
 * O Guid define o Id da entidade antes de persistir no banco já podendo relacionar com outra entidade
 * diferente do Int
 */

using System;

namespace GerFuncProd.Business.Core.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
