using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Playground.UI.Components.Common
{
    public abstract class AComponent : ComponentBase
    {
        private ILogger Logger { get; set; }

        [Inject]
        public ILoggerFactory LoggerFactory { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Logger = LoggerFactory?.CreateLogger(GetType().Name);
        }

        protected void Log(string message, LogLevel level = LogLevel.Information)
        {
            if (Logger != null)
            {
                Logger.Log(level, message);
            }
            else
            {
                Console.WriteLine(message);
            }
        }
    }
}
