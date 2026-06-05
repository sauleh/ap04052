using System.Reflection.Metadata.Ecma335;

namespace s16con;

public class InvalidStudentIdException : Exception
{
    public string stdid {get; set;}
    public InvalidStudentIdException(string stdid, string msg)
        :base(msg)
    {
        this.stdid = stdid;
    }
}

class Student
{
    public Student(string name, string id)
    {
        this.name = name;

        if (id.Length == 9)
            this.id = id;
        else
            throw new  InvalidStudentIdException(id, "id must be 9 digits long");
    }
    public string name {get; set;}

    private string _id;
    public string id 
    {
        get => _id;
        set
        {
            if (value.Length == 9)
                _id = value;
            else
                throw new  InvalidStudentIdException(value, "id must be 9 digits long");

        }
    }

    public override string ToString()
    {
        return $"{name} - {id}";
    }
}

class Program
{
    static string GetStudentName()
    {
        System.Console.Write("Enter your name ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidDataException("name cannot be empty");
        return name;
    }

    static string GetStdId()
    {
        System.Console.Write("Enter your Student Id: ");
        string stdid = Console.ReadLine();
        if (stdid.Length != 9)
            throw new  InvalidStudentIdException(stdid, "id must be 9 digits long");
        if (! long.TryParse(stdid, out _))
            throw new  InvalidStudentIdException(stdid, "id must only contain digits");
        return stdid;
    }

    static Student GetStudentInfo()
    {
        string name = GetStudentName();
        string id = GetStdId();        
        return new Student(name, id);
    }

    static void Main(string[] args)
    {
        Student s;
        while (true)
        {
            try
            {
                s = GetStudentInfo();
                break;
            }
            catch (InvalidStudentIdException e)
            {
                System.Console.WriteLine($"Error for stdid:{e.stdid}. {e.Message}.");                
            }
        }
        System.Console.WriteLine("you are " + s);
        
    }
}