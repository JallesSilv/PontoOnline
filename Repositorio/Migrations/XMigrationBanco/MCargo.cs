using Repositorio.Config;
using Repositorio.Migrations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.XMigrationBanco
{
    public class MCargo : XRodarMigrationBanco
    {
        public static void Cargo()
        {
            CriarTabelaSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("Cargo", "ChaveCargo"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText =
                         @"CREATE TABLE Cargo(
	                            [ChaveCargo] [bigint] NOT NULL,
	                            [NomeCargo] [nvarchar](50) NULL,
                             CONSTRAINT [PK_Cargo] PRIMARY KEY CLUSTERED 
                            (
	                            [ChaveCargo] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                            ) ON [PRIMARY]
                         ";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela {XConfig.InitialCatalog}.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela Cargo: {error.Message}");
                    }
                }
            }
        }
    }
}
