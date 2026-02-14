namespace s1con2;

struct Progam1
{
    int x;
    double d;
}

class Program
{
    static int sum(int a, int b)
    {
        return a + b;
    }

    static int sum_list(int [] nums)
    {
        int sum = 0;
        for(int i=0; i<nums.Length; i++)
            sum += nums[i];
        return sum;
    }

    static void Main(string[] args)
    {
        double d = 5.4;
        float f = 1.1f;
        char c = 'A';
        string w = "jhkhj";
        string x = w.Substring(1, 2);
        for (int k=0; k<x.Length; k++)
            System.Console.WriteLine(x[k]);

        d = Math.Abs(d);
        int x = 5;
        Console.WriteLine($"Hello, World! {x}");
        string name = Console.ReadLine();
        Console.WriteLine("you are " + name);
        if (name == "")
            name = "ali";

        for(int j =0; j<5; j++)
        {
            Console.Write($"I love {name}");
        }

        int i = 0;
        while (i < 10)
        {
            System.Console.WriteLine($"test {i}");
        }

    }
}
