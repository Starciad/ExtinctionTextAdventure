using System;

namespace ExtinctionTextAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            new Startup().Main(args).GetAwaiter().GetResult();
        }
    }
}