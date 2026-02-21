namespace s3con;

public class Program
{
    public static int add(int a, int b)
    {
        return a+b;
    }


    public static void add(int a, int b, out int sum)
    {
        sum = 0;
        if (a != 0 && b != 0)
            sum = a+b;
    }

    static int add(params int[] nums)
    {
        int sum=0;
        foreach(int n in nums)
            sum += n;
        return sum;
    }

    static void swap(ref int a, ref int b)
    {
        int t = a;
        a = b;
        b = t;
    }

    static void Main22(string[] args)
    {
        int x = 5, y = 6;
        int sum;
        add(x, y, out sum);
        int [] mynums =new int[4]  {1, 2, 3, 4};
        int sum2 = add(mynums);
        int sum3 = add(1, 2, 5, x, y, 7, 12, 13, 4);

        // swap(ref x, ref y);
        Console.WriteLine($"Hello, World! {sum}");
    }
}
