using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace csplay
{
    class Linq
    {
        // All Linq extension methods are located in System.Linq.Enumerable static class

        public static void Start(string[] args)
        {

            // Where clause
            var result = Enumerable.Range(1, 10000).Where((int n) => { return (n % 2) == 0; });

            // OrderBy
            var orderedResult = Enumerable.Range(1, 10000).OrderBy(n => n);

            string[] words = "the quick brown fox jumps over the lazy dog".Split(' ');

            var query = from word in words
                        group word.ToUpper() by word.Length into gr
                        orderby gr.Key
                        select new { Length = gr.Key, Words = gr };

            // Using method-based query syntax.  
            var query2 = words.GroupBy(w => w.Length, w => w.ToUpper()).
                Select(g => new { Length = g.Key, Words = g }).
                OrderBy(o => o.Length);
        }
    }
}