using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Config
{
    public static class XExtension
    {
        public static string AsString(this object pValor)
        {
            if (pValor is null) return string.Empty;
            return Convert.ToString(pValor);
        }

        public static decimal AsDecimal(this string pValor)
        {
            if (pValor is null) return 0;
            return Convert.ToDecimal(pValor.Replace(".", ","));
        }

        public static double AsDouble(this object pValor)
        {
            if (pValor is null) return 0;
            return Convert.ToDouble(pValor);
        }

        public static DateTime AsDateTime(this object pValor)
        {
            if (pValor is null) return DateTime.Now.Date;
            return Convert.ToDateTime(pValor);
        }

        public static bool EstaVazio(this string pValor)
        {
            return string.IsNullOrEmpty(pValor);
        }

        public static bool AsBool(this string pValor)
        {
            return Convert.ToBoolean(pValor);
        }

        public static Int64 AsInt64(this object pValor)
        {
            return (Int64)Convert.ToInt64(pValor);
        }

        public static int AsInt32(this object pValor)
        {
            return (int)Convert.ToInt32(pValor);
        }
    }
}
