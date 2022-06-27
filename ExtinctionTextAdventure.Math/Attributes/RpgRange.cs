using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtinctionTextAdventure.Utilities
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Field)]
    public class RpgRange : Attribute
    {
        public int MinValue { get; }
        public int MaxValue { get; }

        public RpgRange(int min, int max)
        {
            MinValue = min;
            MaxValue = max;
        }
    }
}
