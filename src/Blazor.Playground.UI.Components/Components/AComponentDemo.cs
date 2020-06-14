using Blazor.Playground.Contract.Model;
using Blazor.Playground.Contract.Services;
using Blazor.Playground.UI.Components.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Playground.UI.Components.Components
{
    public abstract class AComponentDemo : AComponent, IDisposable
    {
        [Inject]
        public IStateService StateService { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            StateService.OnChange += Update;
        }

        private async Task Update(IState newState)
        {
            await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
        }

        public virtual void Dispose()
        {
            StateService.OnChange -= Update;
        }
    }
}
