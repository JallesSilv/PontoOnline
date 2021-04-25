using Repositorio.Config;
using Repositorio.Migrations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.XMigrationBanco
{
    public class MPonto : XRodarMigrationBanco
    {
        public static void Ponto()
        {
            CriarTabelaSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("Ponto", "ChavePonto"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText = 
                         @"CREATE TABLE Ponto (
		                            [ChavePonto] [bigint] NOT NULL,
		                            [Data] [datetime] NULL,
	                                CONSTRAINT [PK_Ponto] PRIMARY KEY CLUSTERED 
	                                ([ChavePonto] ASC )
	                            WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) 
	                            ON [PRIMARY]
                            ) ON [PRIMARY]

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
