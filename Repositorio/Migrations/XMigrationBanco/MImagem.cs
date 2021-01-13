using Repositorio.Config;
using Repositorio.Migrations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.XMigrationBanco
{
    public class MImagem : XRodarMigrationBanco
    {
        public static void Imagem()
        {
            CriarTabelaSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("Imagem", "ChaveImagem"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText =
                         @"CREATE TABLE Imagem(
	                            [ChaveImagem] [bigint] NOT NULL,
	                            [DataInicio] [datetime] NULL,
	                            [DataFinal] [datetime] NULL,
	                            [ByteImagem] [binary](8000) NULL,
                             CONSTRAINT [PK_Imagem] PRIMARY KEY CLUSTERED 
                            (
	                            [ChaveImagem] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                            ) ON [PRIMARY]
                            GO
                         ";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela {XConfig.InitialCatalog}.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela Imagem: {error.Message}");
                    }
                }
            }
        }
    }
}
