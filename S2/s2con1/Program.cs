namespace s2con1;
// Java Runtime Environment , JDK
// Dotnet SDK, Dotnet RE
// Just In Time Compiling 

class Student
{
    int id;
    double gpa;
}

class Program
{
    static void swap(int [] nums, int i, int j)
    {
        int tmp = nums[i];
        nums[i] = nums[j];
        nums[j] = tmp;
    }

    static void power2(int x, out int result)
    {
        result = x*x;
    }

    static void swap(ref int a, ref int b)
    {
        int t = a;
        a = b;
        b = t;
    }

    static void print_array(int[] nums)
    {
        foreach(int n in nums)
        {
            Console.Write(n + " ");
        }
        System.Console.WriteLine();
    }
    static void Main(string[] args)
    {
        string s = Console.ReadLine();
        int n;
        while (! int.TryParse(s, out n))
        {
            System.Console.WriteLine(n*2);
            s = Console.ReadLine();
        }
    }

    static void Main5(string[] args)
    {
        // List<int[]> mynumarrays = new List<int[]>();
        int[] nums;
        for(int i=0; i<1000; i++)
        {
            nums = new int[1000];
            for(int j=0; j<1000; j++) nums[j] = i + 1;
            // mynumarrays.Add(nums);
            System.Console.Write(".");
        }

        int[] mynums = new int[6]{1, 2, 3, 4, 5, 6};
        print_array(mynums);
        swap(mynums, 0, 5);
        print_array(mynums);


        int a=5, b=4;
        int[] As = new int[]{4};
        int[] Bs = new int[]{5};
        System.Console.WriteLine(a + " " + b);
        swap(ref a, ref b);
        System.Console.WriteLine(a + " " + b);
    }
    static void Main1(string[] args)
    {
        Student s = null;//new Student();
        int x = 5; // value type
        double d = 5.5f;
        string s2 = "gahsdf";
        int[] nums = new int[10];

        Console.WriteLine("Hello, World!");
    }
}
