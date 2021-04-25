using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contratos
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario ObterUsuario(Usuario pUsuario );

        Usuario UsuarioChave(Guid pChave);

        Task<Usuario> ObterToken(Usuario pLogin);

        Usuario GetUserFromAccessToken(string accessToken);

        Task<Usuario> Registrar(Usuario pLogin);
    }
}
