using Blazor.Playground.Contract.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Playground.Contract.Services
{
    public class StateService : IStateService
    {
        private const int MAX_VALUE = 100;

        private readonly State State;
        private readonly IRandomGenerator Generator;

        public event ChangeEventHandler OnChange;

        public StateService(IRandomGenerator generator)
        {
            Generator = generator;
            State = new State()
            {
                CurrentState = Generator.NextInt(MAX_VALUE)
            };
        }

        private async Task NotifyOfChange() 
            => await (OnChange?.Invoke(State) ?? Task.CompletedTask).ConfigureAwait(false);

        #region IStateService
        IState IStateService.State => State;

        Task IStateService.IncrementState(int change)
        {
            State.CurrentState += change;
            return NotifyOfChange();
        }

        Task IStateService.MultiplyState(int change)
        {
            State.CurrentState *= change;
            return NotifyOfChange();
        }

        Task IStateService.ResetState()
        {
            State.CurrentState = Generator.NextInt(MAX_VALUE);
            return NotifyOfChange();
        }
        #endregion IStateService
    }
}
