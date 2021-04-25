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
    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        private readonly PontoDbContext contexto;
        public EmpresaRepository(PontoDbContext _contexto) : base(_contexto)
        {
            contexto = _contexto;
        }

        public void DeleteId(Guid pChave)
        {
            var result = contexto.Empresa.FirstOrDefault(p => p.ChaveEmpresa == pChave);
            contexto.Remove(result);
            contexto.SaveChanges();
        }

        public Empresa Create(Empresa pEmpresa)
        {
            try
            {                
                Contexto.Add(pEmpresa);
                Contexto.SaveChanges();
                return pEmpresa;
            }
            catch (Exception error)
            {

                throw new Exception($@"{error.Message}");
            }
        }

        public void Edit(Guid pChave, Empresa pEmpresa)
        {
            try
            {

                var empresa = Contexto.Empresa.Where(pX => pX.ChaveEmpresa == pChave);

                empresa.Select(pX => new Empresa() {
                    NomeEmpresa = pEmpresa.NomeEmpresa,
                    Cnpj = pEmpresa.Cnpj,
                    Inscricao = pEmpresa.Inscricao,
                    DataCadastro = pEmpresa.DataCadastro,
                    Endereco = new Endereco()
                    {
                        Cep = pEmpresa.Endereco.Cep,
                        Uf = pEmpresa.Endereco.Uf,
                        Estado = pEmpresa.Endereco.Estado,
                        Cidade = pEmpresa.Endereco.Cidade,
                        Bairro = pEmpresa.Endereco.Bairro,
                        Complemento = pEmpresa.Endereco.Complemento,
                        Ddd = pEmpresa.Endereco.Ddd
                    }
                });

                Contexto.Update(empresa);
                Contexto.SaveChanges();
            }
            catch (Exception error)
            {
                throw new Exception($@"{error.Message}");
            }
        }

        public IEnumerable<Empresa> ObterListaEmpresa()
        {
            try
            {
                return Contexto.Set<Empresa>().Include(p => p.Endereco).ToList();
            }
            catch (Exception error)
            {

                throw new Exception($@"{error.Message}");
            }
        }
    }
}
