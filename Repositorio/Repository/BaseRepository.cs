using Dominio.Contratos;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly PontoDbContext Contexto;

        public BaseRepository(PontoDbContext contexto)
        {
            Contexto = contexto;
        }

        public TEntity Create(TEntity entity)
        {
            try
            {
                Contexto.Set<TEntity>().Add(entity);
                Contexto.SaveChanges();
                return entity;
            }
            catch (Exception error)
            {

                throw new Exception($@"{error.Message}");
            }
        }

        public void Edit(TEntity entity)
        {
            Contexto.Set<TEntity>().Update(entity);

            Contexto.SaveChanges();
        }

        public TEntity ObterChave(Guid pChave)
        {
            try
            {
                return Contexto.Set<TEntity>().Find(pChave);
            }
            catch (Exception error)
            {

                throw new Exception($@"{error.Message}");
            }
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            try
            {
                return Contexto.Set<TEntity>().ToList();
            }
            catch (Exception error)
            {

                throw new Exception($@"{error.Message}");
            }
        }

        public void Delete(TEntity entity)
        {
            Contexto.Set<TEntity>().Remove(entity);
            Contexto.SaveChanges();
        }

        public void Dispose()
        {
            try
            {
                Contexto.Dispose();
            }
            catch (Exception error)
            {

                throw new Exception($@"{error.Message}");
            }

        }        
    }
}
