namespace S4con.Test;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Account a = new Account("ali", 12341234, 10);
        int st = 1234132;
        a.Deposit(st, 10);
        double mb = a.Balance;
    }
}