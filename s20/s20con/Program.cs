using System.Diagnostics;
using System.Runtime.InteropServices;

namespace s20con;

public static class MyExtMethods
{
    public static bool IsPrime(long n) => true;
    public static IEnumerable<long> GetPrimes()
    {
        long n = 2;
        while (true)
        {
            if (IsPrime(n))
                yield return n;
            n++;
        }        
    }

    public static void ToConsole<T>(this T e) => System.Console.WriteLine(e);

    public static void ForEach<T>(this IEnumerable<T> nums, Action<T> fn)
    {
        foreach(var n in nums)
            fn(n);
    }

    public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> items, Func<T, bool> fn)
    {
        foreach(var e in items)
            if (fn(e))
                yield return e;
    }

    public static IEnumerable<TOut> MySelect<TIn, TOut>(this IEnumerable<TIn> items, Func<TIn, TOut> fn)
    {
        foreach(var v in items)
            yield return fn(v);
    }

}




class PData
{
    public string country;
    public int year;
    public double pop;
    public static PData Parse(string line)
    {
        var toks = line.Split(',');
        return new PData()
                {
                    country = toks[0].ToLower(),
                    year = int.Parse(toks[2])  ,
                    pop = double.Parse(toks[3])
                };
                
    }
    public override string ToString() => $"{country} {year} {pop}";
}


class SData
{
    public string country;
    public int year;
    public double rate;
    public static SData Parse(string line)
    {
        var toks = line.Split(',');
        return new SData()
                {
                    country = toks[0].ToLower(),
                    year = int.Parse(toks[2])  ,
                    rate = double.Parse(toks[3])
                };
    }
}

class Program
{

    static void Main(string[] args)
    {
        var sud = File.ReadAllLines("suicide-rates-by-country.csv")
            .Skip(1)
            .Select(l => SData.Parse(l));

        var pop = File.ReadAllLines("population.csv")
                .Skip(1)
                .Where(l => l.Split(",").Length == 4)
                .Select(l => PData.Parse(l));

        sud.Join(pop, 
            d1 => (d1.country, d1.year),
            d2 => (d2.country, d2.year),
            (d1, d2) => (d1.country, d1.year, d1.rate, d2.pop, totalsu:d1.rate * (d2.pop/100_000))
        ).OrderByDescending( d => d.totalsu)
         .Take(50)
         .ForEach(l => Console.WriteLine(l));
    }


    static void MainZip(string[] args)
    {
        Enumerable.Range(1,10).Zip(Enumerable.Range(1,10).Select(x => Math.Sqrt(x)))
                  .ToList()
                  .ForEach(x => Console.WriteLine(x));
    }

    static void Main34344444(string[] args)
    {
        // var primes = MyExtMethods.GetPrimes();
        // primes.Take(10).ForEach(Console.WriteLine);

        // var items2 = Enumerable.Range(1, int.MaxValue);

        // var s = string.Join("*", ["", "", "", ""]);
        // var s = string.Join(string.Empty, Enumerable.Range(1,5).Select(_=>"*"));
        // System.Console.WriteLine(s);


        if (Enumerable.Range(1, 20).All(x => x > 0))
            System.Console.WriteLine("All Positive");

        // Enumerable.Range(1, 20)
        //           .Concat(Enumerable.Range(30,10))
        //           .ForEach(Console.WriteLine);
                //   .Aggregate( (a, b) => a+b)
                //   .ToConsole();



                //   .MyWhere(n => n % 2 == 1)
                //   .MySelect(n => string.Join("*", Enumerable.Range(1,n).Select(_=>string.Empty)))
                //   .ForEach(Console.WriteLine);
                  
        // var listitems = items.ToList();
    }
}
