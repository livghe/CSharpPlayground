using System;
using System.Linq.Expressions;

// Chapter 4: Lambdas
// Lambda expressions are used most commonly with the System.Func and System.Action delegates.
// Lambda expressions can capture local variables. They are then called closures.

// An anonymous method is like a lambda expression, but it lacks the following features:
// 1. Implicitly typed parameters.
// 2. Expression syntax (an anonymous method must always be a statement block).
// 3. The ability to compile to an expression tree by assigning to Expression<T>.


namespace Sample
{
    class Lambdas
    {
        static System.Func<int> Natural()
        {
            // seed would normally go out of scope when Natural() reaches end. 
            // But because it is captured in a lambda, its lifetime is extended to match the lifetime of the capturing closure/lambda.
            int seed = 0;
            return () => seed++; // Returns a closure
        }

        static void CaptureIteratorTest()
        {
            Action[] actions = new Action[3];

            System.Console.WriteLine("Capturing an iterator variable...");
            for (int i = 0; i < 3; i++)
                actions[i] = () => Console.Write(i);

            foreach (Action a in actions)
            {
                a(); // prints 333, not 012
            }
            Console.WriteLine();
        }

        static void AnonymousMethodTest()
        {
            System.Func<int, int> sqr = delegate (int x) { return x * x; };
            Console.WriteLine("sqr(x) = {0}", sqr(5));

            // a unique feature of Anonymous Methods is that you can omit the parameter declaration part completely, even if the Delegate declares it:
            // public event EventHandler Clicked = delegate { };
            // public event EventHandler Clicked = delegate { System.Console.WriteLine("Clicked!"); };
        }

        public static void Start(string[] args)
        {
            Console.WriteLine("Lambas...");
            System.Func<int, int, int> Sum = (int x, int y) => (x + y); // explicitly specify the types of the lambda params
            System.Func<int, int, int> Diff = (x, y) => x - y;

            int factor = 3;
            // local variable capturing. Prod is now a Closure due to the capturing.
            // Captured variables are evaluated when the delegate is actually invoked, not when the variables were captured.
            System.Func<int, int, int> Prod = (int x, int y) => { return (x * y * factor); };

            int a = 32;
            int b = 11;
            System.Console.WriteLine("a = {0}, b = {1}, Sum={2}, Diff={3}, Prod={4}", a, b, Sum(a, b), Diff(a, b), Prod(a, b));

            CaptureIteratorTest();
            AnonymousMethodTest();
            Console.WriteLine();
        }
    }
}