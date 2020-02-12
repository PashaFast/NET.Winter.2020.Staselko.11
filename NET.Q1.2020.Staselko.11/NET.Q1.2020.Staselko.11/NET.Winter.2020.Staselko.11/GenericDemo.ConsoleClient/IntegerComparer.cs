using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GenericDemo.ConsoleClient
{
    public class IntegerComparer : IComparer<int>
    {
        public int Compare([AllowNull] int x, [AllowNull] int y)
        {
            if (x > y) return 1;
            if (x < y) return -1;
            else return 0;
        }
    }
}
