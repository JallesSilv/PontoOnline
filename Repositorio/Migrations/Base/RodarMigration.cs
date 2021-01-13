using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.Base
{
    public class RodarMigration : XMigration
    {
        public override void Executar()
        {
            XRodarMigrationBanco.ExecutarBanco();

        }
    }
}
