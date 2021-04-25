using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Contratos
{
    public interface IEmpresaRepository:IBaseRepository<Empresa>
    {
        Empresa Create(Empresa pEmpresa);

        void DeleteId(Guid pChave);

        void Edit(Guid pChave, Empresa pCargo);

        IEnumerable<Empresa> ObterListaEmpresa();

    }
}
