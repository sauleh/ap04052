using System.Collections;

namespace s12con;

class Instructor : IComparable<Instructor>, IBigger<Instructor>
{
    public int CompareTo(Instructor other)
    {
        throw new NotImplementedException();
    }

    public bool IsBigger(Instructor s)
    {
        throw new NotImplementedException();
    }
}

interface IBiggerStudent
{
    bool IsBigger(Student s);
}

interface IBiggerInstructor
{
    bool IsBigger(Instructor s);
}

interface IBigger<OtherType>
{
    bool IsBigger(OtherType other);
}


class GenStudent<IDType, GradeType>
{
    public IDType Id {get; private set;}
    public string Name {get; set;}

    public GradeType GPA {get; set;}

    private List<GradeType> Grades;
}



class Student: IComparable, IComparable<Student>, IBigger<Student>
{
    public string name;
    public int id;
    public override string ToString()
    {
        return name + "-" + id;
    }

    int Test()
    {
        return 0;
    }
    RetType Test<RetType>()
    {
        throw new NotImplementedException();
    }

    public int CompareTo(object obj)
    {
        Student other = obj as Student;
        if (other == null)
            return -1;
        return this.CompareTo(other);
    }

    public int CompareTo(Student other) => this.id.CompareTo(other.id);

    public bool IsBigger(Student s)
    {
        throw new NotImplementedException();
    }
}

partial class Program
{

    public static void Main3432(string[] args)
    {
        GenStudent<int, string> genStudent = new GenStudent<int, string>();
        GenStudent<string, double> genStudent1 = new GenStudent<string, double>();
        GenStudent<int, int> genStudent2 = new  GenStudent<int, int>();
    }


    void swap(ref object a, ref object b)
    {
        object tmp = a;
        a = b;
        b = tmp;
    }

    static void swap<_Type>(ref _Type a, ref _Type b)
    {
        _Type tmp = a;
        a = b;
        b = tmp;
    }

    static T ming<T>(T a, T b) where T: IComparable<T>
    {
        return a.CompareTo(b) < 0 ? a : b;
    }

    static object  min(object a, object b)
    {
        IComparable ioa = a as IComparable;
        IComparable iob = b as IComparable;
        if (ioa == null || iob == null)
            return null;
        
        return ioa.CompareTo(b) < 0 ? a : b;
    }

    static void Main343(string[] args)
    {
        string a = "asdf", b = "zadff";
        string minab = (string) min(a, b);

        Instructor i1 = new  Instructor(), i2 = new Instructor();

        Student s1 = new Student() {name="ali", id=1};
        Student s2 = new Student() {name="zali", id=2};        
        var sm = ming(i1, i2);

        swap<string>(ref a, ref b);
    }

    static void Main_student_sortedlist(string[] args)
    {
        Student s1 = new Student() {name="ali", id=1};
        Student s2 = new Student() {name="zali", id=2};
        SortedList sl = new SortedList();
        sl.Add(s1, true);
        sl.Add(s2, true);
        foreach(var s  in sl)
            System.Console.WriteLine(s);
    }

    static void Main_int_sortedlist(string[] args)
    {
        SortedList sl = new SortedList();
        sl.Add(1, "one");
        sl.Add(5, "five");
        sl.Add(-1, "neg one");
        foreach(var n in sl)
            System.Console.WriteLine(n);

        var w = sl.GetKey(1);
        System.Console.WriteLine(w);
        var x = sl.GetKey(2);
        System.Console.WriteLine(x);
    }
}
