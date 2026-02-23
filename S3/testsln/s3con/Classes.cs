
using System.Security.Cryptography;

public class Point
{
    double X;
    double Y;

    public Point()
    {
        X = 0; Y = 0;
    }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double DistanceTo(Point p)
    {
        return Math.Sqrt(p.X*X + p.Y*Y);
    }

    public void Print()
    {
        System.Console.WriteLine($"X: {X}, Y: {Y}");
    }

    public void Move(Point p)
    {
        X += p.X;
        Y += p.Y;
    }
}

class Exe
{
    static void Main(string[] args)
    {
        Point p1 = new Point();
        Point p = new Point(1.1, 2.2);
        p.Print();
        Point pp = new Point(3, 5);
        p.Move(pp);
        p.Print();
        double dd = pp.DistanceTo(p1);
    }
}


public class Square
{
    public Point [] Points;

    public Square(params Point[] p1)
    {
        Points = (Point[]) p1.Clone();
    }
    public double Area
    {
        get
        {
            return Math.Pow(Points[0].DistanceTo(Points[1]), 2);
        }
    }
    public double Circumference()
    {
        return 0;
    }
    public void Move(Point p)
    {
        foreach(Point pp in Points)
            pp.Move(p);
    }
    public void Rotate(double degree)
    {        
    }

    public int PointCount() => Points.Length;
}