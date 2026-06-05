namespace s14con;

class Program
{
    static void Main(string[] args)
    {
        Dog d = new Dog(3, new Pair<int, int>(1,1));
        Animal a = d;
        d.Die();
        a.Die();
        
    }
    static void Main234(string[] args)
    {
        Pair<int,int> barn = new Pair<int, int>() {X=1, Y=3};
        Goat goat = new Goat(5, barn);
        goat.MakeSound();
        goat.Move(new Pair<int, int>(1,1));

        Dolphine fish = new Dolphine(10, barn);
        fish.Move(new Pair<int, int>(100, -10)); 

        Dog d = new Dog(3, new Pair<int, int>(1,1));
        Dog d2= new Dog(5, new Pair<int, int>(1,1));
        Goat g2 = new Goat(3, new Pair<int, int>(2,2));

        // Animal a = d;
        System.Console.WriteLine("-----------------------------------------");

        Animal [] animals = new Animal[]{goat, fish, d, d2, g2};
        foreach(Animal a in animals)
        {
            a.MakeSound();
            // a.color
        }
    }

    static void Main2(string[] args)
    {
        // Pair<int,int> barn = new Pair<int, int>() {X=1, Y=3};
        // Animal goat = new Animal("boz", 5, barn);
        // System.Console.WriteLine(goat);
        // barn.X = 4;
        // barn.Y = -1;
        // Animal dog = new Animal("sag", 10, barn);
        // System.Console.WriteLine(dog);
        // System.Console.WriteLine(goat);
        // dog.MakeSound();
        // dog.Move(new Pair<int,int>(5, 10));
        // goat.MakeSound();
        // goat.Move(new Pair<int,int>(5, 10));
        // Animal fish = new Animal("dolphine", 10, barn);
        // fish.Move(new Pair<int, int>(100, -10));

    }
}
