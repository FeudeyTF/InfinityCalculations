using InfinityCalculations.InfinityArithmetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
namespace InfinityCalculations
{
    public static class BigMath
    {
        public static InfinityInt Power(InfinityInt x, int y)
        {
            if (y % 2 == 0)
            {
                InfinityInt power = Power(x, y / 2);
                return power * power;

            }
            else
            {
                InfinityInt r = 1;
                for (InfinityInt i = 0; i < y; i++)
                    r *= x;
                return r;
            }
        }
    }
}
