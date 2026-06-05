using System.Net;

namespace s18con;

class Program
{
    // static bool IsOdd(int i)
    // {
    //     return i % 2 == 1;
    // }

    // static double Sqrt(int n)
    // {
    //     return Math.Sqrt(n);
    // }

    static void Main(string[] args)
    {
        Enumerable.Range(1, 100)
                  .Select( _ => Random.Shared.Next(1, 100))
                  .Where(x => x%2 == 0)
                  .GroupBy(age => age / 10)
                  .Where(g => g.Key % 2 == 1)
                  .OrderBy(g => g.Key)
                  .Select( g => $"Decade {g.Key}: {string.Join(",", g)}")
                  .ToList().ForEach(Console.WriteLine);



        // Enumerable.Range(1,10)
        //     .Where(n => n % 2 == 1)
        //     .Select(n => Math.Sqrt(n))
        //     .ToList().ForEach(Console.WriteLine);

        // foreach(int i in Enumerable.Range(1, 10))
        //     if (i % 2 == 1)
        //         System.Console.WriteLine(i);
    }
}
