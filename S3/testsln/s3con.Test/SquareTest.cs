namespace s3con.Test;

[TestClass]
public class SquareTest
{
    [TestMethod]
    public void ConstructorTest()
    {        
        Point[] points = new Point[]
        {
            new Point(0,0), new Point(1,0), 
            new Point(1,1), new Point(0,1)            
        };        
        Square s = new Square(points);        
        foreach(Point pp in s.Points)
            Assert.IsTrue(pp != null);
        Assert.AreEqual(s.PointCount(), 4);

        points[0] = null;

        foreach(Point pp in s.Points)
            Assert.IsTrue(pp != null);
        Assert.AreEqual(s.PointCount(), 4);


    }

    [TestMethod]
    public void AreaTest()
    {        
        Assert.Inconclusive();
        Square s = new Square(new Point(0,0), new Point(1,0), 
                              new Point(1,1), new Point(0,1));
        Assert.AreEqual(s.Area, 1);                              
    }

    [TestMethod]
    public void CircumferenceTest()
    {        
        Assert.Inconclusive();
        Square s = new Square(new Point(0,0), new Point(1,0), 
                              new Point(1,1), new Point(0,1));
        Assert.AreEqual(s.Circumference(), 4);
    }

}