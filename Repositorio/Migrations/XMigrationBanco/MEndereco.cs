using Repositorio.Config;
using Repositorio.Migrations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.XMigrationBanco
{
    public class MEndereco : XRodarMigrationBanco
    {
        public static void Endereco()
        {
            CriarTabelaSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("Endereco", "ChaveEndereco"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText =
                         @"CREATE TABLE Endereco(
	                            [ChaveEndereco] [bigint] NOT NULL,
	                            [Cep] [nvarchar](100) NULL,
	                            [Logradouro] [nvarchar](100) NULL,
	                            [Complemento] [nvarchar](100) NULL,
	                            [Bairro] [nvarchar](100) NULL,
	                            [Localidade] [nvarchar](100) NULL,
	                            [Uf] [nvarchar](100) NULL,
	                            [Ibge] [nvarchar](100) NULL,
	                            [Gia] [nvarchar](100) NULL,
	                            [Ddd] [nvarchar](100) NULL,
	                            [Siafi] [nvarchar](100) NULL,
                             CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
                            (
	                            [ChaveEndereco] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                            ) ON [PRIMARY]
                            GO
                         ";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela {XConfig.InitialCatalog}.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela Endereco: {error.Message}");
                    }
                }
            }
        }
    }
}
