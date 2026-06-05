
class Pair<_xType, _yType>
{
    public Pair(){}
    public Pair(_xType x, _yType y)
    {
        this.X = x;
        this.Y = y;
    }
    public _xType X;
    public _yType Y;
    public override string ToString() => $"{X},{Y}";
    public Pair<_xType, _yType> Clone() => new Pair<_xType, _yType>() {X = this.X, Y = this.Y};
}

abstract class Animal
{
    public string Name {get; set;}
    public int Age {get; set;}
    public Pair<int,int> Location;

    public override string ToString()
    {
        return $"{Name},{Age},{Location}";
    }

    public void Die() //virtual          // pure virtual      void method1() = 0;
    {
        System.Console.WriteLine($"{Name} died at the age of {Age}");
    }

    protected Animal(string name, int age, Pair<int,int> location)
    {
        this.Name = name;
        this.Age = age;
        this.Location = location.Clone();
    }

    public virtual void Move(Pair<int,int> vector)
    {
        this.Location.X += vector.X;
        this.Location.Y += vector.Y;
    }

    public abstract void MakeSound();
}

abstract class LandAnimal: Animal
{
    public double LandSpeed {get; set;}

    protected LandAnimal(string name, int age, Pair<int,int> location)
        :base(name, age, location)
    {}

    public override void Move(Pair<int, int> vector)
    {
        base.Move(vector);
        System.Console.WriteLine($"{this.Name} walked to {this.Location}");
    }
}

class Dog: LandAnimal
{
    public Dog(int age, Pair<int,int> location)
        :base("sag", age, location)
        {}

    public override void MakeSound()
    {
        System.Console.WriteLine("hap hap");
    }

    public new void Die()
    {
        System.Console.WriteLine($"{Name} died at the age of {Age} while hop hoping");
    }    
}

class Goat: LandAnimal
{
    public Goat(int age, Pair<int,int> location)
        :base("boz", age, location)
        {}

    public override void MakeSound()
    {
        System.Console.WriteLine("be be");
    }        
    
}

abstract class SeaAnimal: Animal
{
    protected SeaAnimal(string name, int age, Pair<int,int> location)
        :base(name, age, location)
        {}    

    public override void Move(Pair<int, int> vector)
    {
        base.Move(vector);
        System.Console.WriteLine($"{this.Name} swam to {this.Location}");
    }   
}

class Dolphine: SeaAnimal
{
    public Dolphine(int age, Pair<int,int> location)
        :base("dolphine", age, location)
        {}

    public override void MakeSound()
    {
        System.Console.WriteLine("weee weee");
    }
}