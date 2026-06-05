namespace s17con;

class Student
{
    public Student(string name, int id)
    {
        if (id < 0 || string.IsNullOrWhiteSpace(name))
            throw new InvalidDataException("id cannot be negative and name cannot be empty");
    }

    public void Register(string course)
    {
        if (string.IsNullOrWhiteSpace(course))
            throw new InvalidDataException("course cann't be empty");
    }
}

class Program
{
    static void Main1234(string[] args)
    {
        StreamWriter writer = null;
        try
        {
            writer = new StreamWriter("test.txt");
            writer.WriteLine("...");  
            // 1          
        }
        catch(InvalidDataException e)
        {
            // ...
            throw;
        }  // FormatException try-catch-finally
        finally
        {
            writer.Close(); // clean up code            
        }
    }


    static void Main3(string[] args)
    {
        checked
        {
            int w = int.MaxValue-2;
            System.Console.WriteLine(w);
            w++;
            System.Console.WriteLine(w);
            w++;
            System.Console.WriteLine(w);
            w++;
            System.Console.WriteLine(w);
            w++;
            System.Console.WriteLine(w);
            w++;
            System.Console.WriteLine(w);
            w++;
            System.Console.WriteLine(w);
        }

    }
}
