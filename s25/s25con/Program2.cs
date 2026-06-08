using System.Diagnostics;
using System.Text.RegularExpressions;

namespace s25con;


class Program
{
    static void Main(string[] args)
    {
        Regex re = new Regex(@"([0-9]+\.){3}[0-9]+");

        using HttpClient client = new HttpClient();
        string c = client.GetStringAsync("https://p30download.ir/").Result;
        if (re.IsMatch(c))
        {
            foreach(var m in re.Matches(c))
            {
                System.Console.WriteLine(m);
            }
        }
    }

    static void Main2343(string[] args)
    {
        Regex re = new Regex(@"([0-9]+\.){3}[0-9]+");
        string[] ips = new string[]
        {
            "1.1.1.1",
            "192.224.1.2",
            "192.224.1",
        };
        foreach(var e in ips)
            if (re.IsMatch(e))
                System.Console.WriteLine("yes");
            else
                System.Console.WriteLine("no");        
    }

    static void Main343(string[] args)
    {
        Regex re = new Regex(@"[a-z,A-Z,0-9]+@([a-z,A-Z,0-9]+\.)+([a-z,A-Z,0-9]+)");
        string[] emails = new string[]
        {
            "sauleh@gmail.com",
            "test.com",
            "ali@",
        } ;
        foreach(var e in emails)
            if (re.IsMatch(e))
                System.Console.WriteLine("yes");
            else
                System.Console.WriteLine("no");
    }
}
