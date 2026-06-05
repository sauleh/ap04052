namespace s8con;

class Program2
{
    static object add(object a, object b)
    {
        int ai = 0, bi = 0;
        double ad = 0, bd = 0;
        if (a is int)
            ai = (int) a;
        else if (a is double)
            ad = (double) a;
        
        if (b is int)
            bi = (int) b;
        else if (b is double)
            bd = (double) b;

        return ai + bi + ad + bd;
    }

    static void Main1(string[] args)
    {
        double x = 5.5;
        object obj = x;
        int w = 4;

        object result = add(x, w);
        double d = (double) result;

        System.Console.WriteLine(d);        
    }
}
