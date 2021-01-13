using Repositorio.Config;
using Repositorio.Migrations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.XMigrationBanco
{
  
    public class MUsuario : XRodarMigrationBanco
    {
        public static void Usuario()
        {
            CriarTabelaSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("Usuario", "ChaveUsuario"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText =
                         @"CREATE TABLE Usuario(
	                            [ChaveUsuario] [bigint] NOT NULL,
	                            [ChaveEmpresa] [bigint] NULL,
	                            [ChaveNivelAcesso] [bigint] NULL,
	                            [ChaveCargo] [bigint] NULL,
	                            [ChaveEndereco] [bigint] NULL,
	                            [Nome] [nvarchar](100) NULL,
	                            [CPF] [bigint] NULL,
	                            [Ativo] [bit] NULL,
                             CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
                            (
	                            [ChaveUsuario] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                            ) ON [PRIMARY]
                            GO

                            ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Cargo] FOREIGN KEY([ChaveCargo])
                            REFERENCES [dbo].[Cargo] ([ChaveCargo])
                            GO

                            ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Cargo]
                            GO

                            ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Empresa] FOREIGN KEY([ChaveEndereco])
                            REFERENCES [dbo].[Endereco] ([ChaveEndereco])
                            GO

                            ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Empresa]
                            GO

                            ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Endereco] FOREIGN KEY([ChaveEndereco])
                            REFERENCES [dbo].[Endereco] ([ChaveEndereco])
                            GO

                            ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Endereco]
                            GO

                            ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_NivelAcesso] FOREIGN KEY([ChaveNivelAcesso])
                            REFERENCES [dbo].[NivelAcesso] ([ChaveNivelAcesso])
                            GO

                            ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_NivelAcesso]
                            GO

                            ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Usuario] FOREIGN KEY([ChaveUsuario])
                            REFERENCES [dbo].[Usuario] ([ChaveUsuario])
                            GO

                            ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Usuario]
                            GO
                         ";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela {XConfig.InitialCatalog}.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela Usuario: {error.Message}");
                    }
                }
            }
        }
    }
}
