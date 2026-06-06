using System.Collections.Immutable;

namespace s24con;

class Program
{
    static async Task<int> DoWork(int n)
    {
        return 5;
    }
    static void Main(string[] args)
    {
        Task<int> t = new Task<int>( o =>
        {
            int n = (int) o;
            System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: t1 start");
            Thread.Sleep(500);
            System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: t1 done");
            return n * 2;
        }, 5);
        var tnew = t.ContinueWith(t2 => {
            System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: t2 start");
            Thread.Sleep(500);
            System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: t2 done");
            return t2.Result * 5;
        });
        t.Start();
        tnew.Wait();
        System.Console.WriteLine(t.Result);

        //Console.ReadLine();
        // Task<int> t = new Task<int>( o => Random.Shared.Next(), null);
        // t.Start();
        // t.Wait();
        // System.Console.WriteLine(t.Result);
    }


    static void Main33(string[] args)
    {
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: main-start");
        var tasks = 
            Enumerable.Range(1,25).Select(n => new Task<int>(o =>
                    {
                        int n = (int) o;
                        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: start");
                        Thread.Sleep(500);
                        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: end");            
                        return n * 2;                        
                    }, n))
                    .ToList();
        tasks.ForEach(t => t.Start());
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: main-waiting");

        Task.WaitAll(tasks);        
        tasks.ForEach(t => System.Console.WriteLine(t.Result));
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: main-finished");        
    }
}
