using System.Security;

namespace s23con;

class InOut
{
    public int input {get; set;}
    public int output {get; set;}
}

class Program
{

    static void worker2(object o)
    {
        var t = o as InOut;
        t.output = t.input * 2;    

        if (Interlocked.Decrement(ref remaining_tasks) == 0)    
            allworkfinished.Set();
    }
    static void Main(string[] args)
    {
        remaining_tasks = 100;
        var tasks = Enumerable.Range(1,remaining_tasks)
                  .Select(n => new InOut() {input = n});

        var threads = tasks.Select(d => (t:new Thread(worker2), d))
                  .ToList();

        threads.ForEach(p => p.t.Start(p.d));

        // ThreadPool.QueueUserWorkItem(x[0]);

        allworkfinished.WaitOne();

        foreach(var d in threads)
            System.Console.WriteLine(d.d.output);        
    }


    static void Main3333(string[] args)
    {
        AutoResetEvent input_entered = new AutoResetEvent(false);
        AutoResetEvent ready_for_input = new AutoResetEvent(true);
        string input = string.Empty;
        Thread t = new Thread( () =>
        {
            while(true)
            {
                ready_for_input.WaitOne();
                Console.Write($"{Thread.CurrentThread.ManagedThreadId}: Input? ");
                input = Console.ReadLine();
                input_entered.Set();
            }
        });
        t.Start();

        // ;
        // t.Join();

        while(input_entered.WaitOne())
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: input is \"{input}\"");
            ready_for_input.Set();
        }
        
    }



    static void worker(object o)
    {
        int x = (int) o;
        for(int i=0; i<x; i++)
        {
            Console.Write($"{Thread.CurrentThread.ManagedThreadId}:-");
            Thread.Sleep(300);
        }
        System.Console.WriteLine();
        if (0  == Interlocked.Decrement(ref remaining_tasks))
            allworkfinished.Set();
    }    
    static int total_tasks;
    static int remaining_tasks;
    static bool all_tasks_submitted = false;

    static AutoResetEvent allworkfinished = new AutoResetEvent(false);
    static void Main2343(string[] args)
    {
        total_tasks = 25;
        var threads = Enumerable.Range(1, total_tasks)
                  .Select(_ => Random.Shared.Next(1, 20))
                  .Select(n => (t:new Thread(worker), n))
                  .ToList();                  
        threads.ForEach(p => {
            p.t.Start(p.n);
            Interlocked.Increment(ref remaining_tasks);
        });

        while (! allworkfinished.WaitOne(500))
            System.Console.WriteLine($"\nRemaining: {remaining_tasks}");

        System.Console.WriteLine("All threads are done.");

    }
}
