using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Playground.UI.Components.JsInterop
{
    public partial class JsInteropPlayground
    {
        private readonly Random _random = new Random();

        private async Task InvokeReturn()
        {
            var parameter = _random.Next(50);
            Console.WriteLine($"{nameof(JsInteropPlayground)}.{nameof(InvokeReturn)}: parameter = {parameter}");
            var result = await JsRuntime.InvokeAsync<int>("jsInterop.returnDoubled", parameter);
            Console.WriteLine($"{nameof(JsInteropPlayground)}.{nameof(InvokeReturn)}: result = {result}");
        }

        private async Task InvokeCallback()
        {
            var parameter = _random.Next(50);
            var reference = DotNetObjectReference.Create(this);
            Console.WriteLine($"{nameof(JsInteropPlayground)}.{nameof(InvokeCallback)}: parameter = {parameter}");
            await JsRuntime.InvokeVoidAsync("jsInterop.callBack", reference, nameof(ReceiveInstanceCallback), parameter);
            Console.WriteLine($"{nameof(JsInteropPlayground)}.{nameof(InvokeCallback)}: done");
        }

        [JSInvokable(nameof(ReceiveInstanceCallback))]
        public void ReceiveInstanceCallback(int number)
        {
            Console.WriteLine($"{nameof(JsInteropPlayground)}.{nameof(ReceiveInstanceCallback)}: received {number}");
        }

        [JSInvokable(nameof(ReceiveInstanceCallbackAsync))]
        public async Task ReceiveInstanceCallbackAsync(int number)
        {
            Console.WriteLine($"{nameof(JsInteropPlayground)}.{nameof(ReceiveInstanceCallbackAsync)}: received {number}");
            await Task.CompletedTask;
        }

        private async Task InvokeStaticCall()
        {
            var numberOfElements = _random.Next(4) + 1;
            Console.WriteLine($"{nameof(JsInteropPlayground)}.{nameof(InvokeStaticCall)}: number of elements = {numberOfElements}");
            await JsRuntime.InvokeVoidAsync("jsInterop.callStaticMethod", numberOfElements);
        }
    }
}
