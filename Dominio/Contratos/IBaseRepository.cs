using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Contratos
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Create(TEntity entity);

        TEntity ObterChave(Guid pChave);

        IEnumerable<TEntity> ObterTodos();

        void Edit(TEntity entity);

        void Delete(TEntity entity);
    }
}
