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
                         @"CREATE TABLE Usuario (
	                            [ChaveUsuario] [bigint] NOT NULL,
	                            [ChaveEmpresa] [bigint] NULL,
	                            [ChaveCargo] [bigint] NULL,
	                            [ChaveEndereco] [bigint] NULL,
	                            [Nome] [nvarchar](100) NULL,
	                            [Email] [nvarchar](100) NULL,
	                            [CPF] [bigint] NULL,
	                            [Ativo] [bit] NULL,
	                            [Senha] [nvarchar](1000) NULL,
                             CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
                            (
	                            [ChaveUsuario] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                            ) ON [PRIMARY]

                            ALTER TABLE Usuario SET (LOCK_ESCALATION = AUTO)

                            ALTER TABLE Usuario  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Cargo] FOREIGN KEY([ChaveCargo])
                            REFERENCES Cargo ([ChaveCargo])

                            ALTER TABLE Usuario CHECK CONSTRAINT [FK_Usuario_Cargo]

                            ALTER TABLE Usuario  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Empresa] FOREIGN KEY([ChaveEndereco])
                            REFERENCES Endereco ([ChaveEndereco])

                            ALTER TABLE Usuario CHECK CONSTRAINT [FK_Usuario_Empresa]

                            ALTER TABLE Usuario  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Endereco] FOREIGN KEY([ChaveEndereco])
                            REFERENCES Endereco ([ChaveEndereco])

                            ALTER TABLE Usuario CHECK CONSTRAINT [FK_Usuario_Endereco]

                            ALTER TABLE Usuario  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Usuario] FOREIGN KEY([ChaveUsuario])
                            REFERENCES Usuario ([ChaveUsuario])

                            ALTER TABLE Usuario CHECK CONSTRAINT [FK_Usuario_Usuario]
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
