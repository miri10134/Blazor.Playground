using Blazor.Playground.Common.Util;
using Blazor.Playground.UI.Components.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Playground.UI.Components.Lifecycle
{
    /// <summary>
    /// Abstract base class. All lifecycle methods are overridden to log calls.
    /// </summary>
    public abstract class ALifecycleComponent : AComponent, IDisposable
    {
        #region Lifecycle methods
        protected override void OnInitialized()
        {
            LogMethod();
        }
        protected override Task OnInitializedAsync()
        {
            LogMethod();
            return base.OnInitializedAsync();
        }

        protected override void OnParametersSet()
        {
            LogMethod();
            base.OnParametersSet();
        }
        protected override Task OnParametersSetAsync()
        {
            LogMethod();
            return base.OnParametersSetAsync();
        }
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            LogMethod();
            base.BuildRenderTree(builder);
        }
        public override Task SetParametersAsync(ParameterView parameters)
        {
            LogMethod(parameters.ToDictionary());
            return base.SetParametersAsync(parameters);
        }
        
        protected override bool ShouldRender()
        {
            var baseValue = base.ShouldRender(); // We could return a dummy value but this is a good way to explore the default behavior.
            LogMethod(new Dictionary<string, object> { { "return", baseValue } });
            return baseValue;
        }

        protected override void OnAfterRender(bool firstRender)
        {
            LogMethod(new Dictionary<string, object> { { nameof(firstRender), firstRender } });
            base.OnAfterRender(firstRender);
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            LogMethod(new Dictionary<string, object> { { nameof(firstRender), firstRender } });
            return base.OnAfterRenderAsync(firstRender);
        }

        #endregion

        #region Dispose and Finalize
        protected virtual void Dispose(bool disposing) 
            => LogMethod(new Dictionary<string, object> { { nameof(disposing), disposing } });

        ~ALifecycleComponent() => Dispose(disposing: false);

        public void Dispose() => Dispose(disposing: true);
        #endregion

        #region Logging

        /// <summary>
        /// Write current class type, method name and parameters to console output.
        /// Note: Since we do not call base.OnInitialized in the overriden method, <see cref="AComponent"/> does not use ILogger. This is intendet to avoid cluttering with class names.
        /// </summary>
        private void LogMethod(IReadOnlyDictionary<string, object> paramList = null, [CallerMemberName] string method = "")
        {
            Log($"{GetType().Name}: {method} {paramList.Format()}");
        }

        ///// <summary>
        ///// Dummy wrapper to simplify logging of async methods. Does not really work async. 
        ///// </summary>
        //private Task LogAsyncMethod(IReadOnlyDictionary<string, object> paramList = null, [CallerMemberName] string method = "")
        //{
        //    LogMethod(paramList, method);
        //    return Task.CompletedTask;
        //}

        #endregion 
    }
}
