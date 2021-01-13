using Repositorio.Config;
using Repositorio.Migrations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.XMigrationBanco
{
    public class MNivelAcesso : XRodarMigrationBanco
    {
        public static void NivelAcesso()
        {
            CriarTabelaSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("NivelAcesso", "ChaveNivelAcesso"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText =
                         @"CREATE TABLE NivelAcesso(
	                            [ChaveNivelAcesso] [bigint] NOT NULL,
	                            [NomeNivelAcesso] [nvarchar](100) NULL,
	                            [Ativo] [bit] NULL,
                             CONSTRAINT [PK_NivelAcesso] PRIMARY KEY CLUSTERED 
                            (
	                            [ChaveNivelAcesso] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                            ) ON [PRIMARY]
                            GO
                         ";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela {XConfig.InitialCatalog}.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela Banco: {error.Message}");
                    }
                }
            }
        }
    }
}
