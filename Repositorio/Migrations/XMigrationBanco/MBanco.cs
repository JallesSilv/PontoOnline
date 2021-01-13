using Repositorio.Config;
using Repositorio.Migrations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.XMigrationBanco
{
    public class MBanco : XRodarMigrationBanco
    {
        public static void Banco()
        {
            CriarBancoSql();
        }

        private static void CriarBancoSql()
        {
            if (!VerificarExisteTabela.ExisteTabela($"{XConfig.InitialCatalog}"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText =
                         $@"CREATE DATABASE {XConfig.InitialCatalog}
                         ";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela {XConfig.InitialCatalog}.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela Ponto: {error.Message}");
                    }
                }
            }
        }
    }
}
