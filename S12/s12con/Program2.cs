using System.Diagnostics.CodeAnalysis;

namespace s12con;

class PairComparer<xType, yType> : IComparer<Pair<xType, yType>>
        where xType: IEquatable<xType>, IComparable<xType>, IComparable
        where yType: IEquatable<yType>, IComparable<yType>, IComparable
{
    public int Compare(Pair<xType, yType> x, Pair<xType, yType> y)
    {
        return x.CompareTo(y);
    }
}

class PairEquatable<xType, yType> : IEqualityComparer<Pair<xType, yType>>
        where xType : IEquatable<xType>, IComparable<xType>, IComparable
        where yType : IEquatable<yType>, IComparable<yType>, IComparable

{
    public bool Equals(Pair<xType, yType> x, Pair<xType, yType> y)
    {
        throw new NotImplementedException();
    }

    public int GetHashCode([DisallowNull] Pair<xType, yType> obj)
    {
        throw new NotImplementedException();
    }
}

// GetHashCode, Equals
//  x, y => z // Dictionary<Pair<int, int>, int>

public class Pair<xType, yType> : 
    IComparable<Pair<xType, yType>>, 
    IEquatable<Pair<xType, yType>>,
    IComparable
        where xType: IEquatable<xType>, IComparable<xType>, IComparable
        where yType: IEquatable<yType>, IComparable<yType>, IComparable
{
    public xType x;
    public yType y;

    public int CompareTo(Pair<xType, yType> other)
    {
        int cmp = this.x.CompareTo(other.x);
        return cmp != 0 ? cmp : this.y.CompareTo(other.y);
    }

    public int CompareTo(object obj)
    {
        var other = obj as Pair<xType, yType>;
        if (other == null)
            return -1;
        return this.CompareTo(other);
    }

    public override bool Equals(object obj)
    {
        var other = obj as Pair<xType, yType>;
        if (other == null)
            return false;
        
        return this.x.Equals(other.x) && this.y.Equals(other.y);        
    }

    public override int GetHashCode()
    {
        return this.x.GetHashCode() ^ this.y.GetHashCode();
    }

    public bool Equals(Pair<xType, yType> other)
    {
        return this.x.Equals(other.x) && this.y.Equals(other.y);
    }

    public override string ToString() => $"({x},{y})";
}

partial class Program
{

    public static void Main(string[] args)
    {
        var p1 = new Pair<int,int>() {x=1, y=2}; 
        var p2 = new Pair<int,int>() {x=1, y=4}; 
        var p3 = new Pair<int,int>() {x=2, y=1}; 
        var p4 = new Pair<int,int>() {x=-1, y=5};       
        List<Pair<int,int>> l = new List<Pair<int, int>>();
        l.Add(p1);
        l.Add(p2);
        l.Add(p3);
        l.Add(p4);
        l.Sort(new PairComparer<int,int>());
        foreach(var v in l)
            System.Console.WriteLine(v);
    }


    public static void Main_dic(string[] args)
    {
        Dictionary<Pair<int, int>, int> dic = new();
        var p1 = new Pair<int,int>() {x=1, y=2}; // (1,2,3)
        var p2 = new Pair<int,int>() {x=2, y=1}; // (2,1,4)
        var p3 = new Pair<int,int>() {x=1, y=2}; // (1,2,3)
        var p4 = new Pair<int,int>() {x=5, y=2}; // (5,2,3)

        dic[p1] = 3;
        dic[p2] = 4;
        System.Console.WriteLine(dic[p1]);
        System.Console.WriteLine(dic[p2]);
        System.Console.WriteLine(dic[p3]);
        if (dic.ContainsKey(p4))
            System.Console.WriteLine(p4 + "found");
        else
            System.Console.WriteLine(p4 + "not found");


    }


    public static void Main5(string[] args)
    {
        List<Student> stds = new List<Student>();
        Student s = new Student();
        // stds.Contains(s);

        Dictionary<string, int> pb = new Dictionary<string, int>();
        pb.Add("ali", 912234);

        foreach(KeyValuePair<string,int> v in pb)
        {
            System.Console.WriteLine(v);
        }

        

        // x = []
    }

}
