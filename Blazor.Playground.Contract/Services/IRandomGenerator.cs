using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Playground.Contract.Services
{
    public interface IRandomGenerator
    {
        int NextInt(int maxValue = 100);
    }
}
