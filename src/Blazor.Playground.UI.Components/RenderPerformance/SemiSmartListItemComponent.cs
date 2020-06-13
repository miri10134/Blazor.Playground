using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Playground.UI.Components.RenderPerformance
{
    public class SemiSmartListItemComponent : ListItemComponent
    {
        private string OldValue { get; set; }
        private bool HasChanged { get; set; } = true;

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            HasChanged = Value != OldValue;
            OldValue = Value;
        }

        protected override bool ShouldRender()
        {
            return HasChanged;
        }
    }
}
