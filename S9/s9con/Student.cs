

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

interface IPerson
{
    string Name {get; set;}
    int Gender {get; set;}

    bool HasNatId {get; set;}
    int NatId {get; set;}
}

interface IUniversityPerson: IPerson
{
    int Id {get; set;} // GetId, SetId
}

interface IRatableUniversityPerson: IUniversityPerson
{
    double GetRating();
}

class Instructor : IComparable, IRatableUniversityPerson
{
    public double GetRating() => this.Rating;

    public string Name {get;set;}
    public int Id {get; set;}
    public int Gender {get; set;}

    public double Rating {get; set;}

    public static Instructor [] TestData = [
            new Instructor { Name = "Zeva Green", Id = 101, Gender = 0, Rating = 3.9 },
            new Instructor { Name = "Xen Carter", Id = 102, Gender = 1, Rating = 3.4 },
            new Instructor { Name = "Mia Patel", Id = 103, Gender = 0,  Rating = 3.7 },
            new Instructor { Name = "Noah Kim", Id = 104, Gender = 1,   Rating = 3.2 },
            new Instructor { Name = "Lily Morris", Id = 105, Gender = 0,Rating = 3.8 }
    ];

    public override string ToString() => $"Instructor {Name}, {Id}, {Gender}, {Rating}";


    public int CompareTo(object obj)
    {
        Instructor other = obj as Instructor;
        return this.Rating.CompareTo(other.Rating);
    }
}


class Student : IComparable, IUniversityPerson, IRatableUniversityPerson
{
    public double GetRating() => this.GPA;

   public string Name {get; set;}
   public int Id {get; set;}
   public int Gender {get; set;}
   public double GPA {get; set;}

    public static bool operator<(Student s1, Student s2)  => s1.CompareTo(s2) < 0;
    public static bool operator>(Student s1, Student s2) => s2 < s1;
    public static Student[] operator+(Student s1, Student s2)
    {
        return [s1, s2];
    }

    public static Student operator+(Student s1, double extra)
    {
        s1.GPA += extra;
        return s1;
    }

    public static Student operator!(Student s)
    {
        s.GPA /= 2;
        return s;
    }

    public static explicit operator Student( string str)
    {
        var toks = str.Split(',');
        string name = toks[0];
        int id = int.Parse(toks[1]);
        double gpa = double.Parse(toks[2]);
        int gender = toks[3] == "F" ? 0 : 1;
        return new Student{Name = name, Id = id, GPA=gpa, Gender = gender};
    }

    public static Student[] operator+(Student[] students, Student s)
    {
        Student[] new_students = new Student[students.Length + 1];
        for(int i=0; i<students.Length; i++)
            new_students[i] = students[i];
        new_students[students.Length] = s;
        return new_students;
    }

    

    public override string ToString() => $"{Name}, {Id}, {Gender}, {GPA}";
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
