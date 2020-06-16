using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.Playground.UI.Components.Threading
{
    public partial class ThreadingPlayground : IDisposable
    {
        private string State { get; set; } = "Normal";
        private Timer TimerInstance { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            TimerInstance = new Timer(Count, null, 1000, 1000);
        }

        private void Count(object state)
        {
            StateHasChanged();
        }

        private async Task Delay()
        {
            State = "Delaying ...";
            await Task.Delay(3000);
            State = "Normal";
        }

        private void Wait()
        {
            State = "Waiting ...";
            Task.Delay(1000).Wait();
            State = "Normal";
        }

        private void Run()
        {
            State = "Running ...";
            Task.Run(() =>
            {
                var targetTime = DateTime.Now.AddSeconds(3);
                while(DateTime.Now < targetTime)
                {
                    // busy waiting
                }
                State = "Done Internal";
            });
            State = "Normal";
        }

        private void Sleep()
        {
            State = "Sleeping";
            Thread.Sleep(3000);
            State = "Normal";
        }

        private void StartThread()
        {
            var t = new Thread(ThreadTask);
            t.Start();
        }

        private void ThreadTask()
        {
            State = "Thread started";
            Console.WriteLine("Thread started");
        }

        /// <summary>
        /// Dispose the <see cref="Timer"/>-Instance
        /// </summary>
        public void Dispose()
        {
            TimerInstance?.Dispose();
        }
    }
}
