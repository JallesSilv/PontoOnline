using Dominio.Contratos;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repositorio.Config;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Utilitarios.Seguranca;

namespace Repositorio.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly PontoDbContext contexto;
        public UsuarioRepository(PontoDbContext _contexto) : base(_contexto)
        {
            contexto = _contexto;
        }

        public async Task<Usuario> ObterToken(Usuario pLogin)
        {
            try
            {
                var validarUsuario = new Usuario();
                if (pLogin == null) return null;

                if (pLogin.Email != null)
                    validarUsuario = contexto.Usuario.Where(pR => pR.Email == pLogin.Email).FirstOrDefault();
                else
                    validarUsuario = contexto.Usuario.Where(pR => pR.Cpf == pLogin.Cpf).FirstOrDefault();

                var preencharSenha = XAesCrip.Decriptografar(validarUsuario.Senha);
                var confirmarSenha = XAesCrip.Decriptografar(pLogin.Senha);

                //if (validarUsuario.Cpf != pCpf && validarUsuario.Senha != pLogin.Senha)
                //if (validarUsuario.Cpf != pLogin.Cpf && preencharSenha != confirmarSenha)
                //    throw new Exception($@"Error:.. Dados de Acesso Incorreto!");

                if (pLogin.Email != null)
                    validarUsuario = await contexto.Usuario.Include(p => p.Cargo)
                        .Where(pR => pR.Email == pLogin.Email)
                        .FirstOrDefaultAsync();
                else
                    validarUsuario = await contexto.Usuario.Include(p => p.Cargo)
                        .Where(pR => pR.Cpf == pLogin.Cpf)
                        .FirstOrDefaultAsync();

                return validarUsuario;
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
                var pUser = contexto.Usuario.Include(p => p.Cargo).Where(pR => pR.ChaveUsuario == pUsuario.ChaveUsuario).FirstOrDefault();

                return pUser;
            }
            catch (Exception error)
            {

                throw new Exception($@"{error.Message}");
            }
        }

        public Usuario UsuarioChave(Guid pChave)
        {
            try
            {
                var pUser = contexto.Usuario
                        .Include(p => p.Cargo).ThenInclude(p=>p.NivelAcesso)
                        .Include(p => p.Empresa)
                        .Include(p => p.Endereco)
                    .Where(pR => pR.ChaveUsuario == pChave).FirstOrDefault();

                return pUser;
            }
            catch (Exception error)
            {

                throw new Exception($@"{error.Message}");
            }
        }

        public async Task<Usuario> Registrar(Usuario login)
        {
            var usuarioValido = contexto.Usuario.FirstOrDefault(pX=>pX.Cpf == login.Cpf && pX.Email == login.Email);

            if (usuarioValido != null)
            {
                var usuario = new Usuario()
                {
                    Cpf = login.Cpf,
                    Email = login.Email,
                    Senha = login.Senha
                };
                await contexto.AddAsync(usuario);
            }
            return await ObterToken(login); 
        }

        public Usuario GetUserFromAccessToken(string accessToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Token.Secret);

                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false
                };

                SecurityToken securityToken;

                var timeExpirar = tokenHandler.ReadJwtToken(accessToken).Claims.ToList();

                //var testestes = DateTime.Parse(timeExpirar[4].Value.);

                var expired = new DateTime(DateTime.UnixEpoch.AddSeconds(timeExpirar[4].Value.AsDouble()).Ticks);

                if (expired < DateTime.Now)
                {
                    return null;
                }
                else
                {
                    var principle = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);
                    JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;

                    if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    {
                        var userId = principle.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        Guid userGuid = Guid.Parse(userId);
                        return contexto.Usuario.Include(u => u.Cargo)
                                            .Where(u => u.ChaveUsuario == userGuid).FirstOrDefault();
                    }
                }                
            }
            catch (Exception eX)
            {
                throw new Exception();
            }

            return new Usuario();
        }
    }
}
