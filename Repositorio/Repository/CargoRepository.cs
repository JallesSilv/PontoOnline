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
    public class CargoRepository : BaseRepository<Cargo>, ICargoRepository
    {
        private readonly PontoDbContext contexto;
        public CargoRepository(PontoDbContext _contexto) : base(_contexto)
        {
            contexto = _contexto;
        }

        public void DeleteId(Guid pChave)
        {
            var result = contexto.Cargo.FirstOrDefault(p=>p.ChaveCargo == pChave);
            contexto.Remove(result);
            contexto.SaveChanges();
        }

        public Cargo Create(Cargo pCargo)
        {
            try
            {
                pCargo.NivelAcesso = null;
                Contexto.Add(pCargo);
                Contexto.SaveChanges();
                return pCargo;
            }
            catch (Exception error)
            {

                throw new Exception($@"{error.Message}");
            }
        }


        public void Edit(Guid pChave, Cargo pCargo)
        {
            try
            {
                pCargo.NivelAcesso = null;
                var cargo = Contexto.Cargo.FirstOrDefault(pX => pX.ChaveCargo == pChave);
                cargo.NomeCargo = pCargo.NomeCargo;
                cargo.ChaveNivelAcesso = pCargo.ChaveNivelAcesso;
                Contexto.Update(cargo);
                Contexto.SaveChanges();
            }
            catch (Exception error)
            {
                throw new Exception($@"{error.Message}");
            }
        }

        public IEnumerable<Cargo> ObterListaCargo()
        {
            try
            {
                return Contexto.Set<Cargo>().Include(p=>p.NivelAcesso).ToList();
            }
            catch (Exception error)
            {

                throw new Exception($@"{error.Message}");
            }
        }
    }
}
