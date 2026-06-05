
using System.Runtime.InteropServices;

public class StudentNameComparer : System.Collections.IComparer
{
    public int Compare(object x, object y)
    {
        Student xs = x as Student;
        Student ys = y as Student;
        return xs.Name.CompareTo(ys.Name);
    }
}

public class StudentIdComparer : System.Collections.IComparer
{
    public int Compare(object x, object y)
    {
        Student xs = x as Student;
        Student ys = y as Student;
        return xs.Id.CompareTo(ys.Id);
    }
}

public class StudentGenderComparer : System.Collections.IComparer
{
    public int Compare(object x, object y)
    {
        Student xs = x as Student;
        Student ys = y as Student;
        return xs.Gender.CompareTo(ys.Gender);
    }
}

public class StudentGPAComparer : System.Collections.IComparer
{
    public int Compare(object x, object y)
    {
        Student xs = x as Student;
        Student ys = y as Student;
        return xs.GPA.CompareTo(ys.GPA);
    }
}

public static class StudentComparer
{
    public static StudentIdComparer StudentIdComparer = new();
    public static StudentNameComparer StudentNameComparer = new();
    public static StudentGenderComparer StudentGenderComparer = new();
    public static StudentGPAComparer StudentGPAComparer = new();
}

[StructLayout(LayoutKind.Sequential, Pack=1)]
struct ssss
{
    int a;
}

class Student : IComparable
{
   public string Name {get; set;}
   public int Id {get; set;}
   public int Gender {get; set;}
   public double GPA {get; set;}

    public int CompareTo(object obj)
    {
        if (obj is not Student)
            return 0;
        
        Student other = obj as Student;
        return this.GPA.CompareTo(other.GPA);

        // if (this.GPA < other.GPA)
        //     return -1;
        // else if (this.GPA == other.GPA)
        //     return 0;
        // else 
        //     return 1;
    }
}
