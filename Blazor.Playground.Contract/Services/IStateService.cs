using Blazor.Playground.Contract.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Playground.Contract.Services
{
    public delegate Task ChangeEventHandler(IState newState);

    public interface IStateService
    {
        IState State { get; }

        Task ResetState();

        Task IncrementState(int change);

        Task MultiplyState(int change);

        event ChangeEventHandler OnChange;
    }
}