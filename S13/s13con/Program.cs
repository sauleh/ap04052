namespace s13con;

class Person
{
    // public Person(){}
    public Person(string name, int id)
    {
        this.Name = name;
        this.NatId = id;
    }
    public string Name;
    public int NatId;
    
}

class Student: Person
{
    public Student(string name, int id, int stdid, double gpa)
        : base(name, id)
    {
        this.StdId = stdid;
        this.GPA = gpa;
    }
    public int StdId;
    public double GPA {get; private set;}
}



public static class MyExt2
{
    // Ext Method, String duplicate "asdf" => "asdfasdf"
    // Ext Method, int NextPrime(10)
    public static void Print<_T>(this _T[] items, string delim=",")
    {
        System.Console.WriteLine(string.Join(delim, items));
    }
    public static int NextPrime(this int n)
    {
        int ww=1;
        bool found = true;
        for(int i=n+1; ; i++)
        {
            for(int j=2; j<i; j++)
                if (i % j == 0)
                {
                    found = false;
                    break;
                }
            if (found)
                return i;
            found = true;            
        }                    
    }
}

class Program
{
    static void Main(string[] args)
    {
        int w = 5;
        System.Console.WriteLine(w.NextPrime());
        System.Console.WriteLine(w.NextPrime().NextPrime());
        System.Console.WriteLine(w.NextPrime().NextPrime().NextPrime());

        int[] nums = new int[]{1,2,5,1,1,1,10,123,3,3};
        nums.Print();
    }
}
