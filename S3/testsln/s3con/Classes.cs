
class Point
{
    double X;
    double Y;
    double Z;

    public Point()
    {
        X = 0; Y = 0;
    }

    public Point(double x, double y, double z = 0)
    {
        X = x;
        Y = y;
        Z = z;
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


class Square
{
    public Square(params Point[] p1)
    {
        
    }

    public double Area()
    {
        return 0;
    }

    public double Circumference()
    {
        return 0;
    }

    public void Move(Point p)
    {
        
    }

    public void Rotate(double degree)
    {
        
    }

}