using System;
using System.Diagnostics;
using System.Net;

class Program
{
    static void Main()
    {
        Console.Write("url: ");
        string URL = Console.ReadLine();

        DNSLookup(URL);
    }

    static void DNSLookup(string URL)
    {
        try
        {
            Uri URI = new Uri(URL);
            string HOST = URI.Host;

            var arec = Dns.GetHostAddresses(HOST);
            Console.WriteLine("A:");
            foreach (var ip in arec)
            {
                Console.WriteLine(ip);
            }

            Console.WriteLine("\ngetting other records using nslookup...");

            RunNslookup(HOST, "MX");
            RunNslookup(HOST, "NS");
            RunNslookup(HOST, "CNAME");
            RunNslookup(HOST, "TXT");
            RunNslookup(HOST, "PTR");
            RunNslookup(HOST, "SOA");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"error: {ex.Message}");
        }
    }

    static void RunNslookup(string HOST, string recordType)
    {
        try
        {
            ProcessStartInfo deploy = new ProcessStartInfo("nslookup")
            {
                Arguments = $"-type={recordType} {HOST}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process perform = Process.Start(deploy);
            string output = perform.StandardOutput.ReadToEnd();
            perform.WaitForExit();

            Console.WriteLine($"{recordType} records:");
            Console.WriteLine(output);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"error running nslookup for {recordType}: {ex.Message}");
        }
    }
}
