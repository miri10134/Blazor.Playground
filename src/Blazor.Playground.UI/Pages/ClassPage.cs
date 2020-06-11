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
            builder.OpenElement(2, "div");
            builder.AddContent(3, $"This page does nothing except for displaying the url parameter. Its only purpose is to demonstrate how a pure c# component can become a page by adding the Route attribute.");
            builder.CloseElement();
        }
    }
}
