
using System.Threading.Tasks.Dataflow;

class Program
{
    static Queue<string> msgs = new Queue<string>(["msg1", "msg2", "msg3", "msg4"]);
    static void WriteMsgToConsoleYellow(string msg)
    {
        var c = System.Console.ForegroundColor;
        System.Console.ForegroundColor = ConsoleColor.Yellow;
        System.Console.WriteLine(msg);
        System.Console.ForegroundColor = c;
    }

    static void WriteMsgToConsoleGreen(string msg)
    {
        // TODO implement with using
        var c = System.Console.ForegroundColor;
        System.Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine(msg);
        System.Console.ForegroundColor = c;
    }


    const string LogFileName = "log.txt";
    static void WriteMsgToLogFile(string msg)
    {
        File.AppendAllText(LogFileName, msg + "\n");
    }

    static event Action<string> SMSCallback;

    static void MakeSMSCallback()
    {
        Task.Run( () => 
        {
            while(true)
            {
                if (msgs.Count == 0)
                {
                    Task.Delay(500).Wait();
                    continue;
                }
                var msg = msgs.Dequeue();
                if (SMSCallback != null)
                    SMSCallback(msg);
            }
        });
    }

    static void Main(string[] args)
    {
        // Call back 
        MakeSMSCallback();
        GenerateMsgs();
        Task.Delay(1000).Wait();
        SMSCallback = WriteMsgToConsoleGreen;
        Task.Delay(4000).Wait();
        SMSCallback += WriteMsgToConsoleYellow;
        Task.Delay(4000).Wait();
        SMSCallback -= WriteMsgToConsoleGreen;
        Task.Delay(4000).Wait();

    }

    private static void GenerateMsgs()
    {
        Task.Run( () => {
            while (true)
            {
                msgs.Enqueue($"{DateTime.Now}, {Random.Shared.NextInt64()}, Hello");
                Task.Delay(Random.Shared.Next(200, 2000)).Wait();
            }
        });
    }
}
