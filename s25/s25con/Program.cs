using System.Diagnostics;

namespace s25con2;

class Program
{
    static async Task<(string,int)> MyDownloadAsync(string url)
    {
        using HttpClient client = new HttpClient();
        string content = await client.GetStringAsync(url);
        string sub = content.Substring(0,50);
        int len = content.Length;
        return (sub,len);
    }


    static void Main2134123(string[] args)
    {
        var t1 = MyDownloadAsync("https://dl2.soft98.ir/soft/w/WinRAR.7.22.x64.zip?1780899803");
        var t2 = MyDownloadAsync("https://dl2.soft98.ir/soft/w/WinRAR.7.22.x64.exe?1780899803");

        System.Console.WriteLine(t1.Result);
        System.Console.WriteLine(t2.Result);
    }


    static void Main3432423(string[] args)
    {

        using HttpClient client = new HttpClient();
        Stopwatch sw = Stopwatch.StartNew();
        // 
        // var t1 = client.GetStringAsync("https://p30download.ir/");
        var t1 = client.GetStringAsync("https://dl2.soft98.ir/soft/w/WinRAR.7.22.x64.zip?1780899803");
        Console.WriteLine(t1.Result.Substring(0, 50));
        Console.WriteLine(t1.Result.Length);

        var t2 = client.GetStringAsync("https://dl2.soft98.ir/soft/w/WinRAR.7.22.x64.exe?1780899841");
        Console.WriteLine(t2.Result.Substring(0, 50));
        Console.WriteLine(t2.Result.Length);

        System.Console.WriteLine(sw.Elapsed);
    }



    static async Task<double> DoWork(int n)
    {
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: DoWork #1");
        Task<int> t1 = new Task<int>(() =>
        {
            System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: DoWork #1");
            return 10 * 15;
        });
        t1.Start();
        int w = await t1;
        double final = 1;
        for(int i = 1; i< w; i++)
            final *= i;

        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: DoWork #1");
        return final;
    }

    static async Task DoWork3(int n)
    {
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: DoWork #1");
        await Task.Delay(500);
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: DoWork #2");
        await Task.Delay(500);
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: DoWork #3");
        await Task.Delay(500);
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: DoWork #4");
        await Task.Delay(500);
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: DoWork #5");
        await Task.Delay(500);
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: DoWork #6");        
    }

    static async Task DoWork1(int n)
    {
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: DoWork Start");
        var t = new Task( () =>
        {
            System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: DoWork inside Task");
            double product =1;
            for(int i=1; i<n; i++)
                product *= i;            
            System.Console.WriteLine(product);            
        });
        t.Start();
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: DoWork after Start");
        await t;
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: DoWork after await");
    }

    static void Main4(string[] args)
    {
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: Main - Before DoWork");
        var t = DoWork(10000);
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: Main - After DoWork");
        t.Wait();
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: Main - Done");
    }
}
