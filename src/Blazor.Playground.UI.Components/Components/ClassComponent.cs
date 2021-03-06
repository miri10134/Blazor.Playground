﻿using Blazor.Playground.Contract.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Playground.UI.Components.Components
{
    public class ClassComponent : AComponentDemo
    {
        [Parameter]
        public int ChangeValue { get; set; }

        [Inject]
        public IRandomGenerator Generator {get;set;}

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var seq = 0;
            builder.OpenElement(seq++, "div");
            // h3
            builder.OpenElement(seq++, "h3");
            builder.AddContent(seq++, "Class Component");
            builder.CloseElement();

            // p
            builder.OpenElement(seq++, "p");
            builder.AddContent(seq++, $"This component is defined purely in C#.");
            builder.CloseElement();

            // p
            builder.OpenElement(seq++, "p");
            builder.AddContent(seq++, $"Is does exactly the same as the Razor Component.");
            builder.CloseElement();

            // p
            builder.OpenElement(seq++, "p");
            builder.AddContent(seq++, $"Current State: {StateService.State.CurrentState}");
            builder.CloseElement();

            // p
            builder.OpenElement(seq++, "p");
            builder.AddContent(seq++, $"ChangeValue: {ChangeValue} ");
            //p > span
            builder.OpenElement(seq++, "span");
            builder.AddAttribute(seq++, "class", "oi oi-reload");
            builder.AddAttribute(seq++, "onclick", EventCallback.Factory.Create(this, NewValue));
            builder.CloseElement();
            builder.CloseElement();

            // button
            builder.OpenElement(seq++, "button");
            builder.AddAttribute(seq++, "onclick", EventCallback.Factory.Create(this, Multiply));
            builder.AddContent(seq++, "Multiply");
            builder.CloseElement();

            builder.CloseElement();
        }

        private async Task Multiply()
        {
            await StateService.MultiplyState(ChangeValue);
        }

        private void NewValue()
        {
            ChangeValue = Generator.NextInt();
        }
    }
}
