// RideSharingExample.MsTests.cs
// MSTest unit tests for the RideSharingExample implementation you pasted.
//
// 1) Create an MSTest test project:
//    dotnet new mstest -n RideSharingExample.Tests
// 2) Add reference to your production project (that contains namespace RideSharingExample):
//    dotnet add RideSharingExample.Tests reference RideSharingExample
//
// These tests cover: Person, Vehicle, Driver, Ride, RideService.
// Note: Ride uses a private static "nextId" counter. We reset it via reflection in tests
// to make RideId deterministic.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using RideSharingExample;
using System;
using System.Linq;
using System.Reflection;

namespace RideSharingExample.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Constructor_SetsProperties()
        {
            var p = new Person("GB-1", "Alice", "Jones", "07111");

            Assert.AreEqual("GB-1", p.NationalId);
            Assert.AreEqual("Alice", p.FirstName);
            Assert.AreEqual("Jones", p.LastName);
            Assert.AreEqual("07111", p.PhoneNumber);
            Assert.AreEqual("Alice Jones", p.FullName());
        }

        [TestMethod]
        [DataRow(null, "A", "B", "1")]
        [DataRow("", "A", "B", "1")]
        [DataRow("   ", "A", "B", "1")]
        [DataRow("ID", null, "B", "1")]
        [DataRow("ID", "", "B", "1")]
        [DataRow("ID", "A", null, "1")]
        [DataRow("ID", "A", "", "1")]
        [DataRow("ID", "A", "B", null)]
        [DataRow("ID", "A", "B", "")]
        public void Constructor_InvalidInputs_Throws(string id, string fn, string ln, string phone)
        {
            Assert.ThrowsException<ArgumentException>(() => new Person(id, fn, ln, phone));
        }

        [TestMethod]
        public void UpdatePhoneNumber_ChangesPhoneNumber()
        {
            var p = new Person("GB-1", "Alice", "Jones", "07111");
            p.UpdatePhoneNumber("07000");

            Assert.AreEqual("07000", p.PhoneNumber);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("   ")]
        public void UpdatePhoneNumber_Invalid_Throws(string newPhone)
        {
            var p = new Person("GB-1", "Alice", "Jones", "07111");
            Assert.ThrowsException<ArgumentException>(() => p.UpdatePhoneNumber(newPhone));
        }

        [TestMethod]
        public void Equals_SameNationalId_IsTrue_AndHashMatches()
        {
            var p1 = new Person("GB-1", "Alice", "Jones", "07111");
            var p2 = new Person("GB-1", "Alicia", "Jones", "07222");

            Assert.IsTrue(p1.Equals(p2));
            Assert.AreEqual(p1.GetHashCode(), p2.GetHashCode());
        }

        [TestMethod]
        public void Equals_DifferentNationalId_IsFalse()
        {
            var p1 = new Person("GB-1", "Alice", "Jones", "07111");
            var p2 = new Person("GB-2", "Alice", "Jones", "07111");

            Assert.IsFalse(p1.Equals(p2));
        }

        [TestMethod]
        public void ToString_ContainsKeyFields()
        {
            var p = new Person("GB-1", "Alice", "Jones", "07111");
            var s = p.ToString();

            StringAssert.Contains(s, "Alice Jones");
            StringAssert.Contains(s, "GB-1");
            StringAssert.Contains(s, "07111");
        }
    }

    [TestClass]
    public class VehicleTests
    {
        [TestMethod]
        public void Constructor_NormalizesPlate_AndSetsFields()
        {
            var owner = new Person("GB-1", "Alice", "Jones", "07111");
            var v = new Vehicle("ab12 cde", "Toyota Prius", owner);

            Assert.AreEqual("AB12 CDE", v.LicensePlate);
            Assert.AreEqual("Toyota Prius", v.Model);
            Assert.AreSame(owner, v.Owner);
        }

        [TestMethod]
        public void GetVehicleInfo_ContainsOwnerName_Model_Plate()
        {
            var owner = new Person("GB-1", "Alice", "Jones", "07111");
            var v = new Vehicle("ab12 cde", "Toyota Prius", owner);

            var info = v.GetVehicleInfo();
            StringAssert.Contains(info, "Toyota Prius");
            StringAssert.Contains(info, "AB12 CDE");
            StringAssert.Contains(info, "Alice Jones");
        }

        [TestMethod]
        public void ToString_ReturnsVehicleInfo()
        {
            var owner = new Person("GB-1", "Alice", "Jones", "07111");
            var v = new Vehicle("ab12 cde", "Toyota Prius", owner);

            Assert.AreEqual(v.GetVehicleInfo(), v.ToString());
        }

        [TestMethod]
        public void UpdateModel_ChangesModel()
        {
            var owner = new Person("GB-1", "Alice", "Jones", "07111");
            var v = new Vehicle("AB12 CDE", "Toyota Prius", owner);

            v.UpdateModel("Tesla Model 3");
            Assert.AreEqual("Tesla Model 3", v.Model);
        }

        [TestMethod]
        public void UpdateLicensePlate_Normalizes()
        {
            var owner = new Person("GB-1", "Alice", "Jones", "07111");
            var v = new Vehicle("AB12 CDE", "Toyota Prius", owner);

            v.UpdateLicensePlate("xy99 zzz");
            Assert.AreEqual("XY99 ZZZ", v.LicensePlate);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("   ")]
        public void UpdateModel_Invalid_Throws(string model)
        {
            var owner = new Person("GB-1", "Alice", "Jones", "07111");
            var v = new Vehicle("AB12 CDE", "Toyota Prius", owner);

            Assert.ThrowsException<ArgumentException>(() => v.UpdateModel(model));
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("   ")]
        public void UpdateLicensePlate_Invalid_Throws(string plate)
        {
            var owner = new Person("GB-1", "Alice", "Jones", "07111");
            var v = new Vehicle("AB12 CDE", "Toyota Prius", owner);

            Assert.ThrowsException<ArgumentException>(() => v.UpdateLicensePlate(plate));
        }

        [TestMethod]
        public void Constructor_Invalid_Throws()
        {
            var owner = new Person("GB-1", "Alice", "Jones", "07111");

            Assert.ThrowsException<ArgumentException>(() => new Vehicle("", "Model", owner));
            Assert.ThrowsException<ArgumentException>(() => new Vehicle("PLATE", "", owner));
            Assert.ThrowsException<ArgumentNullException>(() => new Vehicle("PLATE", "Model", null!));
        }
    }

    [TestClass]
    public class DriverTests
    {
        [TestMethod]
        public void Constructor_RequiresDriverOwnsVehicle()
        {
            var alice = new Person("GB-1", "Alice", "Jones", "07111");
            var bob = new Person("GB-2", "Bob", "Smith", "07222");
            var bobsCar = new Vehicle("AB12 CDE", "Toyota Prius", bob);

            Assert.ThrowsException<InvalidOperationException>(() => new Driver(alice, bobsCar));
        }

        [TestMethod]
        public void AddRating_AndCalculateAverageRating()
        {
            var alice = new Person("GB-1", "Alice", "Jones", "07111");
            var car = new Vehicle("AB12 CDE", "Toyota Prius", alice);
            var d = new Driver(alice, car);

            Assert.AreEqual(0.0, d.CalculateAverageRating(), 0.0001);

            d.AddRating(5);
            d.AddRating(4);

            Assert.AreEqual(4.5, d.CalculateAverageRating(), 0.0001);
            Assert.AreEqual(2, d.Ratings.Count);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(6)]
        [DataRow(-1)]
        public void AddRating_OutOfRange_Throws(int rating)
        {
            var alice = new Person("GB-1", "Alice", "Jones", "07111");
            var car = new Vehicle("AB12 CDE", "Toyota Prius", alice);
            var d = new Driver(alice, car);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => d.AddRating(rating));
        }

        [TestMethod]
        public void AddRide_Valid_AddsToList()
        {
            ResetRideIdCounterForTests();

            var alice = new Person("GB-1", "Alice", "Jones", "07111");
            var bob = new Person("GB-2", "Bob", "Smith", "07222");
            var car = new Vehicle("AB12 CDE", "Toyota Prius", alice);
            var d = new Driver(alice, car);

            var ride = new Ride(bob, d, "A", "B", 10m);
            d.AddRide(ride);

            Assert.AreEqual(1, d.Rides.Count);
            Assert.AreSame(ride, d.Rides[0]);
        }

        [TestMethod]
        public void AddRide_WrongDriver_Throws()
        {
            ResetRideIdCounterForTests();

            var alice = new Person("GB-1", "Alice", "Jones", "07111");
            var carA = new Vehicle("AB12 CDE", "Toyota Prius", alice);
            var driverA = new Driver(alice, carA);

            var eve = new Person("GB-3", "Eve", "Stone", "07333");
            var carE = new Vehicle("ZZ99 ZZZ", "Honda Civic", eve);
            var driverE = new Driver(eve, carE);

            var passenger = new Person("GB-9", "Pat", "Rider", "07000");
            var rideAssignedToE = new Ride(passenger, driverE, "A", "B", 10m);

            Assert.ThrowsException<InvalidOperationException>(() => driverA.AddRide(rideAssignedToE));
        }

        [TestMethod]
        public void ToString_ContainsNameVehicleAndRatingText()
        {
            var alice = new Person("GB-1", "Alice", "Jones", "07111");
            var car = new Vehicle("AB12 CDE", "Toyota Prius", alice);
            var d = new Driver(alice, car);

            var s1 = d.ToString();
            StringAssert.Contains(s1, "Alice Jones");
            StringAssert.Contains(s1, "Toyota Prius");
            StringAssert.Contains(s1, "No ratings yet");

            d.AddRating(5);
            var s2 = d.ToString();
            StringAssert.Contains(s2, "Avg rating");
        }

        private static void ResetRideIdCounterForTests()
        {
            var rideType = typeof(Ride);
            var field = rideType.GetField("nextId", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.IsNotNull(field, "Could not find Ride.nextId via reflection.");
            field!.SetValue(null, 1);
        }
    }

    [TestClass]
    public class RideTests
    {
        [TestInitialize]
        public void Init()
        {
            ResetRideIdCounterForTests();
        }

        [TestMethod]
        public void Constructor_SetsProperties_AndIncrementsRideId()
        {
            var driver = BuildDriver("GB-1");
            var passenger = new Person("GB-9", "Pat", "Rider", "07000");

            var r1 = new Ride(passenger, driver, "Start", "End", 12.34m);
            var r2 = new Ride(passenger, driver, "Start2", "End2", 56.78m);

            Assert.AreEqual(1, r1.RideId);
            Assert.AreEqual(2, r2.RideId);

            Assert.AreSame(passenger, r1.Passenger);
            Assert.AreSame(driver, r1.Driver);
            Assert.AreEqual("Start", r1.StartLocation);
            Assert.AreEqual("End", r1.EndLocation);
            Assert.AreEqual(12.34m, r1.Price);

            // time should be "recent" (within a couple seconds)
            Assert.IsTrue((DateTime.Now - r1.RideTime).TotalSeconds < 5);
        }

        [TestMethod]
        public void Constructor_Invalid_Throws()
        {
            var driver = BuildDriver("GB-1");
            var passenger = new Person("GB-9", "Pat", "Rider", "07000");

            Assert.ThrowsException<ArgumentNullException>(() => new Ride(null!, driver, "A", "B", 1m));
            Assert.ThrowsException<ArgumentNullException>(() => new Ride(passenger, null!, "A", "B", 1m));

            Assert.ThrowsException<ArgumentException>(() => new Ride(passenger, driver, "", "B", 1m));
            Assert.ThrowsException<ArgumentException>(() => new Ride(passenger, driver, "A", "", 1m));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Ride(passenger, driver, "A", "B", -1m));
        }

        [TestMethod]
        public void ToString_ContainsRideSummary()
        {
            var driver = BuildDriver("GB-1");
            var passenger = new Person("GB-9", "Pat", "Rider", "07000");

            var r = new Ride(passenger, driver, "Kings Cross", "Oxford Circus", 14.50m);

            var s = r.ToString();
            StringAssert.Contains(s, "Ride #");
            StringAssert.Contains(s, "Pat Rider");
            StringAssert.Contains(s, "Kings Cross");
            StringAssert.Contains(s, "Oxford Circus");
            StringAssert.Contains(s, "£14.50");
        }

        private static Driver BuildDriver(string nationalId)
        {
            var p = new Person(nationalId, "Alice", "Jones", "07111");
            var car = new Vehicle("AB12 CDE", "Toyota Prius", p);
            return new Driver(p, car);
        }

        private static void ResetRideIdCounterForTests()
        {
            var rideType = typeof(Ride);
            var field = rideType.GetField("nextId", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.IsNotNull(field, "Could not find Ride.nextId via reflection.");
            field!.SetValue(null, 1);
        }
    }

    [TestClass]
    public class RideServiceTests
    {
        [TestInitialize]
        public void Init()
        {
            ResetRideIdCounterForTests();
        }

        [TestMethod]
        public void AddDriver_AddsDriver_AndPreventsDuplicateByNationalId()
        {
            var service = new RideService();

            var driver1 = BuildDriver("GB-1");
            service.AddDriver(driver1);

            Assert.AreEqual(1, service.Drivers.Count);
            Assert.AreSame(driver1, service.Drivers[0]);

            // Duplicate: same person national id, different objects
            var duplicatePerson = new Person("GB-1", "Alicia", "Jones", "07000");
            var duplicateVehicle = new Vehicle("ZZ99 ZZZ", "Honda Civic", duplicatePerson);
            var duplicateDriver = new Driver(duplicatePerson, duplicateVehicle);

            Assert.ThrowsException<InvalidOperationException>(() => service.AddDriver(duplicateDriver));
        }

        [TestMethod]
        public void CreateRide_RequiresDriverRegistered()
        {
            var service = new RideService();

            var unregisteredDriver = BuildDriver("GB-1");
            var passenger = new Person("GB-9", "Pat", "Rider", "07000");

            Assert.ThrowsException<InvalidOperationException>(() =>
                service.CreateRide(passenger, unregisteredDriver, "A", "B", 10m));
        }

        [TestMethod]
        public void CreateRide_AddsRideToService_AndToDriver()
        {
            var service = new RideService();
            var driver = BuildDriver("GB-1");
            service.AddDriver(driver);

            var passenger = new Person("GB-9", "Pat", "Rider", "07000");

            var ride = service.CreateRide(passenger, driver, "A", "B", 10m);

            Assert.AreEqual(1, service.Rides.Count);
            Assert.AreSame(ride, service.Rides[0]);

            Assert.AreEqual(1, driver.Rides.Count);
            Assert.AreSame(ride, driver.Rides[0]);
        }

        [TestMethod]
        public void GetTotalRevenue_SumsRidePrices()
        {
            var service = new RideService();
            var driver = BuildDriver("GB-1");
            service.AddDriver(driver);

            var p1 = new Person("GB-9", "Pat", "Rider", "07000");
            var p2 = new Person("GB-8", "Sam", "Rider", "07001");

            service.CreateRide(p1, driver, "A", "B", 10.50m);
            service.CreateRide(p2, driver, "C", "D", 20.25m);

            Assert.AreEqual(30.75m, service.GetTotalRevenue());
        }

        [TestMethod]
        public void GetRidesForPassenger_FiltersByPassengerEquals()
        {
            var service = new RideService();
            var driver = BuildDriver("GB-1");
            service.AddDriver(driver);

            var bob = new Person("GB-2", "Bob", "Smith", "07222");
            var charlie = new Person("GB-3", "Charlie", "Khan", "07333");

            service.CreateRide(bob, driver, "A", "B", 10m);
            service.CreateRide(bob, driver, "C", "D", 11m);
            service.CreateRide(charlie, driver, "E", "F", 12m);

            var bobsRides = service.GetRidesForPassenger(bob);
            Assert.AreEqual(2, bobsRides.Count);
            Assert.IsTrue(bobsRides.All(r => r.Passenger.Equals(bob)));
        }

        [TestMethod]
        public void GetRidesForDriver_FiltersByReference()
        {
            var service = new RideService();
            var driver1 = BuildDriver("GB-1");
            var driver2 = BuildDriver("GB-2");
            service.AddDriver(driver1);
            service.AddDriver(driver2);

            var passenger = new Person("GB-9", "Pat", "Rider", "07000");

            service.CreateRide(passenger, driver1, "A", "B", 10m);
            service.CreateRide(passenger, driver1, "C", "D", 11m);
            service.CreateRide(passenger, driver2, "E", "F", 12m);

            var d1Rides = service.GetRidesForDriver(driver1);
            var d2Rides = service.GetRidesForDriver(driver2);

            Assert.AreEqual(2, d1Rides.Count);
            Assert.AreEqual(1, d2Rides.Count);
            Assert.IsTrue(d1Rides.All(r => ReferenceEquals(r.Driver, driver1)));
            Assert.IsTrue(d2Rides.All(r => ReferenceEquals(r.Driver, driver2)));
        }

        [TestMethod]
        public void FindDriverByNationalId_FindsOrReturnsNull()
        {
            var service = new RideService();
            var driver1 = BuildDriver("GB-1");
            service.AddDriver(driver1);

            var found = service.FindDriverByNationalId("GB-1");
            Assert.IsNotNull(found);
            Assert.AreSame(driver1, found);

            var notFound = service.FindDriverByNationalId("GB-999");
            Assert.IsNull(notFound);
        }

        private static Driver BuildDriver(string nationalId)
        {
            var p = new Person(nationalId, "Alice", "Jones", "07111");
            var car = new Vehicle("AB12 CDE", "Toyota Prius", p);
            return new Driver(p, car);
        }

        private static void ResetRideIdCounterForTests()
        {
            var rideType = typeof(Ride);
            var field = rideType.GetField("nextId", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.IsNotNull(field, "Could not find Ride.nextId via reflection.");
            field!.SetValue(null, 1);
        }
    }
}
