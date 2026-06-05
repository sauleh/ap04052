namespace s7con;

class Student
{
    public string Name {get; set;} 
    public int Id {get; set;}

    public Student(string name, int id)
    {
        if (name == "")
            Logger.Instance.Log("sdfasd");

        this.Name = name;
        this.Id = id;

    }

    public void Register(string course)
    {
        if (course == "")
            // Log
            ;
    }

    public override string ToString() => $"{this.Name} : {this.Id}";
}

class Program 
{

    static void Main(string[] args)
    {
        MyArray mya = new MyArray(4);
        // mya.set(0, 5);
        // mya.set(1, 2);
        // mya.set(2, 10);
        mya[0] = 5;
        mya[1] = 2;
        mya[2] = 10;
        mya[3] = 1;

        MyArray mya2 = new MyArray(4);
        mya2[0] = 5;
        mya2[1] = 2;
        mya2[2] = 10;
        mya2[3] = 1;

        int w = mya2[2];
        if (mya == mya2)
        {
            System.Console.WriteLine("Equal");
        }
        else
        {
            System.Console.WriteLine("Not Equal");
        }
    }

    static void Main1234(string[] args)
    {
        #region Hide
        object obj = new object();
        System.Console.WriteLine($"{obj.ToString()} {obj.GetType()} {obj.GetHashCode()}");
        string s = "adfas";
        System.Console.WriteLine($"{s.ToString()} {s.GetType()} {s.GetHashCode()}");
        int m = 10;
        System.Console.WriteLine($"{m.ToString()} {m.GetType()} {m.GetHashCode()}");
        int[] nums = new int[]{5, 4,3, 2};
        System.Console.WriteLine($"{nums.ToString()} {nums.GetType()} {nums.GetHashCode()}");
        #endregion

        Student ss = new Student("Zhaleh", 999);
        System.Console.WriteLine($"{ss} {ss.GetType()} {ss.GetHashCode()}");

        int [] nums1 = new int[3] {1, 2, 3};
        int [] nums2 = new int[3] {1, 2, 3};
        int [] nums3 = nums1;
        string s1 = "ali";
        string s2 = "ali";
        if (nums1 == nums3)
        {
            System.Console.WriteLine("Is Equal");
        }
        else
        {
            System.Console.WriteLine("Is Not Equal");            
        }
    }
    

    static void Main1(string[] args)
    {        
        Logger.LogPrefix = "myprogram_";

        if (args.Length < 5)
        {
            Logger.Instance.Log("Parameter count wrong");
        }

        Console.WriteLine("Hello, World!");

        Student s = new Student("asd", 2314);
    }
}
