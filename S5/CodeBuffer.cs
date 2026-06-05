// RideSharingExample.cs
// Full, copy-pasteable example (no inheritance). Demonstrates composition, encapsulation,
// static members (ID generator), ToString/Equals, lists, and a simple service layer.

using System;
using System.Collections.Generic;
using System.Linq;

namespace RideSharingExample
{
    // ----------------------------
    // 1) Person
    // ----------------------------
    public sealed class Person
    {
        private readonly string nationalId;   // identity should not change
        private string firstName;
        private string lastName;
        private string phoneNumber;

        public Person(string nationalId, string firstName, string lastName, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(nationalId)) throw new ArgumentException("nationalId is required.");
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("firstName is required.");
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("lastName is required.");
            if (string.IsNullOrWhiteSpace(phoneNumber)) throw new ArgumentException("phoneNumber is required.");

            this.nationalId = nationalId.Trim();
            this.firstName = firstName.Trim();
            this.lastName = lastName.Trim();
            this.phoneNumber = phoneNumber.Trim();
        }

        public string NationalId => nationalId;
        public string FirstName => firstName;
        public string LastName => lastName;
        public string PhoneNumber => phoneNumber;

        public string FullName() => $"{firstName} {lastName}";

        public void UpdatePhoneNumber(string newPhoneNumber)
        {
            if (string.IsNullOrWhiteSpace(newPhoneNumber))
                throw new ArgumentException("Phone number cannot be empty.");
            phoneNumber = newPhoneNumber.Trim();
        }

        public override string ToString()
            => $"{FullName()} (ID: {nationalId}, Phone: {phoneNumber})";

        // People are "the same" if their NationalId matches.
        public override bool Equals(object? obj)
            => obj is Person other && string.Equals(nationalId, other.nationalId, StringComparison.Ordinal);

        public override int GetHashCode()
            => nationalId.GetHashCode(StringComparison.Ordinal);
    }

    // ----------------------------
    // 2) Vehicle
    // ----------------------------
    public sealed class Vehicle
    {
        private string licensePlate;
        private string model;
        private readonly Person owner;

        public Vehicle(string licensePlate, string model, Person owner)
        {
            if (string.IsNullOrWhiteSpace(licensePlate)) throw new ArgumentException("licensePlate is required.");
            if (string.IsNullOrWhiteSpace(model)) throw new ArgumentException("model is required.");
            this.owner = owner ?? throw new ArgumentNullException(nameof(owner));

            this.licensePlate = licensePlate.Trim().ToUpperInvariant();
            this.model = model.Trim();
        }

        public string LicensePlate => licensePlate;
        public string Model => model;
        public Person Owner => owner;

        public void UpdateModel(string newModel)
        {
            if (string.IsNullOrWhiteSpace(newModel)) throw new ArgumentException("Model cannot be empty.");
            model = newModel.Trim();
        }

        public void UpdateLicensePlate(string newPlate)
        {
            if (string.IsNullOrWhiteSpace(newPlate)) throw new ArgumentException("License plate cannot be empty.");
            licensePlate = newPlate.Trim().ToUpperInvariant();
        }

        public string GetVehicleInfo()
            => $"{model} [{licensePlate}] (Owner: {owner.FullName()})";

        public override string ToString() => GetVehicleInfo();
    }

    // ----------------------------
    // 3) Driver (composition: Driver HAS a Person, HAS a Vehicle)
    // ----------------------------
    public sealed class Driver
    {
        private readonly Person driverInfo;
        private readonly Vehicle vehicle;
        private readonly List<Ride> rides = new();

        // rating system: store ratings, compute average
        private readonly List<int> ratings = new(); // 1..5

        public Driver(Person driverInfo, Vehicle vehicle)
        {
            this.driverInfo = driverInfo ?? throw new ArgumentNullException(nameof(driverInfo));
            this.vehicle = vehicle ?? throw new ArgumentNullException(nameof(vehicle));

            // simple business rule: driver must own the vehicle
            if (!vehicle.Owner.Equals(driverInfo))
                throw new InvalidOperationException("Driver must be the owner of the vehicle in this simplified model.");
        }

        public Person DriverInfo => driverInfo;
        public Vehicle Vehicle => vehicle;

        public IReadOnlyList<Ride> Rides => rides;
        public IReadOnlyList<int> Ratings => ratings;

        public void AddRide(Ride ride)
        {
            if (ride == null) throw new ArgumentNullException(nameof(ride));
            if (!ReferenceEquals(ride.Driver, this))
                throw new InvalidOperationException("This ride is not assigned to this driver.");
            rides.Add(ride);
        }

        public void AddRating(int rating)
        {
            if (rating < 1 || rating > 5) throw new ArgumentOutOfRangeException(nameof(rating), "Rating must be 1..5.");
            ratings.Add(rating);
        }

        public double CalculateAverageRating()
            => ratings.Count == 0 ? 0.0 : ratings.Average();

        public override string ToString()
        {
            var avg = CalculateAverageRating();
            var ratingText = ratings.Count == 0 ? "No ratings yet" : $"Avg rating: {avg:F2} ({ratings.Count} rating(s))";
            return $"Driver: {driverInfo.FullName()} | {vehicle.Model} [{vehicle.LicensePlate}] | {ratingText}";
        }
    }

    // ----------------------------
    // 4) Ride (composition: Ride HAS a passenger Person, HAS a Driver)
    // ----------------------------
    public sealed class Ride
    {
        private static int nextId = 1; // static id generator

        private readonly int rideId;
        private readonly Person passenger;
        private readonly Driver driver;
        private readonly string startLocation;
        private readonly string endLocation;
        private readonly decimal price;
        private readonly DateTime rideTime;

        public Ride(Person passenger, Driver driver, string startLocation, string endLocation, decimal price)
        {
            this.passenger = passenger ?? throw new ArgumentNullException(nameof(passenger));
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));

            if (string.IsNullOrWhiteSpace(startLocation)) throw new ArgumentException("startLocation is required.");
            if (string.IsNullOrWhiteSpace(endLocation)) throw new ArgumentException("endLocation is required.");
            if (price < 0) throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");

            this.startLocation = startLocation.Trim();
            this.endLocation = endLocation.Trim();
            this.price = price;
            this.rideTime = DateTime.Now;

            this.rideId = nextId++;
        }

        public int RideId => rideId;
        public Person Passenger => passenger;
        public Driver Driver => driver;
        public string StartLocation => startLocation;
        public string EndLocation => endLocation;
        public decimal Price => price;
        public DateTime RideTime => rideTime;

        public override string ToString()
        {
            return $"Ride #{rideId} | {rideTime:g} | Passenger: {passenger.FullName()} | " +
                   $"Driver: {driver.DriverInfo.FullName()} | {startLocation} -> {endLocation} | £{price:F2}";
        }
    }

    // ----------------------------
    // 5) RideService (manages collections + business logic)
    // ----------------------------
    public sealed class RideService
    {
        private readonly List<Driver> drivers = new();
        private readonly List<Ride> rides = new();

        public IReadOnlyList<Driver> Drivers => drivers;
        public IReadOnlyList<Ride> Rides => rides;

        public void AddDriver(Driver driver)
        {
            if (driver == null) throw new ArgumentNullException(nameof(driver));

            // prevent duplicates by NationalId
            bool exists = drivers.Any(d => d.DriverInfo.Equals(driver.DriverInfo));
            if (exists) throw new InvalidOperationException("Driver already exists in the system.");

            drivers.Add(driver);
        }

        public Ride CreateRide(Person passenger, Driver driver, string start, string end, decimal price)
        {
            if (passenger == null) throw new ArgumentNullException(nameof(passenger));
            if (driver == null) throw new ArgumentNullException(nameof(driver));

            if (!drivers.Contains(driver))
                throw new InvalidOperationException("Driver must be registered in RideService before creating rides.");

            var ride = new Ride(passenger, driver, start, end, price);

            rides.Add(ride);
            driver.AddRide(ride);

            return ride;
        }

        public decimal GetTotalRevenue() => rides.Sum(r => r.Price);

        public List<Ride> GetRidesForPassenger(Person passenger)
        {
            if (passenger == null) throw new ArgumentNullException(nameof(passenger));
            return rides.Where(r => r.Passenger.Equals(passenger)).ToList();
        }

        public List<Ride> GetRidesForDriver(Driver driver)
        {
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            return rides.Where(r => ReferenceEquals(r.Driver, driver)).ToList();
        }

        public Driver? FindDriverByNationalId(string nationalId)
        {
            if (string.IsNullOrWhiteSpace(nationalId)) return null;
            return drivers.FirstOrDefault(d => d.DriverInfo.NationalId == nationalId.Trim());
        }
    }

    // ----------------------------
    // Demo Program
    // ----------------------------
    internal static class Program
    {
        private static void Main()
        {
            // Create people
            var alice = new Person("GB-1001", "Alice", "Johnson", "07111 111111");
            var bob = new Person("GB-2002", "Bob", "Smith", "07222 222222");
            var charlie = new Person("GB-3003", "Charlie", "Khan", "07333 333333");

            // Alice is a driver with a vehicle she owns
            var aliceCar = new Vehicle("AB12 CDE", "Toyota Prius", alice);
            var driverAlice = new Driver(alice, aliceCar);

            // System service
            var service = new RideService();
            service.AddDriver(driverAlice);

            // Create rides: Bob and Charlie are passengers
            var ride1 = service.CreateRide(bob, driverAlice, "King's Cross", "Oxford Circus", 14.50m);
            var ride2 = service.CreateRide(charlie, driverAlice, "Waterloo", "Canary Wharf", 21.25m);

            // Ratings for driver
            driverAlice.AddRating(5);
            driverAlice.AddRating(4);

            // Print info
            Console.WriteLine("=== People ===");
            Console.WriteLine(alice);
            Console.WriteLine(bob);
            Console.WriteLine(charlie);

            Console.WriteLine("\n=== Driver ===");
            Console.WriteLine(driverAlice);

            Console.WriteLine("\n=== Rides ===");
            Console.WriteLine(ride1);
            Console.WriteLine(ride2);

            Console.WriteLine("\n=== Revenue ===");
            Console.WriteLine($"Total revenue: £{service.GetTotalRevenue():F2}");

            // Show reuse of Person info: update Bob phone once, it updates everywhere Bob is referenced
            Console.WriteLine("\n=== Update passenger phone (Bob) ===");
            bob.UpdatePhoneNumber("07000 000000");
            Console.WriteLine("Bob after update: " + bob);

            Console.WriteLine("\nRides for Bob:");
            foreach (var r in service.GetRidesForPassenger(bob))
                Console.WriteLine(r);

            // Pause in some environments
            // Console.ReadLine();
        }
    }
}
