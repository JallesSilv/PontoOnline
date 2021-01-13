﻿using Repositorio.Migrations.XMigrationBanco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.Base
{
    public class XRodarMigrationBanco
    {
        public static void ExecutarBanco()
        {
            //MVersao_Migration.Versao_Migration();
            MBanco.Banco();
            MPonto.Ponto();
            MImagem.Imagem();
            MCargo.Cargo();
            MNivelAcesso.NivelAcesso();
            MEndereco.Endereco();
            MEmpresa.Empresa();
            MUsuario.Usuario();
            MPontoHistorico.PontoHistorico();
        }
    }
}
