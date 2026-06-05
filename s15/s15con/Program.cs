namespace s15con;


class Program
{
    delegate int BinOp(int a, int b);

    static int[] apply(int[] l1, int[] l2, Func<int, int, int> op)
    {
        var retl = new int[l1.Length];
        for(int i=0; i<l1.Length; i++)
            retl[i] = op(l1[i],l2[i]);
        return retl;
    }


    static void perform(int[] l1, int[] l2, Action<int, int> op)
    {
        for(int i=0; i<l1.Length; i++)
            op(l1[i],l2[i]);        
    }


    // static int[] apply(int[] l1, int[] l2, BinOp op)
    // {
    //     var retl = new int[l1.Length];
    //     for(int i=0; i<l1.Length; i++)
    //         retl[i] = op(l1[i],l2[i]);
    //     return retl;
    // }

    static int PlusOp(int a, int b) => a + b;
    static int MulOp(int c, int d) => c * d;

    static void Main(string[] args)
    {
        int[] nums1 = new int[] {1,2,3,4,-1,5};
        int[] nums2 = new int[] {-1,-2,3,4,-1,4};

        int[] result = apply(nums1, nums2, PlusOp);
        result = apply(nums1, nums2, MulOp);
        result = apply(nums1, nums2, (int x, int y) => {

            return x / y;
        });

        int x = 5;
        var myfn = (int l, int r) =>
        {
            int sum = 0 + result[0];            
            for(int i=l; i<r; i++)
                sum+=i;
            return sum+l*x;
        };
        result = apply(nums1, nums2, myfn);

        perform(nums1, nums2, (int a, int b) => System.Console.WriteLine($"{a},{b}"));

    }
}
