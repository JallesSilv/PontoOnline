using Dominio.Contratos;
using Dominio.Entidades;
using Repositorio.Contexto;

namespace Repositorio.Repository
{
    public class NivelAcessoRepository : BaseRepository<NivelAcesso>, INivelAcessoRepository
    {
        public NivelAcessoRepository(PontoDbContext contexto) : base(contexto)
        {
        }
    }
}
