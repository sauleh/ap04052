using System.Collections;
using System.Numerics;

interface IHasGPA<_GPAType> //where _GPAType: INumber<double>
{
    _GPAType GPA {get;}
}
class Pair<_Tx>: IEnumerable<_Tx> // _GPAType
    // where _GPAType: INumber<double>
    where _Tx: IComparable<_Tx> //, IHasGPA<_GPAType>, new()
{
    public _Tx x {get; set;}
    public _Tx y {get; set;}

    public IEnumerator<_Tx> GetEnumerator()
    {
        yield return x;
        yield return y;
        // var nums = new _Tx[]{x,y};
        // return (IEnumerator<_Tx>) nums.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    void test()
    {
        // _Tx w = new _Tx();
        // _GPAType d = x.GPA;
        // d += 1;

        Pair<int> p = new Pair<int>() {x=2, y=5};
        foreach(int n in p)
            System.Console.WriteLine(n);
    }
}

public class Student
{
    
}