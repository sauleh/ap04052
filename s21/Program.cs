using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace s21;

class Program
{

    static void thread11()
    {
        while(true)
        {
            var c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            System.Console.WriteLine($"Thread1 {Thread.CurrentThread.ManagedThreadId}");
            Console.ForegroundColor = c;
            Thread.Sleep(200);
        }
    }

    static void thread21()
    {
        while(true)
        {
            var c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            System.Console.WriteLine($"Cyan");
            Console.ForegroundColor = c;
            Thread.Sleep(200);
        }
    }

    static int count = 0;

    static void thread1()
    {
        for(int i=0; i<1000_000; i++)
            count ++;
    }

    static void thread2()
    {
        for(int i=0; i<1000_000; i++)
            count--;
    }



    static void Main(string[] args)
    {
        Thread t1 = new Thread(thread1);
        Thread t2 = new Thread(thread2);
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
        System.Console.WriteLine(count);
        // while(true)
        // {
        //     System.Console.WriteLine($"Yellow");
        //     Thread.Sleep(200);
        // }
    }
}
