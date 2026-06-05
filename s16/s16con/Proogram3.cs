// class Program
// {
//     static void f1()
//     {
//         System.Console.Write("n1? ");
//         string num1 = Console.ReadLine();
//         int value1 = int.Parse(num1);
//         System.Console.Write("n2? ");
//         string num2 = Console.ReadLine();
//         int value2 = int.Parse(num2);
//         System.Console.Write("n3? ");
//         string num3 = Console.ReadLine();
//         int value3 = int.Parse(num3);
//         System.Console.WriteLine(value1 * value2 * value3);        
//     }

//     static void f2()
//     {
//         try
//         {
//             f1();
//         }
//         catch(Exception e)
//         {
//             System.Console.WriteLine("f2: " + e.Message);
//             throw;
//         }
//     }

//     static void f3()
//     {
//         f2();

//     }

//     static void Main(string[] args)
//     {
//         while(true)
//         {
//             try
//             {
//                 f3();
//                 break;
//             }
//             catch(OverflowException e)
//             {
//                 System.Console.WriteLine("Overflow happend: " + e.Message);
//                 System.Console.WriteLine("Overflow happend: " + e.StackTrace);
//                 // System.Console.WriteLine("Overflow happend: " + e.HResult);
//                 // System.Console.WriteLine("Overflow happend: " + e.InnerException?.ToString());
//             }
//             catch(FormatException e)
//             {
//                 System.Console.WriteLine("Format exceptioon happend: " + e.Message);                
//             }
//         }
//     }    
// }