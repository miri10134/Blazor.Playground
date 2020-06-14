using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Playground.UI.Components.Components
{
    public partial class PartialComponent // Note: Base class has to be set in razor. Otherwise the compiler will get confused. Interfaces can be set and implemented here.
    {
        private string Value { get; set; }

        object ICloneable.Clone()
        {
            throw new NotImplementedException();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Value = $"Hello World, {nameof(PartialComponent)} initialized on the code side of life.";
        }

        //protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        //{
        //}
    }
}
