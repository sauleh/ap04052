using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace s21join;

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
    public override string ToString() => $"{country} {year} {rate}";
}


class Program
{

    static void Main2343(string[] args)
    {
        var iran =  File.ReadAllLines("children-per-woman-UN.csv")
            .Skip(1)
            .Select(l => SData.Parse(l))
            .Where(d => d.country == "iran");
        
        iran.Join(iran,
            d => d.year,
            d => d.year-1,
            (d1, d2) => (d1.country, y1:d1.year, y2:d2.year, r1:d1.rate, r2:d2.rate, diff:d1.rate-d2.rate)
         ).OrderBy(d => d.diff)
          .ToList()
          .ForEach(d => Console.WriteLine(d));
    }

    static void Main2(string[] args)
    {
        var a = (1, 2, "test");
        (int x,int y, string comment) b = (1, 2, "test");
        var c = (x:1, y:2, c:3.4, d:"mest");

        int x = 5, y = 4;
        (x,y,_) = b;

        (x, y) = (y, x);

        // System.Console.WriteLine(b.Item1);
        // System.Console.WriteLine(b.x);
        // System.Console.WriteLine(b.y);
        // System.Console.WriteLine(b);

        if (a == b)
            System.Console.WriteLine("same");
        else
            System.Console.WriteLine("not the same");



        // opt1 class
        // opt2 anonymous class
        // var a = new {x=1 , y=2};
        // var b = new {x=1 , y=2};

        // if (a == b)
        //     System.Console.WriteLine("same");
        // else
        //     System.Console.WriteLine("not the same");

    }
}
