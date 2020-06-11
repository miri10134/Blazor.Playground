using Blazor.Playground.UI.Components.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blazor.Playground.UI.Pages
{
    [Route("/Sample/{Value}")]
    public class ClassPage : AComponent
    {
        [Parameter]
        public string Value { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            builder.AddContent(1, $"Parameter: {Value}");
            builder.CloseElement();
        }
    }
}
