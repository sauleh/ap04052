
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace s10con;

class node
{
    public int value;
    public node left;
    public node right;
}

class Pair
{
    public int x;
    public int y;
    static int EqualCallCount = 0;

    public override bool Equals(object obj)
    {
        System.Console.Write($"\r{EqualCallCount++}");
        if (obj is not Pair)
            return false;
        
        Pair other = obj as Pair;
        return this.x == other.x  && this.y == other.y;
    }

    public override int GetHashCode()
    {
        return 1;//x.GetHashCode() + 1023 * y.GetHashCode();
    }
}

class Shape
{
    public string Name;
}

struct TestS
{
    bool s;//, d, w, k;
}

class Program
{
    unsafe static void Main(string[] args)
    {
        int w = sizeof(TestS);
        //int w = Marshal.SizeOf<TestS>();
        System.Console.WriteLine(w);
    }

    static void Main_HT(string[] args)
    {
        Hashtable ht = new Hashtable(1_000_000);
        for(int i=0; i<1000_000; i++)
            ht.Add(new Pair{ x=Random.Shared.Next(), y=Random.Shared.Next()}, new Shape());

        Stopwatch sw = Stopwatch.StartNew();
        for(int i=0; i<1; i++)
            if (ht.ContainsKey(new Pair{ x=Random.Shared.Next(), y=Random.Shared.Next()}))
                System.Console.Write('.');  
        System.Console.WriteLine(sw.Elapsed);      
    }

    static void Main_HT2(string[] args)
    {
        Hashtable ht = new Hashtable();
        Pair p1 = new Pair{x = 5, y = 4};
        Pair p2 = new Pair{x = 1, y = 2};
        Shape s1 = new Shape{ Name="Square"};
        Shape s2 = new Shape{ Name="Circle"};
        ht.Add(p1, s1);
        ht.Add(p2, s2);

        if (ht.ContainsKey(p1))
        {
            Shape s = (Shape) ht[p1];
            System.Console.WriteLine(s.Name);
        }

        Pair p3 = new Pair{ x = 1, y = 2};
        if (ht.ContainsKey(p3))
        {
            Shape s = (Shape) ht[p3];
            System.Console.WriteLine(s.Name);
        }
        else
        {
            System.Console.WriteLine("No shape found for p3");
        }

    }


    static void Main_HT1(string[] args)
    {
        Hashtable ht = new Hashtable();
        ht.Add("zari", 912234122);
        ht.Add("mari", 910234122);
        ht.Add("sari", 914234122);

        if (ht.ContainsKey("zari"))
            System.Console.WriteLine(ht["zari"]);

        if (! ht.ContainsKey("dari"))
            System.Console.WriteLine("do not have dari's number");
    }


    public static void DFS(node root)
    {
        if (root == null)
            return;
        
        System.Console.WriteLine(root.value);
        DFS(root.left);
        DFS(root.right);
    }

    public static void BFS(node root)
    {
        Queue q = new Queue();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            node n = (node) q.Dequeue();
            System.Console.WriteLine(n.value);
            q.Enqueue(n.left);
            q.Enqueue(n.right);
        }
    }

    static void Main_Queue(string[] args)
    {
        Queue q = new Queue();
        q.Enqueue("ali");
        string b = (string) q.Dequeue();

    }


    static void Main_Stack(string[] args)
    {
        Stack s = new Stack(); // FILO 
        s.Push(1);              //  (1 + (2 + 3 - (4 + 2)) * (1 - 4))
        var x = s.Pop();        //
    }


    static void Main_BitArray(string[] args)
    {
        bool [] b = new bool[64]; // 4 * 8 * 64 
        // UInt64 a = 0b0101010111010101010101010101010100; // 8 * 4
        BitArray ba = new BitArray(1000*1000); // 1,000,000 / 8  = 125,000
        ba[1] = true;
        bool b1 = ba[10];


    }

    static void Main_ArrayList(string[] args)
    {
        ArrayList al = new ArrayList();
        al.Add(1);
        al.Add("asdf");

        var x = al[1];

        foreach(var v in al)
            System.Console.WriteLine(v);

        al.RemoveAt(0);

        foreach(var v in al)
            System.Console.WriteLine(v);

        for(int i=0; i<al.Count; i++)
            System.Console.WriteLine(al[i]);

    }
    static void Main_Array(string[] args)
    {
        object[] nums = new object[10];
        nums[0] = 5;
        nums[1] = "adf";
        int x = (int) nums[0];
        string s = (string) nums[1];
        foreach(var v in nums)
            System.Console.WriteLine(v);
    }
}
