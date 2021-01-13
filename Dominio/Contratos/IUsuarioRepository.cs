using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Contratos
{
    public interface IUsuarioRepository: IBaseRepository<Usuario>
    {
        Usuario ObterUsuario(Usuario pUsuario );

        Usuario ObterToken(Login plogin);
    }
}
