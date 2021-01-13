using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.Base
{
    public abstract class XMigration
    {
        public abstract void Executar();
    }
}
