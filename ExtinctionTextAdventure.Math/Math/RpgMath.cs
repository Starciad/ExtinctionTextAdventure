using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtinctionTextAdventure.Utilities
{
    public static class RpgMath
    {
        public static int GetPercentageValue(int value, int percentage)
        {
            return (int)System.Math.Round(percentage * 0.01f * value);
        }
    }
}
