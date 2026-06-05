// namespace s15con;

// interface IBinOp
// {
//     int eval(int a, int b);
// }

// class PlusOp : IBinOp
// {
//     public int eval(int a, int b) => a + b;
// }

// class MulOp : IBinOp
// {
//     public int eval(int a, int b) => a * b;
// }

// static class Operators
// {
//     public static PlusOp PlusOp = new PlusOp();
//     public static MulOp MulOp = new MulOp();
// }

// class Program
// {
//     static int[] apply(int[] l1, int[] l2, IBinOp op)
//     {
//         var retl = new int[l1.Length];
//         for(int i=0; i<l1.Length; i++)
//             retl[i] = op.eval(l1[i],l2[i]);
//         return retl;
//     }

//     static void Main(string[] args)
//     {
//         int[] nums1 = new int[] {1,2,3,4,-1,5};
//         int[] nums2 = new int[] {-1,-2,3,4,-1,0};

//         int[] result = apply(nums1, nums2, Operators.PlusOp);
//         result = apply(nums1, nums2, Operators.MulOp);
//     }
// }
