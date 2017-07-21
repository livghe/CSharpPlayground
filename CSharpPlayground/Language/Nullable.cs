using System;

// Nullable<int> is equivalent to int?
// Null coalescing operator ??: if 1st op is null, then return 2nd.

public class NullableTest
{
    public static void Start(string[] args)
    {
        Console.WriteLine("NullableTest.Start(...)");

        Console.WriteLine(null == null);                // True
        Console.WriteLine((bool?)null == (bool?)null);  // True

        // System.Nullable<int> is equivalent to int?
        {
            int? x = null;

            // null coalescing operator: if the 1st operand is non-null, return it. otherwise return the second operand.
            int y = x ?? 5; // y is 5

            int? a = null, b = 1, c = 2;
            Console.WriteLine("a ?? b ?? c = {0}", a ?? b ?? c);

            Console.WriteLine("a ?? x = {0}", null ?? x);
        }

        {
            int? x = 5;
            int? y = null;
            
            // Equality operator examples
            Console.WriteLine(x == y); // False
            Console.WriteLine(x == null); // False
            Console.WriteLine(x == 5); // True
            Console.WriteLine(y == null); // True
            Console.WriteLine(y == 5); // False
            Console.WriteLine(y != 5); // True
            
            // Relational operator examples
            Console.WriteLine(x < 6); // True
            Console.WriteLine(y < 6); // False
            Console.WriteLine(y > 6); // False
            
            // All other operator examples
            Console.WriteLine(x + 5); // 10
            Console.WriteLine(x + y); // null (prints empty line)
        }

        {
            bool? n = null;
            bool? f = false;
            bool? t = true;

            Console.WriteLine(n | n); // (null)
            Console.WriteLine(n | f); // (null)
            Console.WriteLine(n | t); // True
            Console.WriteLine(n & n); // (null)
            Console.WriteLine(n & f); // False
            Console.WriteLine(n & t); // (null)
        }
    }
}