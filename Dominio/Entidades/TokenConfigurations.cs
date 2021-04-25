using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
