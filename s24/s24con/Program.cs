namespace s24con2;

class InOutTask<Tin,Tout>
{
    public static int task_count = 0;
    public Tin input {get; set;}
    public Tout output {get; set;}
}

class Program
{
    static AutoResetEvent tasks_done = new AutoResetEvent(false);

    static void DoWork(object obj)
    {
        InOutTask<int,int> task = (InOutTask<int,int>) obj;
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: start-{task.input}");
        Thread.Sleep(100);
        task.output = task.input * 2;
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: end-{task.input}");
        if (0 == Interlocked.Decrement(ref InOutTask<int,int>.task_count))
            tasks_done.Set();

    }

    static void Main2(string[] args)
    {
        List<InOutTask<int,int>> tasks = new List<InOutTask<int, int>>();
        for(int i=0; i<40; i++)
        {
            var t = new InOutTask<int,int>() {input = i};
            Interlocked.Increment(ref InOutTask<int,int>.task_count);
            tasks.Add(t);
            ThreadPool.QueueUserWorkItem(DoWork, t);
        }

        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: main-wait");
        tasks_done.WaitOne();
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: main-done");
    }
}
