using Repositorio.Config;
using Repositorio.Migrations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.XMigrationBanco
{
    public class MEmpresa : XRodarMigrationBanco
    {
        public static void Empresa()
        {
            CriarTabelaSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("Empresa", "ChaveEmpresa"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText =
                         @"CREATE TABLE Empresa(
	                            [ChaveEmpresa] [bigint] NOT NULL,
	                            [NomeEmpresa] [nchar](10) NULL,
	                            [Cnpj] [bigint] NULL,
	                            [Inscricao] [nvarchar](50) NULL,
	                            [DataCadastro] [datetime] NULL,
	                            [ChaveEndereco] [bigint] NULL,
                                [Ativo] [bit] NULL,
                                CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
                            (
	                            [ChaveEmpresa] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                            ) ON [PRIMARY]

                            ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Endereco] FOREIGN KEY([ChaveEndereco])
                            REFERENCES [dbo].[Endereco] ([ChaveEndereco])

                            ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_Endereco]
                         ";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela {XConfig.InitialCatalog}.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela Empresa: {error.Message}");
                    }
                }
            }
        }
    }
}
