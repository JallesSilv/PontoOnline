using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Repositorio.Config
{
	public class XLog
	{
		public static void RegistraLog(string strMensagem, string strNomeArquivo)
		{
			var caminho = "C:/temp/";
			try
			{
				using (var writer = new StreamWriter($"{caminho}{strNomeArquivo}_{DateTime.Now.ToString("ddMMyy")}.txt", true))
				{
					writer.WriteLine("-------------------------------------------------------------");
					writer.WriteLine($"Data e hoário: {DateTime.Now.ToString("ddMMyy hh:MM")} - {strMensagem}");
					writer.Close();
					writer.Dispose();
				}
			}
			catch (Exception eX)
			{
				if (Environment.UserInteractive)
					Console.WriteLine($"Não foi possível gravar o log.: {eX.Message}");
			}
		}
	}
}
