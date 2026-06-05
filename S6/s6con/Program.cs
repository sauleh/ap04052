namespace s6con;


enum Colors
{
    Green = 7,
    Yellow = 15,
    Pink = 12,
    Orange = 14
};

struct StudentV
{
    public string name;
    public int Id;
    public double GPA;
    public void print()
    {
        System.Console.WriteLine($"name: {this.name}, id:{this.Id}");
    }    
}

class Student
{
    string name;
    int id;

    static int _NextStudentId = 40452100;
    public static int NextStudentId
    {
        get
        {
            return _NextStudentId++;
        }
        set
        {
            _NextStudentId = value;
        }
    }

    public Student(string name)
        : this(name, NextStudentId)
    {
    }

    public Student(string name, int id)
    {
        this.name = name;
        this.id = id;
    }

    public void print()
    {
        System.Console.WriteLine($"name: {this.name}, id:{this.id}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Colors c = Colors.Green;
        int w = (int) c;
        System.Console.WriteLine($"{w}, {c}");
        if (7 == (int)c)
        {
            System.Console.WriteLine("Green");
        }
    }

    static void Main343(string[] args)
    {
        StudentV sv = new StudentV();
        sv.Id = 12345;
        sv.name = "hosna";
        sv.GPA = 19.5;
        sv.print();

        StudentV sv2 = sv;
        sv2.Id = 8888;

        sv2.print();
        sv.print();

    }

    static void Main1(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Student s1 = new Student("ali", 1234);
        s1.print();

        for(int i=0;i<10; i++)
        {
            Student s2 = new Student("mali"+i);
            s2.print();
        }

        Student.NextStudentId = 40452200;

        for(int i=0;i<10; i++)
        {
            Student s2 = null;// = new Student("mali"+i);
            s2.print();
        }
        int w = 5;
        int xx = w;

        Student s3 = new Student("ali");
        Student s4 = s3;

    }
}
