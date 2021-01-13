using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace Repositorio.Config
{
    public class XBaseConfig
    {
        public XBaseConfig() { }

        public static string Get<TProperty>(Expression<Func<TProperty>> pProperty)
        {
            MemberExpression member;
            member = (MemberExpression)pProperty.Body;
            return Get(member.Member.Name);
        }

        public static string Get(string pPropertyName)
        {
            string path = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            var fileJson = File.ReadAllText($@"{path}\configuracoes.json");
            var objetoJson = JObject.Parse(fileJson);
            string result = string.Empty;
            try
            {
                result = objetoJson.SelectToken(pPropertyName).Value<string>();
            }
            catch { }

            return result;
        }
    }
}
