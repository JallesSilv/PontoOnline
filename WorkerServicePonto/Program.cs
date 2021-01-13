using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Hosting;
using Repositorio.Config;
using WsPonto;

namespace WorkerServicePonto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args, XConfig.StateMode.AsBool());
            //Console.ReadLine();

        }

        public static void CreateHostBuilder(string[] args, bool console)
        {
            string _ip = XUtilitarios.GetLocalIPv4(NetworkInterfaceType.Ethernet, Dns.GetHostName());
            string url = $"http://0.0.0.0:5001";
            //string url = $"http://{_ip}:5001";
            //string url = $"http://localhost:5001";

            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            var pathToContentRoot = Path.GetDirectoryName(pathToExe);

            var host = WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(pathToContentRoot)
                .UseUrls(url)
                .UseStartup<Startup>()
                .Build();

            if (console)
                host.Run();
            else
                host.RunAsService();
        }
    }
}
