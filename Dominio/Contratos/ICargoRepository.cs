using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Contratos
{
    public interface ICargoRepository : IBaseRepository<Cargo>
    {   
        void DeleteId(Guid pChave);

        void Edit(Guid pChave, Cargo pCargo);

        IEnumerable<Cargo> ObterListaCargo();
    }
}
