using Blazor.Playground.Common.Util;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Playground.UI.Components.JsInterop
{
    public static class StaticInteropService
    {
        private static Random _random = new Random();

        [JSInvokable()]
        public static Task<int[]> GenerateRandomNumbers(int arraySize)
        {
            var result = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
                result[i] = _random.Next(10);

            Console.WriteLine($"{nameof(StaticInteropService)}.{nameof(GenerateRandomNumbers)}: result = {result.Format()}");

            return Task.FromResult(result);
        }
    }
}
