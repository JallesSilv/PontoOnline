using Dominio.Contratos;
using Dominio.Entidades;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repository
{
    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(PontoDbContext contexto) : base(contexto)
        {
        }
    }
}
