using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Playground.UI.Components.SimpleComponents
{
    public partial class SimpleRazorComponent
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Log($"Hello World, {nameof(SimpleRazorComponent)} here from the code side of life.");
        }

        //protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        //{
        //}
    }
}
