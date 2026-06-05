// using System.Reflection.Metadata.Ecma335;

// namespace s16con;

// class Student
// {
//     public Student(string name, string id)
//     {
//         this.name = name;

//         if (id.Length == 9)
//             this.id = id;
//         else
//             ;//...
//     }
//     public string name {get; set;}

//     private string _id;
//     public string id 
//     {
//         get => _id;
//         set
//         {
//             if (value.Length == 9)
//                 _id = value;
//             //!!!!
//         }
//     }

//     public override string ToString()
//     {
//         return $"{name} - {id}";
//     }
// }

// class Program
// {
//     static bool GetStudentName(out string name, out string reason)
//     {
//         System.Console.Write("Enter your name ");
//         reason = string.Empty;
//         name = Console.ReadLine();
//         if (string.IsNullOrWhiteSpace(name))
//         {
//             reason = "name cannot be empty";
//             return false;
//         }
//         return true;
//     }

//     static bool GetStdId(out string stdid, out string reason)
//     {
//         System.Console.Write("Enter your Student Id: ");
//         reason = string.Empty;
//         stdid = Console.ReadLine();
//         if (stdid.Length != 9)
//         {
//             reason = "Student Id must be 9 characters long";
//             return false;
//         }
//         if (! long.TryParse(stdid, out _))
//         {
//             reason = "Student Id must be contain only digits";
//             return false;            
//         }
//         return true;        
//     }

//     static bool GetStudentInfo(out Student s, out string reason)
//     {
//         s = null;
//         if (!GetStudentName(out string name, out reason))
//             return false;

//         if (!GetStdId(out string id, out reason))
//             return false;
        
//         s = new Student(name, id);
//         return true;
//     }

//     static void Main(string[] args)
//     {
//         Student s;
//         while (!GetStudentInfo(out s, out string reason)) 
//             System.Console.WriteLine($"Error. {reason}.");
//         System.Console.WriteLine("your id is: " + s);
        
//     }

//     static void Main2(string[] args)
//     {
//         string id;
//         string reason;
//         while (!GetStdId(out id, out reason)) 
//             System.Console.WriteLine($"Error. {reason}.");
//         System.Console.WriteLine("your id is: " + id);
//     }
// }
