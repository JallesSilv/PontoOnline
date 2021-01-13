using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace Repositorio.Config
{
    public class XUtilitarios
    {
        public static string GetLocalIPv4(NetworkInterfaceType pTipo, string pHostname)
        {
            string output = "";
            try
            {
                foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (item.OperationalStatus == OperationalStatus.Up && item.NetworkInterfaceType == pTipo)
                    {
                        IPInterfaceProperties adapterProperties = item.GetIPProperties();
                        if (adapterProperties.GatewayAddresses.FirstOrDefault() != null)
                        {
                            foreach (UnicastIPAddressInformation ip in adapterProperties.UnicastAddresses)
                            {
                                if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                                {
                                    output = ip.Address.ToString();
                                }
                            }
                        }
                    }
                }
                if (string.IsNullOrWhiteSpace(output))
                {
                    var ips = Dns.GetHostAddresses(pHostname).Where(pX => pX.AddressFamily == AddressFamily.InterNetwork).Select(px => px.ToString()).ToArray();
                    var ip = ips.FirstOrDefault(pX => !pX.EndsWith("."));
                    output = ip ?? ips.FirstOrDefault();
                }
            }
            catch
            {

                return "";
            }
            return output;
        }
    }
}
