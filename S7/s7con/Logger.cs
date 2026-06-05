public class Logger
{
    private Logger(string filename)
    {
        this.LogStream = new StreamWriter(filename);
    }
    
    public void Log(string message)
    {
        LogStream.WriteLine(message);
        LogStream.Flush();
    }

    public static Logger Instance => _Instance ?? (_Instance = new Logger(LogPrefix));
    // {
    //     get
    //     {
    //         if (null == _Instance)
    //             _Instance = new Logger();
            
    //         return _Instance;
    //     }
    // }

    private static Logger _Instance = null;

    public static string LogPrefix = "log.txt";

    private StreamWriter LogStream;
}