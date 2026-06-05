
// class Pair<_xType, _yType>
// {
//     public Pair(){}
//     public Pair(_xType x, _yType y)
//     {
//         this.X = x;
//         this.Y = y;
//     }
//     public _xType X;
//     public _yType Y;
//     public override string ToString() => $"{X},{Y}";
//     public Pair<_xType, _yType> Clone() => new Pair<_xType, _yType>() {X = this.X, Y = this.Y};
// }

// class Animal
// {
//     public string Name {get; set;}
//     public int Age {get; set;}
//     public Pair<int,int> Location;

//     public override string ToString()
//     {
//         return $"{Name},{Age},{Location}";
//     }

//     public Animal(string name, int age, Pair<int,int> location)
//     {
//         this.Name = name;
//         this.Age = age;
//         this.Location = location.Clone();
//     }

//     public void Move(Pair<int,int> vector)
//     {
//         this.Location.X += vector.X;
//         this.Location.Y += vector.Y;
//         string movestr;
//         if (this.Name == "boz" || this.Name == "sag")
//             movestr= "walked";
//         else
//             movestr= "swam";

//         System.Console.WriteLine($"{this.Name} {movestr} {this.Location}");
//     }

//     public void MakeSound()
//     {
//         if (this.Name == "boz")
//             System.Console.WriteLine($"be be");
//         else if (this.Name == "sag")
//             System.Console.WriteLine("Hap Hap");
//     }
    
// }