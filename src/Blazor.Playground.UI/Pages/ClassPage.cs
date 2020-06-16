using Blazor.Playground.UI.Components.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blazor.Playground.UI.Pages
{
    [Route("/sample/{value}")]
    public class ClassPage : AComponent
    {
        [Parameter]
        public string Value { get; set; }
               
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var seq = 0;

            builder.OpenElement(seq++, "div");
            builder.AddAttribute(seq++, "class", "explanation");
            builder.OpenElement(seq++, "p");
            builder.AddContent(seq++, $"This page does nothing except for displaying the url parameter.");
            builder.CloseElement();
            builder.OpenElement(seq++, "p");
            builder.AddContent(seq++, $"Its only purpose is to demonstrate how a pure c# component can become a page by adding the Route attribute.");
            builder.CloseElement();
            builder.OpenElement(seq++, "p");
            builder.AddContent(seq++, $"Note: The route url and the parameter name are case-insensitive! The parameter value obviously not.");
            builder.CloseElement();
            builder.OpenElement(seq++, "p");
            builder.AddContent(seq++, $"It also shows that changing the value of the parameter property does not affect the url.");
            builder.CloseElement();
            builder.CloseElement();

            builder.OpenElement(seq++, "div");
            builder.AddContent(seq++, $"Parameter: {Value}");
            builder.CloseElement();

            builder.OpenElement(seq++, "button");
            builder.AddAttribute(seq++, "onclick", EventCallback.Factory.Create(this, Count));
            builder.AddContent(seq++, "Add +");
            builder.CloseElement();            
        }

        private void Count()
        {
            Value += "+";
        }
    }
}
