using Dominio.Contratos;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly PontoDbContext contexto;
        public UsuarioRepository(PontoDbContext _contexto) : base(_contexto)
        {
            contexto = _contexto;
        }

        public Usuario ObterToken(Login pLogin)
        {
            try
            {
                Int64 pCpf = Convert.ToInt64(pLogin.Cpf);
                return contexto.Usuario.Include(p => p.NivelAcesso).Where(pR => pR.Cpf == pCpf && pR.Senha == pLogin.Senha).FirstOrDefault();
            }
            catch (Exception error)
            {

                throw new Exception($@"{error.Message}");
            }
        }

        public Usuario ObterUsuario(Usuario pUsuario)
        {
            try
            {
                var pUser = contexto.Usuario.Include(p => p.NivelAcesso).Where(pR => pR.ChaveUsuario == pUsuario.ChaveUsuario).FirstOrDefault();

                return pUser;
            }
            catch (Exception error)
            {

                throw new Exception($@"{error.Message}");
            }
        }
    }
}
