using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

class Timer : IDisposable
{
    private string Title;
    private Stopwatch Sw;
    public Timer(string title)
    {
        this.Title = title;
        Sw = new Stopwatch();
        Sw.Start();
    }
    public void Dispose()
    {
        Sw.Stop();
        System.Console.WriteLine($"Elapsed Time: {Sw.Elapsed}");
    }
}


class Program2
{
    public static void Main(string[] args)
    {
        Student[] students = new Student[]
        {
            new Student { Name = "Zeva Green", Id = 101, Gender = 0, GPA = 3.9 },
            new Student { Name = "Xen Carter", Id = 102, Gender = 1, GPA = 3.4 },
            new Student { Name = "Mia Patel", Id = 103, Gender = 0, GPA = 3.7 },
            new Student { Name = "Noah Kim", Id = 104, Gender = 1, GPA = 3.2 },
            new Student { Name = "Lily Morris", Id = 105, Gender = 0, GPA = 3.8 }
        };

        foreach (var student in students)
        {
            System.Console.WriteLine($"{student.Id}: {student.Name}, Gender={student.Gender}, GPA={student.GPA:F2}");
        }

        Array.Sort(students, StudentComparer.StudentGenderComparer);

        System.Console.WriteLine("------------------------------------------------------");

        foreach (var student in students)
        {
            System.Console.WriteLine($"{student.Id}: {student.Name}, Gender={student.Gender}, GPA={student.GPA:F2}");
        }

        // int [] nums = new int[] {2,4,6,1,0,-1};
        // System.Console.WriteLine(string.Join(",", nums));
        // Array.Sort(nums);
        // System.Console.WriteLine(string.Join(",", nums));
    }





    public static void Main3(string[] args)
    {
        double d = Random.Shared.NextDouble();
        if (d == 0)
            d = 1;

        // IDisposable
        using (Timer timer = new Timer("double multiplication"))
        {
            for(int i = 0; i<1_000_000; i++)
            {
                double d2 = Random.Shared.NextDouble();
                if (d2 == 0)
                    d2 = 1;
                d *= d2 * 2;
            }
        }

        System.Console.WriteLine(d);
    }
}