using s7con;

class MyArray
{
    public int[] nums {get; set;}

    public MyArray(int size)
    {
        nums = new int[size];
    }

    public int this[int i]
    {
        get => nums[i];
        set
        {
            nums[i] = value;
        }
    }

    public override bool Equals(object obj)
    {
        // this
        // obj
        object obj1234 = new Student("", 234);

        if (obj is not MyArray)
            return false;

        MyArray other = obj as MyArray;
        // if (other == null)
        //     return false;

        if (this.nums.Length != other.nums.Length)
            return false;

        for(int i=0; i<this.nums.Length; i++)
            if (this.nums[i] != other.nums[i])
                return false;

        return true;
    }

    public static bool operator==(MyArray o1, MyArray o2) => o1.Equals(o2);
    public static bool operator!=(MyArray o1, MyArray o2) => !o1.Equals(o2);

    // public void set(int idx, int value)
    // {
    //     nums[idx] = value;
    // }

    // public int get(int ids) => nums[ids];    
}