using System.Collections;

namespace s10con;

class MyIntEnum: IEnumerator
{
    private MyInt m;
    public MyIntEnum(MyInt m)
    {
        this.m = m;
        this.Reset();
    }

    private int value;

    public object Current {get; set;}

    public bool MoveNext()
    {
        if (this.value == 0)
            return false;

        this.Current =  this.value % 10;
        this.value = this.value / 10;
        return true;
    }

    public void Reset()
    {
        this.value = m.value;
    }
}

class MyStr
{
    private string str;
    // private char[] chars = str.ToCharArray();

    IEnumerable Characters
    {
        get
        {
            yield return 'c';
            // for(int i=0;i<chars.Length; i++)
            //     yield  return chars[i];
        }
    }

}

class MyInt// : IEnumerable
{
    static bool IsPrime(int n)
    {
        for(int i=2; i<=Math.Sqrt(n); i++)
            if (n % i == 0)
                return false;
        return true;
    } 
    public static IEnumerable PrimeDigits
    {
        get
        {
            for(int i=2;;i++)
                if (IsPrime(i))
                    yield return i;
        }
    }

    public int value;
    public MyInt(int num)
    {
        this.value = num;
    }
    
    public int this[int idx]
    {
        get
        {
            return 0;
        }
    }

    public static implicit operator MyInt(int value) => new MyInt(value);

    public IEnumerable AllDigits
    {
        get
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
            yield return 7;
            yield return 8;
            yield return 9;
            
        }
    }


    public IEnumerable get_digits()
    {
        int v = value;
        while (v > 0)
        {
            int r = v % 10;
            v = v / 10;
            yield return r;
        }
    }


    // public IEnumerator GetEnumerator()
    // {
    //     return new MyIntEnum(this);
    // }
}

class Student 
{}
class Course: IEnumerable
{
    private Student[] students = new Student[20];

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

class Program
{

    static void Main(string[] args)
    {
        foreach(int p in MyInt.PrimeDigits)
            System.Console.WriteLine(p);
    }

    static void Main5123(string[] args)
    {
        // string str = "123456789";
        // int [] nums = new int[]{1,2,2,3,4,3,4,123,2};
        Dictionary<string,int> dic = new Dictionary<string, int>();
        IEnumerator se = dic.GetEnumerator();

        while(se.MoveNext())
        {
            System.Console.Write(se.Current + " ");
        }

        // se.MoveNext();
        // System.Console.WriteLine(se.Current);
        // System.Console.WriteLine(se.Current);
        // se.MoveNext();
        // System.Console.WriteLine(se.Current);
        // se.Reset();
        // se.MoveNext();
        // System.Console.WriteLine(se.Current);
    }
  
    static void Main234123(string[] args)
    {
        string str = "18273645";
        foreach(var ch in str)
            System.Console.WriteLine(ch);

        MyInt m = 12345678;
        // IEnumerator me = m.GetEnumerator();
        // me.MoveNext();

        // for(int i=0; i<m.Length; i++)
        //     System.Console.WriteLine(m[i]);

        foreach(int ch in m.AllDigits)
            System.Console.WriteLine(ch);

        // var e = m.GetEnumerator();

        // for(object c = e.MoveNext() ? e.Current : null; 
        //     e.MoveNext();
        //     )
        // {
        //     System.Console.WriteLine(e.Current);
        // }
    }
}
