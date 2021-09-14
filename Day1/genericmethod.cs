// using System;
// namespace NET{
// class genericmethod
// {
//     static void Main(string[] args)
//     {
//         int a = 10, b = 90;
//         Console.WriteLine("Before swap: {0}, {1}", a, b);
//         Swap<int> (ref a, ref b);
//         Console.WriteLine("After swap: {0}, {1}", a, b);

//         //Swap 2 strings
//         string s1 = "Hello", s2 = "There";
//         Console.WriteLine("Before swap: {0}, {1}", s1, s2);
//         Swap<string>(ref a, ref b);
//         Console.WriteLine("After swap: {0}, {1}", s1, s2);
//     }

//     static void Swap<T>(ref T a, ref T b)
//     {
//         T temp;
//         temp = a;
//         a = b;
//         b = temp;
//     }
// }
// }