using Blazor.Playground.UI.Components.Common;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Playground.UI.Components.RenderPerformance
{
    public abstract class APerformanceListComponent : AComponent
    {
        [Parameter]
        public IReadOnlyList<string> Values { get; set; }

        [Parameter]
        public Action<double> SetRendertime { get; set; }

        private DateTime RenderStartTime = DateTime.Now;
        protected override bool ShouldRender()
        {
            RenderStartTime = DateTime.Now;
            return base.ShouldRender();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            var diff = (DateTime.Now - RenderStartTime).TotalMilliseconds;
            SetRendertime?.Invoke(diff);
            base.OnAfterRender(firstRender);
        }

        protected List<string> CurrentValues { get; set; } = new List<string>();

        protected virtual async Task RemoveElement(string value)
        {
            if(CurrentValues.Remove(value))
                await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
        }

        protected virtual async Task Reset()
        {
            CurrentValues = Values.ToList();
            await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
        }
    }
}
