using Repositorio.Config;
using Repositorio.Migrations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.XMigrationBanco
{
    public class MPontoHistorico : XRodarMigrationBanco
    {
        public static void PontoHistorico()
        {
            CriarTabelaSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("PontoHistorico", "ChavePontoHistorico"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText =
                         @"CREATE TABLE PontoHistorico(
	                            [ChavePontoHistorico] [bigint] NOT NULL,
	                            [Horas] [time](7) NULL,
	                            [Observacao] [nvarchar](500) NULL,
	                            [ChavePonto] [bigint] NULL,
	                            [ChaveUsuario] [bigint] NULL,
	                            [ChaveImagem] [bigint] NULL,
                             CONSTRAINT [PK_PontoHistorico] PRIMARY KEY CLUSTERED 
                            (
	                            [ChavePontoHistorico] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                            ) ON [PRIMARY]
                            GO

                            ALTER TABLE [dbo].[PontoHistorico]  WITH CHECK ADD  CONSTRAINT [FK_PontoHistorico_Imagem] FOREIGN KEY([ChaveImagem])
                            REFERENCES [dbo].[Imagem] ([ChaveImagem])
                            GO

                            ALTER TABLE [dbo].[PontoHistorico] CHECK CONSTRAINT [FK_PontoHistorico_Imagem]
                            GO

                            ALTER TABLE [dbo].[PontoHistorico]  WITH CHECK ADD  CONSTRAINT [FK_PontoHistorico_Ponto] FOREIGN KEY([ChavePonto])
                            REFERENCES [dbo].[Ponto] ([ChavePonto])
                            GO

                            ALTER TABLE [dbo].[PontoHistorico] CHECK CONSTRAINT [FK_PontoHistorico_Ponto]
                            GO

                         ";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela {XConfig.InitialCatalog}.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela PontoHistorico: {error.Message}");
                    }
                }
            }
        }
    }
}
