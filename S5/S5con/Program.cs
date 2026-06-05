

namespace S5con;

class Program
{
    static void Main(string[] args)
    {
        Passenger p = new Passenger(
            name:"pari", 
            natId:6566656, 
            paymentcard:"6576545678865",
            phoneNumber: 657654);
        RideManager m = new RideManager();
        m.RegisterAsPassenger(p);

        Ride r = p.RequestRide(
            start: new Location(latitude: 545678865, longditude: 545678865), 
            destination: new Location(latitude:545678865, longditude:545678865));
        System.Console.WriteLine(r.Driver.Info());
        //...
        r.RateDriver(6);        
    }

    static void Mainii()
    {
        RideManager m = new RideManager();
        Passenger p = m.LookupPassenger(phonenumber: 69876980);
        foreach(Ride r in p.Rides)
        {
            System.Console.WriteLine(r.Info());
        }
    }

    static void Main6(string[] args)
    {
        Driver d = new Driver(name:"ali", 
            natId:6566656, 
            paymentcard:"6576545678865",
            phoneNumber: 657654);
        Ride r = d.AcceptRide();
        System.Console.WriteLine(r.Passenger.Info());        
        System.Console.WriteLine(r.FromAddress);        
        System.Console.WriteLine(r.ToAddress);        
        System.Console.WriteLine(r.Cost);
        d.ArrivedAtStartingPoint();
        d.ArrivedAtDesitnation();
    }

    static void Main123(string[] args)
    {
        int n = 5;
        // int [] nums = new int[5];
        List<int> nums = new List<int>();
        nums.Add(n);
        // List<List<Student>>         

    }
}

internal class RideManager
{
    internal Passenger LookupPassenger(int phonenumber)
    {
        throw new NotImplementedException();
    }

    internal void RegisterAsPassenger(Passenger p)
    {
        throw new NotImplementedException();
    }
}

internal class Driver
{
    private string name;
    private int natId;
    private string paymentcard;
    private int phoneNumber;

    public Driver(string name, int natId, string paymentcard, int phoneNumber)
    {
        this.name = name;
        this.natId = natId;
        this.paymentcard = paymentcard;
        this.phoneNumber = phoneNumber;
    }

    public Ride CurrentRide { get; private set; }

    internal Ride AcceptRide()
    {
        throw new NotImplementedException();
    }

    internal void ArrivedAtDesitnation()
    {
        this.CurrentRide.IsActive = false;
    }

    internal void ArrivedAtStartingPoint()
    {
        throw new NotImplementedException();
    }

    internal bool Info()
    {
        throw new NotImplementedException();
    }
}

internal class Location
{
    private int latitude;
    private int longditude;

    public Location(int latitude, int longditude)
    {
        this.latitude = latitude;
        this.longditude = longditude;
    }
}

internal class Passenger
{
    private string name;
    private int natId;
    private string paymentcard;
    private int phoneNumber;

    private List<Ride> RideHistory;

    public Ride CurrentRide
    {
        get
        {
            foreach(Ride r in RideHistory)
                if (r.IsActive)
                    return r;
            return null;
        }
    }

    public IEnumerable<Ride> Rides { get; internal set; }

    public Passenger(string name, int natId, string paymentcard, int phoneNumber)
    {
        this.name = name;
        this.natId = natId;
        this.paymentcard = paymentcard;
        this.phoneNumber = phoneNumber;
    }

    internal bool Info()
    {
        throw new NotImplementedException();
    }

    internal Ride RequestRide(Location start, Location destination)
    {
        throw new NotImplementedException();
    }
}

internal class Ride
{
    public Driver Driver { get; internal set; }
    public Passenger Passenger { get; internal set; }
    public bool FromAddress { get; internal set; }
    public bool ToAddress { get; internal set; }
    public bool Cost { get; internal set; }
    public bool IsActive { get; internal set; }

    internal bool Info()
    {
        throw new NotImplementedException();
    }

    internal void RateDriver(int v)
    {
        throw new NotImplementedException();
    }
}