using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace s22con;

class Program
{
    static object mylock = new object();
    static object mylock2 = new object();

    static void thread11()
    {
        while(true)
        {
            lock(mylock)
            {
                var c = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                System.Console.WriteLine($"Yellow - Thread 1");
                Console.ForegroundColor = c;
                Thread.Sleep(100);
            }
        }
    }

    static void thread21()
    {
        while(true)
        {
            lock(mylock)
            {
                var c = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                System.Console.WriteLine($"Blue Thread 2");
                Console.ForegroundColor = c;
                Thread.Sleep(100);
            }
        }
    }

    static void thread_d1()
    {
        while(true)
        {
            lock(mylock)
            {
                var c = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                System.Console.WriteLine("Thread1: I have lock 1");
                lock (mylock2)
                {
                    System.Console.WriteLine("Thread1: I have lock 2");
                    Thread.Sleep(100);
                }
                Console.ForegroundColor = c;
            }            
        }
    }
    static void thread_d2()
    {
        while(true)
        {
            lock(mylock2)
            {
                var c = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                System.Console.WriteLine("Thread2: I have lock 2");
                lock (mylock)
                {
                    System.Console.WriteLine("Thread2: I have lock 1");
                    Thread.Sleep(100);
                }
                Console.ForegroundColor = c;
            }            
        }        
    }


    static int count = 0;

    static void thread1()
    {
        for(int i=0; i<10_000_000; i++)
            Interlocked.Increment(ref count);
    }

    static void thread2()
    {
        for(int i=0; i<10_000_000; i++)
            Interlocked.Decrement(ref count);

        int x = 5;
        int y = 7;
        Interlocked.Exchange(ref x, y);
    }


    // static List<int> nums = new List<int>();
    static System.Collections.Concurrent.ConcurrentBag<int> nums = new System.Collections.Concurrent.ConcurrentBag<int>();
    static void thread1_cont()
    {
        

        for(int i=0; i<1_000_000; i++)
        {
            nums.Add(1);
        }
    }

    static void thread2_cont()
    {
        for(int i=0; i<1_000_000; i++)
        {
            nums.Add(2);
        }        
    }



    static void Main(string[] args)
    {
        Thread t1 = new Thread(thread1_cont);
        Thread t2 = new Thread(thread2_cont);
        t1.Start();
        t2.Start();
        var sw = Stopwatch.StartNew();
        while(t1.ThreadState != System.Threading.ThreadState.Stopped && 
              t2.ThreadState != System.Threading.ThreadState.Stopped)
        {
            int sum = 0;
            foreach (var num in nums)
                sum += num;
            // if (sum % 1000 == 0)
            System.Console.WriteLine(sum);
        }
        t1.Join();
        t2.Join();
        System.Console.WriteLine(sw.Elapsed);
        System.Console.WriteLine(nums.Count);
        // while(true)
        // {
        //     lock(mylock)
        //     {
        //         System.Console.WriteLine($"White-Main");
        //         Thread.Sleep(100);
        //     }
        // }

    }
}