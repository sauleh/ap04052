namespace s9con;

class Program
{
    static void swap(object[] stds, int i, int j)
    {
        object s1 = stds[i];
        stds[i] = stds[j];
        stds[j] = s1;


    }
    // public static void Sort(IComparable[] stds)
    // {
    //     for(int i=0 ;i<stds.Length; i++)
    //         for (int j = i+1; j<stds.Length; j++)
    //             if (stds[i].CompareTo(stds[j]) > 0)
    //                 swap(stds, i, j);
    // }

    public static void SortByName(IUniversityPerson[] stds)
    {
        for(int i=0 ;i<stds.Length; i++)
            for (int j = i+1; j<stds.Length; j++)
                if (stds[i].Name.CompareTo(stds[j].Name) > 0)
                    swap(stds, i, j);
    }    

    public static void SortByRating(IRatableUniversityPerson[] pps)
    {
        for(int i=0 ;i<pps.Length; i++)
            for (int j = i+1; j<pps.Length; j++)
                if (pps[i].GetRating().CompareTo(pps[j].GetRating()) > 0)
                    swap(pps, i, j);
    } 

    public static void SortByComparer(object[] pps, IComparer cmp)
    {
        for(int i=0 ;i<pps.Length; i++)
            for (int j = i+1; j<pps.Length; j++)
                if (cmp.Compare(pps[i], pps[j]) > 0)
                    swap(pps, i, j);
    } 


    static void Main(string[] args)
    {
        Student[] students = new Student[]
        {
            new Student { Name = "Zeva Green", Id = 101, Gender = 0, GPA = 3.9 },
            new Student { Name = "Xen Carter", Id = 102, Gender = 1, GPA = 3.4 },
            new Student { Name = "Mia Patel", Id = 103, Gender = 0, GPA = 3.7 },
            new Student { Name = "Noah Kim", Id = 104, Gender = 1, GPA = 3.2 },
            new Student { Name = "Lily Morris", Id = 105, Gender = 0, GPA = 3.8 }
        };
        
        SortByName(students);
        System.Console.WriteLine(string.Join("\n", (object[])students));
        SortByName(Instructor.TestData);
        System.Console.WriteLine(string.Join("\n", (object[])Instructor.TestData));


        return;

        Student s1 = students[0];
        Student s2 = students[1];
        Student s3 = students[2];


        // double d = 54.2;
        // int x = (int) d;
        // d = x;
        // Double d;

        Student sws = (Student)"Zhila,1234123,3.95,F";
        System.Console.WriteLine(sws);

        return;

        System.Console.WriteLine(s1);
        var ss = s1 + 0.1 + 0.05;
        System.Console.WriteLine(s1);

        ss = ! s1;
        System.Console.WriteLine(s1);

        return;
        var stds = s1 + s2;
        foreach(var s in stds)
            System.Console.WriteLine(s);
        System.Console.WriteLine("------------------");
        stds = s1 + s2 + s3;
        foreach(var s in stds)
            System.Console.WriteLine(s);


        return;
        #region  Hide
        if ( s1.CompareTo(s2) > 0 )
            System.Console.WriteLine(s1 + "is larger than" + s2);

        if (s1.Equals(s2))
            System.Console.WriteLine("They are equal");

        if (s1 > s2)
            System.Console.WriteLine(s1 + "is larger than" + s2);
        #endregion
    }
}
