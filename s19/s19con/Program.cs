namespace s19con;

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
                    country = toks[0],
                    year = int.Parse(toks[2])  ,
                    rate = double.Parse(toks[3])
                };
    }
}

class Program
{

    // کدام کشور بیشترین بهبود در نرخ مورد نظر دارد
    // کدام کشور بیشترین تغییر در دو گزارش متوالی سالانه داشته
    // بلندترین قله 
    // عمیق‌ترین دره
    //

    static void Main(string[] args)
    {
        File.ReadAllLines("suicide-rates-by-country.csv")
            .Skip(1)
            .Select(l => SData.Parse(l))
            .GroupBy(g => g.country)
            .Select(g => {
                var d1 = g.MaxBy(d => d.year);
                var d2 = g.MinBy(d => d.year);
                return new {country = g.Key, imprate= d2.rate - d1.rate, y1=d1.year, y2=d2.year};
            })
            .OrderByDescending(d => d.imprate)
            .Take(30)
            .ToList()
            .ForEach(s => System.Console.WriteLine(s));
    }



    static void Main34343(string[] args)
    {
        File.ReadAllLines("suicide-rates-by-country.csv")
            .Skip(1)
            .Select(l =>
            {
                var toks = l.Split(',');
                return new
                {
                    country = toks[0].ToLower(),
                    year = int.Parse(toks[2])  ,
                    rate = double.Parse(toks[3])
                };
            })
            .GroupBy(g => g.year)
            .Select(g => new {
                year=g.Key, 
                rank=g.OrderByDescending(d => d.rate)
                      .Select((d,i) => new {d.country, rank=i+1})
                      .Where(dr => dr.country == "iran")
                      .Select(dr => dr.rank)
                      .FirstOrDefault()
            })
            .Where(d => d.rank != 0)
            .ToList()
            .ForEach(s => System.Console.WriteLine(s));
    }


    static void Main3331234(string[] args)
    {
        // var x = new {name="ali", id=1400};
        // System.Console.WriteLine($"{x.name} {x.id}");

        File.ReadAllLines("suicide-rates-by-country.csv")
            .Skip(1)
            .Select(l =>
            {
                var toks = l.Split(',');
                return new
                {
                    country = toks[0].ToLower(),
                    year = int.Parse(toks[2])  ,
                    rate = double.Parse(toks[3])
                };
            })
            .GroupBy(g => g.country)
            .Select(g => new {country=g.Key, avgrate=g.Average(d => d.rate)})
            .OrderByDescending(d => d.avgrate)
            .Select((d,i) => new {d.country, d.avgrate, rank=i})
            .Where( d => d.country == "iran" )
            .ToList()
            .ForEach(s => System.Console.WriteLine(s));
    }

    static void Main1234(string[] args)
    {
        File.ReadAllLines("suicide-rates-by-country.csv")
            .Skip(1)
            .OrderByDescending(l =>
            {
                var toks = l.Split(',');
                return double.Parse(toks[3]);
            })
            .ToList()
            .ForEach(s => System.Console.WriteLine(s));
    }


    static void Main222(string[] args)
    {
        // var x = new {name="ali", id=1400};
        // System.Console.WriteLine($"{x.name} {x.id}");

        File.ReadAllLines("suicide-rates-by-country.csv")
            .Skip(1)
            .Select(l =>
            {
                var toks = l.Split(',');
                return new
                {
                    country = toks[0],
                    year = int.Parse(toks[2])  ,
                    rate = double.Parse(toks[3])
                };
            })
            .Where(d => d.year == 2005)
            .OrderByDescending(d => d.rate)
            .ToList()
            .ForEach(s => System.Console.WriteLine(s));
    }
}
