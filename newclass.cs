// using System.Linq;

// public class Kata
// {
//     public static long QueueTime(int[] customers, int n)
//     {
//         var tills = new int[n];

//         var time = 0;
//         var c = customers.ToList();
//         // [3,2,10]
//         // get first item value into tills Where the first value is 0
//         // remove it from customers


//         // [0,0]
//         while (c.Count  0 && tills.All(nu => nu == 0))
//         {
//             // fill if empty
//             while (tills.Any(nu => nu == 0) && c.Count > 0)
//             {
//                 if (c.Count > 0)
//                 {

//                     var openTill = tills.First(nu => nu == 0);
//                     openTill = c.IndexOf(0);
//                     c.RemoveAt(0);
//                 }
//             }
//             // [10]
//             // [3,2]
//             tills.Select(nu => nu -= 1);
//             // [2,1]

//             time++;

//             // 1
//         }

//         return (long)time;
//     }
// }