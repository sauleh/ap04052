using System.Net;

namespace s18con;

class Program2
{

    static void Main22222(string[] args)
    {
        var t = new PeriodicTimer(new TimeSpan(0,0,1));    
    }

    static void Main3777(string[] args)
    {
        FileSystemWatcher fsw = new FileSystemWatcher();
        fsw.Path = @"C:\git\ap04052\s18\s18con";
        fsw.Filter = "*.txt";
        fsw.Created += (object s, FileSystemEventArgs a) => System.Console.WriteLine($"created : {a.Name}");
        fsw.Deleted += (s,a) => System.Console.WriteLine($"deleted : {a.Name}");
        fsw.EnableRaisingEvents = true;
        Task.Delay(10000000).Wait();
    }

    static void Main234(string[] args)
    {
        using (WebClient wc = new WebClient())
        {
            wc.DownloadFileAsync(new Uri("https://www.sauleh.ir/ap98/static_files/LectureNotes.pdf"), "notes.pdf");

            wc.DownloadFileCompleted += (o,e) => System.Console.WriteLine("download completed!");
            wc.DownloadProgressChanged += (o, e) =>
                System.Console.WriteLine($"{e.BytesReceived} - {e.ProgressPercentage}");

            wc.Disposed += (o,e) => System.Console.WriteLine("Disposed!");

            int x = 4;            
            while(x-- > 0)
            {
                System.Console.WriteLine("Waiting for download!");
                Task.Delay(1000).Wait();
            }
        }
        System.Console.WriteLine("Exiting Proram!");
    }
}
