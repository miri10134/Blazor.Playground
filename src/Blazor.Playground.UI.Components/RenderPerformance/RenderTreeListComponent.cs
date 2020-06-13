using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Playground.UI.Components.RenderPerformance
{
    public class RenderTreeListComponent : APerformanceListComponent
    {
        private Dictionary<string, int> ValueIndexes;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var seq = 0;

            builder.OpenElement(seq++, "button");
            builder.AddAttribute(seq++, "onclick", EventCallback.Factory.Create(this, Reset));
            builder.AddContent(seq++, "Refresh");
            builder.CloseElement();

            builder.OpenElement(seq++, "p");
            builder.OpenElement(seq++, "b");
            builder.AddContent(seq++, "Elements: ");
            builder.CloseElement();
            builder.AddContent(seq++, CurrentValues.Count);
            builder.CloseElement();

            builder.OpenElement(seq++, "ul");
            foreach(var value in CurrentValues)
            {
                var valueIndex = ValueIndexes[value] * 3;
                builder.OpenComponent<SemiSmartListItemComponent>(seq + valueIndex);
                builder.AddAttribute(seq + valueIndex + 1, "Value", value);
                builder.AddAttribute(seq + valueIndex + 2, "RemoveElement", (Func<string, Task>)RemoveElement);
                builder.CloseComponent();

                //builder.OpenComponent<SemiSmartListItemComponent>(seq++);
                //builder.AddAttribute(seq++, "Value", value);
                //builder.AddAttribute(seq++, "RemoveElement", (Func<string, Task>)RemoveElement);
                //builder.CloseComponent();
            }


            builder.CloseElement();
        }

        protected override Task Reset()
        {
            ValueIndexes = Values.Select((v, i) => new { Value = v, Index = i }).ToDictionary(v => v.Value, v => v.Index);

            return base.Reset();
        }
    }
}
