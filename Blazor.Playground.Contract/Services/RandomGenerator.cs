using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Playground.Contract.Services
{
    public class RandomGenerator : IRandomGenerator
    {
        private readonly Random Random;

        public RandomGenerator()
        {
            Random = new Random();
        }

        int IRandomGenerator.NextInt(int maxValue)
            => Random.Next(maxValue);
    }
}
